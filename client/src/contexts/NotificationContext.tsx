import React, {
  createContext,
  useState,
  useContext,
  useCallback,
  ReactNode,
  useEffect,
} from "react";
import axios from "axios";
import { buildApiUrl } from "@/lib/utils";
import { Notification } from "@/components/interfaces/Notification";

export enum NotificationStatus {
  READ = "read",
  UNREAD = "unread"
}

interface NotificationContextType {
  notifications: Notification[];
  addNotification: (
    message: string,
    additionalProps?: Partial<Notification>
  ) => void;
  markNotificationAsRead: (id: number) => Promise<void>;
  clearNotifications: () => void;
  getUnreadCount: () => number;
  fetchNotifications: () => Promise<Notification[]>;
}

const NotificationContext = createContext<NotificationContextType | undefined>(
  undefined
);

export const NotificationProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [notifications, setNotifications] = useState<Notification[]>([]);

  const fetchNotifications = useCallback(async (): Promise<Notification[]> => {
    try {
      const response = await axios.get(buildApiUrl("/notifications"), {
        withCredentials: true,
      });

      setNotifications(response.data);
      return response.data;
    } catch (error) {
      console.error("Failed to fetch notifications", error);
      return [];
    }
  }, []);

  const addNotification = useCallback(
    (
      message: string,
      additionalProps: Partial<Notification> = {}
    ) => {
      const timestamp = new Date();
      const newNotification: Notification = {
        notification_id: additionalProps.notification_id || Date.now(),
        user_id: additionalProps.user_id || 0,
        message,
        status: additionalProps.status || NotificationStatus.UNREAD,
        created_at: additionalProps.created_at || timestamp,
      };

      setNotifications((prev) => {
        const exists = prev.some(
          (n) =>
            n.message === message &&
            n.notification_id === newNotification.notification_id
        );

        return exists ? prev : [newNotification, ...prev];
      });
    },
    []
  );

  const markNotificationAsRead = useCallback(
    async (notification_id: number) => {
      try {
        await axios.put(
          buildApiUrl(`/notifications/${notification_id}/read`)
          , {}, {
          withCredentials: true
        });

        setNotifications((prev) =>
          prev.map((notification) =>
            notification.notification_id === notification_id
              ? { ...notification, status: NotificationStatus.READ }
              : notification
          )
        );
      } catch (error) {
        console.error("Failed to mark notification as read", error);
      }
    },
    []
  );

  const clearNotifications = useCallback(() => {
    setNotifications([]);
  }, []);

  const getUnreadCount = useCallback(() => {
    return notifications.filter((n) => n.status === NotificationStatus.UNREAD).length;
  }, [notifications]);

  useEffect(() => {
    fetchNotifications();
  }, [fetchNotifications]);

  return (
    <NotificationContext.Provider
      value={{
        notifications,
        addNotification,
        markNotificationAsRead,
        clearNotifications,
        getUnreadCount,
        fetchNotifications,
      }}
    >
      {children}
    </NotificationContext.Provider>
  );
};

export const useNotifications = () => {
  const context = useContext(NotificationContext);
  if (context === undefined) {
    throw new Error(
      "useNotifications must be used within a NotificationProvider"
    );
  }
  return context;
};
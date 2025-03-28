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

export interface Notification {
  id: string;
  message: string;
  type: "info" | "success" | "warning" | "error";
  timestamp: number;
  read?: boolean;
  originalId?: string;
}

interface NotificationContextType {
  notifications: Notification[];
  addNotification: (
    message: string,
    type?: Notification["type"],
    additionalProps?: Partial<Notification>
  ) => void;
  markNotificationAsRead: (id: string) => Promise<void>;
  clearNotifications: () => void;
  getUnreadCount: () => number;
  fetchNotifications: () => Promise<void>;
}

const NotificationContext = createContext<NotificationContextType | undefined>(
  undefined
);

export const NotificationProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [notifications, setNotifications] = useState<Notification[]>([]);

  const fetchNotifications = useCallback(async () => {
    try {
      const response = await axios.get(buildApiUrl("/notifications"), {
        withCredentials: true,
      });

      const fetchedNotifications: Notification[] = response.data.map(
        (notification: any) => ({
          id: notification.notification_id,
          message: notification.message,
          type: "info",
          timestamp: new Date(notification.created_at).getTime(),
          read: notification.status === "read",
          originalId: notification.notification_id,
        })
      );

      setNotifications(fetchedNotifications);
    } catch (error) {
      console.error("Failed to fetch notifications", error);
    }
  }, []);

  const addNotification = useCallback(
    (
      message: string,
      type: Notification["type"] = "info",
      additionalProps: Partial<Notification> = {}
    ) => {
      const newNotification: Notification = {
        id:
          additionalProps.id ||
          `notification-${Date.now()}-${Math.random()
            .toString(36)
            .substr(2, 9)}`,
        message,
        type,
        timestamp: additionalProps.timestamp || Date.now(),
        read: additionalProps.read || false,
        originalId: additionalProps.id,
      };

      setNotifications((prev) => {
        const exists = prev.some(
          (n) =>
            n.message === message && n.originalId === newNotification.originalId
        );

        return exists ? prev : [newNotification, ...prev];
      });
    },
    []
  );

  const markNotificationAsRead = useCallback(
    async (id: string) => {
      const notification = notifications.find((n) => n.id === id);

      if (notification?.originalId) {
        try {
          await axios.put(
            buildApiUrl(`/notifications/${notification.originalId}/read`)
          );
        } catch (error) {
          console.error("Failed to mark notification as read", error);
        }
      }

      setNotifications((prev) =>
        prev.map((notification) =>
          notification.id === id
            ? { ...notification, read: true }
            : notification
        )
      );
    },
    [notifications]
  );

  const clearNotifications = useCallback(() => {
    setNotifications([]);
  }, []);

  const getUnreadCount = useCallback(() => {
    return notifications.filter((n) => !n.read).length;
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

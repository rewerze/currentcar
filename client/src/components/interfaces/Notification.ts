export enum NotificationStatus {
    READ = "read",
    UNREAD = "unread"
}

export interface Notification {
    notification_id: number;
    user_id: number;
    message: string;
    status: NotificationStatus;
    created_at: Date
}
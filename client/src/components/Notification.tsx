import { useEffect, useState } from "react";
import { NotificationStatus, type Notification } from "./interfaces/Notification";
import { useUser } from "@/contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { useNotifications } from "@/contexts/NotificationContext";

function Notification() {
    const [notifications, setNotifications] = useState<Notification[]>();
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const notification = useNotifications();
    const { user, loading } = useUser();
    const navigate = useNavigate();

    useEffect(() => {
        if (!loading && !user) {
            navigate("/register");
        } else if (!loading && user) {
            const getNotifications = async () => {
                const response: Notification[] = await notification.fetchNotifications();
                const notificationsArray = Array.isArray(response) ? response : [response];
                setNotifications(notificationsArray);
            };
            getNotifications();
        }
    }, [user, loading]);

    function changeNotification(event: React.MouseEvent<HTMLButtonElement>) {
        const id = event.currentTarget.getAttribute("data-id");

        if (id && notifications) {
            const selectedNotification = notifications.find((notif) => notif.notification_id === parseInt(id));

            if (selectedNotification?.status == NotificationStatus.UNREAD) {
                notification.markNotificationAsRead(parseInt(id))
                selectedNotification.status = NotificationStatus.READ
            }

            setTitle(`Értesítés #${id}`)
            setDescription(selectedNotification?.message || "");
        }
    }
    return (
        <>
            <main className="nav-gap">
                <h1 className="text-center" id="top">Értesítések</h1>
                <div className="notif bg-dark">
                    <div className="row">
                        <h2>Bejövő értesítések</h2>
                        <div className="col-md-4 notif-hidden">
                            <div className="notif-card mt-5">
                                {notifications && notifications?.length > 0 &&
                                    notifications.map((value, _) => (
                                        <div key={value.notification_id} className="notif-card-content">
                                            <button onClick={changeNotification} data-id={value.notification_id}>
                                                <h3>Értesítés</h3>
                                                <p>{value.message.substring(0, 40)}...</p>
                                            </button>
                                        </div>
                                    ))
                                }
                            </div>
                        </div>
                        <div className="col-md-8">
                            <div className="notif-message">
                                <h2>{title}</h2>
                                <p>{description}</p>
                                <a className="btn btn-primary" href="#top">Vissza</a>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </>
    )
}

export default Notification;
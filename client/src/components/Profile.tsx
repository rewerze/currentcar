import "bootstrap/dist/css/bootstrap.min.css";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";

import delete_icon from "../assets/img/delete.svg";
import logout_icon from "../assets/img/logout.svg";
import edit_icon from "../assets/img/edit.svg";
import password_icon from "../assets/img/password.svg";
import notification_icon from "../assets/img/message.svg";

import templateImage from "../assets/img/nepszeru_auto.png";
import { useNotifications } from "@/contexts/NotificationContext";
import { useLanguage } from "@/contexts/LanguageContext";
import { CarInfo } from "./interfaces/Car";
import axios from "axios";
import { buildApiUrl } from "@/lib/utils";

function Profile() {
  const { user, loading } = useUser();
  const [cars, setCars] = useState<CarInfo[]>([]);
  const { t, loadedNamespaces, loadNamespace } = useLanguage();
  const navigate = useNavigate();
  const { notifications } = useNotifications();
  const [notificationCount, setNotificationCount] = useState<number>(0);

  const handleDelete = () => {

  };

  useEffect(() => {
    if (!loadedNamespaces.includes("Profile")) {
      loadNamespace("Profile");
    }
  }, [loadedNamespaces, loadNamespace]);

  useEffect(() => {
    const fetchCars = async () => {
      try {
        const response = await axios.get(buildApiUrl("/getCars"), {
          withCredentials: true,
        });

        setCars(response.data);
      } catch (err) {
        console.error("Failed to fetch cars", err);
      }
    };

    fetchCars();
  }, []);

  useEffect(() => {
    setNotificationCount(notifications.length);
  }, [notifications]);

  useEffect(() => {
    if (!loading && !user) {
      navigate("/register");
    }
  }, [user, loading, navigate]);

  return (
    <>
      <main className="nav-gap">
        <div className="profile-center">
          <div className="profile-form">
            <div className="bg-dark profile-form-box text-light profile-data">
              <h1 className="text-center">{t("profile", "Profile")}</h1>
              <hr />
              <div className="row d-flex justify-content-center">
                <div className="col data-list">
                  <p>
                    <b>{t("username", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.user_name ? new String(user.user_name) : "N/a"}
                    </span>
                  </p>
                  <p>
                    <b>{t("email", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.user_email ? new String(user.user_email) : "N/a"}
                    </span>
                  </p>
                  <p>
                    <b>{t("birthdate", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.born_at
                        ? new Date(user.born_at).toLocaleString("hu-HU", {
                          year: "numeric",
                          month: "numeric",
                          day: "numeric",
                        })
                        : "N/a"}
                    </span>
                  </p>
                  <p>
                    <b>{t("phone", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.u_phone_number
                        ? new String(user.u_phone_number)
                        : "N/a"}
                    </span>
                  </p>
                  <p>
                    <b>{t("access", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.user_role === "user"
                        ? t("user", "Profile")
                        : t("admin", "Profile")}
                    </span>
                  </p>
                  <p>
                    <b>{t("license_number", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.driver_license_number
                        ? new String(user.driver_license_number)
                        : "N/a"}
                    </span>
                  </p>
                  <p>
                    <b>{t("license_expiry", "Profile")}: </b>
                    <span className="badge bg-secondary">
                      {user?.driver_license_expiry
                        ? new Date(user.driver_license_expiry).toLocaleString(
                          "hu-HU"
                        )
                        : "N/a"}
                    </span>
                  </p>
                  <a className="mt-2 text-light" href="/profil/profilkep">
                    <b>{t("change_profile_picture", "Profile")}</b>
                  </a>
                </div>
              </div>
            </div>

            {/* Profile Buttons */}
            <div className="profile-form-box bg-dark text-light mx-1">
              <div className="profile-buttons">
                <div>
                  <a href="/profil/modositas" className="btn btn-primary w-100">
                    <span>
                      <img src={edit_icon} className="icon mx-2" />
                    </span>
                    <b>{t("edit_data", "Profile")}</b>
                  </a>
                </div>

                <div>
                  <a href="/logout" className="btn btn-light w-100">
                    <span>
                      <img src={logout_icon} className="icon mx-2" />
                    </span>
                    <b>{t("logout", "Profile")}</b>
                  </a>
                </div>

                <div>
                  <a
                    href="/profil/jelszo-modositas"
                    className="btn btn-warning w-100"
                  >
                    <span>
                      <img src={password_icon} className="icon mx-2" />
                    </span>
                    <b>{t("change_password", "Profile")}</b>
                  </a>
                </div>

                <div>
                  <a onClick={handleDelete} className="btn btn-danger w-100">
                    <span>
                      <img src={delete_icon} className="icon mx-2" />
                    </span>
                    <b>{t("delete_profile", "Profile")}</b>
                  </a>
                </div>

                <div>
                  <a href="/profil/ertesitesek" className="btn btn-info w-100">
                    <span>
                      <img src={notification_icon} className="icon mx-2" />
                    </span>
                    <b>
                      {t("notifications", "Profile")} (
                      {notificationCount.toString()})
                    </b>
                  </a>
                </div>
              </div>
            </div>
          </div>


          {/* KOCSIK */}
          <div className="profile-car gap-2">
            {cars.map((car, index) => (
              <div key={index} className="profile-car-card" onClick={() => navigate(`/adatlap/${car.car_id}`)}>
                <div className="profile-car-card-body bg-dark">
                  <img
                    src={
                      car.car_id
                        ? `${import.meta.env.PROD ? "/api" : "http://localhost:3000/api"}/getCarImage?car_id=${car.car_id}`
                        : templateImage
                    }
                    onError={(e) => { (e.target as HTMLImageElement).src = templateImage }}
                    className="profile-car-img"
                  />
                  <h3 className="text-center">
                    {car.car_brand} {car.car_model}
                  </h3>
                  <p>{car.car_description}</p>
                  <div className="profile-car-btn">
                    <button
                      className="btn badge bg-primary"
                      onClick={(e) => { e.stopPropagation(); console.log("Edit clicked"); }}
                    >
                      <img src={edit_icon} />
                    </button>
                    <button
                      className="btn badge bg-danger"
                      onClick={(e) => { e.stopPropagation(); console.log("Delete clicked"); }}
                    >
                      <img src={delete_icon} />
                    </button>
                  </div>
                </div>
              </div>
            ))}

          </div>
        </div>
      </main>
    </>
  );
}

export default Profile;

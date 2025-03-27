import { useNavigate } from "react-router-dom";
import { useUser } from "../contexts/UserContext";
import profil from "../assets/img/profile.jpg";
import LanguageSwitcher from "./LanguageSwitcher";
import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect, useState } from "react";
import { useNotifications } from "@/contexts/NotificationContext";

function Nav() {
  const { user } = useUser();
  const { t, loadedNamespaces, loadNamespace } = useLanguage();
  const navigate = useNavigate();
  const { notifications } = useNotifications();

  const [notificationCount, setNotificationCount] = useState<Number>(0);

  useEffect(() => {
    setNotificationCount(notifications.length);
  }, [notifications]);

  useEffect(() => {
    if (!loadedNamespaces.includes("navbar")) {
      loadNamespace("navbar");
    }
  }, [loadedNamespaces, loadNamespace]);

  return (
    <>
      {/* ############################
        #            NAVBAR            #
        ############################ */}
      <nav
        className="navbar navbar-expand-lg bg-body-tertiary w-100"
        data-bs-theme="dark"
      >
        <div className="container-fluid mx-5">
          <a href="/" className="navbar-brand">
            CurRentCar
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarScroll"
            aria-controls="navbarScroll"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarScroll">
            <ul className="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll">
              <li className="nav-item">
                <a
                  className="nav-link active"
                  aria-current="page"
                  href="/utiterv"
                >
                  {t("itinerary", "navbar")}
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link active"
                  aria-current="page"
                  href="/osszesauto"
                >
                  {t("allcars", "navbar")}
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link active"
                  aria-current="page"
                  href="/kovetelmenyek"
                >
                  {t("requirements", "navbar")}
                </a>
              </li>
            </ul>
            <div className="me-5 second-nav d-flex justify-content-start off-link">
              <LanguageSwitcher />
              {user && user.user_id ? (
                <a
                  onClick={() => navigate("/profil")}
                  className="btn text-light"
                >
                  {user.user_name}
                  <img src={profil} alt="" className="profile profile-nav" />
                  <span className="badge bg-danger notification">
                    {notificationCount.toString()}
                  </span>
                </a>
              ) : (
                <a onClick={() => navigate("/register")} className="btn">
                  {t("register", "navbar")}
                </a>
              )}
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default Nav;

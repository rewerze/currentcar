import "bootstrap/dist/css/bootstrap.min.css";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

import delete_icon from "../assets/img/delete.svg";
import logout_icon from "../assets/img/logout.svg";
import edit_icon from "../assets/img/edit.svg";
import password_icon from "../assets/img/password.svg";
import notification_icon from "../assets/img/message.svg";

import car from "../assets/img/nepszeru_auto.png";

function Profile() {
  const { user, loading } = useUser();
  const navigate = useNavigate();

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
            <h1 className="text-center">Profilod</h1>
            <hr />
            <div className="row d-flex justify-content-center">
              <div className="col data-list">
                <p>
                  <b>Felhasználónév: </b>
                  <span className="badge bg-secondary">
                    {user?.user_name ? new String(user.user_name) : "N/a"}
                  </span>
                </p>
                <p>
                  <b>Email cím: </b>
                  <span className="badge bg-secondary">
                    {user?.user_email ? new String(user.user_email) : "N/a"}
                  </span>
                </p>

                <p>
                  <b>Születési dátum: </b>
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
                  <b>Telefon szám: </b>
                  <span className="badge bg-secondary">
                    {user?.u_phone_number ? new String(user.u_phone_number) : "N/a"}
                  </span>
                </p>
                <p>
                  <b>Hozzáférésed: </b>
                  <span className="badge bg-secondary">
                    {user?.user_role === "user" ? "Felhasználó" : "Admin"}
                  </span>
                </p>
                <p>
                  <b>Jogosítvány szám: </b>
                  <span className="badge bg-secondary">
                    {user?.driver_license_number ? new String(user.driver_license_number) : "N/a"}
                  </span>
                </p>
                <p>
                  <b>Jogosítvány lejárati dátuma: </b>
                  <span className="badge bg-secondary">
                    {user?.driver_license_expiry
                      ? new Date(user.driver_license_expiry).toLocaleString("hu-HU")
                      : "N/a"}
                  </span>
                </p>
                <a className="mt-2 text-light" href="/profil/profilkep">
                  <b>Profilkép csere</b>
                </a>
              </div>
            </div>
          </div>

          {/* PROFIL GOMBOK */}
              <div className="profile-form-box bg-dark text-light mx-1">
                <div className="profile-buttons">

                  {/* EDIT */}
                  <div>
                  <a href="/profil/modositas" className="btn btn-primary w-100">
                  <span><img src={edit_icon} className="icon mx-2" /></span>
                  <b>
                    Adatok módosítása
                  </b>
                  </a>
                  </div>

                  {/* LOGOUT */}
                  <div>
                  <a href="/logout" className="btn btn-light w-100">
                  <span><img src={logout_icon} className="icon mx-2" /></span>
                  <b>
                    Kijelentkezés
                  </b>
                  </a>
                  </div>


                  {/* PASS MOD */}
                  <div>
                  <a href="/profil/jelszo-modositas" className="btn btn-warning w-100">
                  <span><img src={password_icon} className="icon mx-2" /></span>
                  <b>
                    Jelszó módosítás
                  </b>
                  </a>
                  </div>

                  {/* DELETE */}
                  <div>
                  <a href="/profil/torles" className="btn btn-danger w-100">
                  <span><img src={delete_icon} className="icon mx-2" /></span>
                  <b>
                    Profil törlés
                  </b>
                  </a>
                  </div>

                  {/* NOTIFICATION */}
                  <div>
                  <a href="/profil/ertesitesek" className="btn btn-info w-100">
                  <span><img src={notification_icon} className="icon mx-2" /></span>
                  <b>
                    Értesítések
                  </b>
                  </a>
                  </div>
                </div>
              </div>
            </div>
            <div className="profile-car gap-2">
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
              <div className="profile-car-card">
                <div className="profile-car-card-body bg-dark">
                      <img src={car} />
                      <h3 className="text-center">car name</h3>
                      <p>lorem ipsum</p>
                </div>
              </div>
            </div>        
        </div>
      </main>
    </>
  );
}

export default Profile;

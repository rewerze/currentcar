import "bootstrap/dist/css/bootstrap.min.css";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

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
        <div className="profile-form">
          <div className="bg-dark profile-form-box text-light w-100">
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

            <div className="d-flex justify-content-center gap-3 mt-5 profile-buttons">
              <a href="/profil/modositas" className="btn btn-primary">
                Adatok módosítása
              </a>
              <a href="/logout" className="btn btn-light text-center">
                Kijelentkezés
              </a>
              <a href="/profil/jelszo-modositas" className="btn btn-warning">
                Jelszó módosítás
              </a>
              <a href="/profil/torles" className="btn btn-danger">
                Profil törlés
              </a>
            </div>
          </div>
        </div>

        <div className="profile-form">
              <div className="profile-form-box bg-dark text-light mx-1">
                <div className="profile-buttons">
                  <a href="/profil/modositas" className="btn btn-primary">
                    Adatok módosítása
                  </a>
                  <a href="/logout" className="btn btn-light">
                    Kijelentkezés
                  </a>
                  <a href="/profil/jelszo-modositas" className="btn btn-warning">
                    Jelszó módosítás
                  </a>
                  <a href="/profil/torles" className="btn btn-danger">
                    Profil törlés
                  </a>
                  <a href="/profil/torles" className="btn btn-info">
                    Értesítések
                  </a>
                </div>
              </div>
            </div>
      </main>
    </>
  );
}

export default Profile;

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
      <main>
        <div className="nav-gap form">
          <div className="bg-dark form-box text-light">
            <h1 className="text-center">Profilod</h1>
            <hr />
            <div className="row d-flex justify-content-center">
              <div className="col data-list">
                <p>
                  <b>Felhasználó név:</b>
                </p>
                <p>
                  <b>Email cím:</b>
                </p>

                <p>
                  <b>Születési dátum:</b>
                </p>
                <p>
                  <b>Telefon szám: </b>
                </p>
                <p>
                  <b>Hozzáférésed: </b>
                </p>
                <p>
                  <b>Jogosítvány szám: </b>
                </p>
                <p>
                  <b>Jogosítvány lejárati dátuma: </b>
                </p>
                <a className="mt-2 text-light" href="/profil/kepcsere">
                  <b>Profilkép csere</b>
                </a>
              </div>
              <div className="col data-list end">
                <p>{user?.username ? new String(user.username) : "N/a"}</p>
                <p>{user?.email ? new String(user.email) : "N/a"}</p>
                <p>
                  {user?.born_date
                    ? new Date(user.born_date).toLocaleString("hu-HU", {
                        year: "numeric",
                        month: "numeric",
                        day: "numeric",
                      })
                    : "N/a"}
                </p>
                <p>
                  {user?.phone_number ? new String(user.phone_number) : "N/a"}
                </p>
                <p>{user?.role == "user" ? "Felhasználó" : "Admin"}</p>
                <p>
                  {user?.jogositvany_szam
                    ? new String(user.jogositvany_szam)
                    : "N/a"}
                </p>
                <p>
                  {user?.jogositvany_lejarat
                    ? new Date(user.jogositvany_lejarat).toLocaleString("hu-HU")
                    : "N/a"}
                </p>
              </div>
            </div>

            <div className="d-flex justify-content-center gap-3 mt-5">
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
      </main>
    </>
  );
}

export default Profile;

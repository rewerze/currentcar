import { useUser } from "@/contexts/UserContext";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

function EditProfile() {
  const { user, loading } = useUser();
  const navigate = useNavigate();

  useEffect(() => {
    if (!user && !loading) {
      navigate("/register");
    }
  }, [user, loading, navigate]);
  return (
    <>
      <main className="nav-gap">
        <form action="/profil/modositas" method="post" className="form">
          <div className="form-box bg-dark">
            <h1>Felhasználói adatok módosítása</h1>

            {/* FELHASZNÁLÓNÉV */}
            <label htmlFor="user_name" className="form-label">
              Felhasználónév:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            {/* EMAIL CÍM */}
            <label htmlFor="user_name" className="form-label mt-3">
              E-mail cím:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            {/* SZÜLETÉSI DÁTUM */}
            <label htmlFor="user_name" className="form-label mt-3">
              Születési dátum:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
              disabled
            />

            {/* TELEFONSZÁM */}
            <label htmlFor="user_name" className="form-label mt-3">
              Telefonszám:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            {/* Jogosítvány szám */}
            <label htmlFor="user_name" className="form-label mt-3">
              Jogosítvány szám:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            {/* Jogosítvány lejárati dátuma */}
            <label htmlFor="user_name" className="form-label mt-3">
              Jogosítvány lejárati dátuma:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            {/* IBAN SZÁM */}
            <label htmlFor="user_name" className="form-label mt-3">
              IBAN:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              className="form-control"
            />

            <div className="d-flex justify-content-center mt-5 gap-3">
              <a href="/profil/kepcsere" className="btn btn-light w-25">
                Profilkép csere
              </a>
              <a
                href="/profil/jelszo-modositas"
                className="btn btn-warning w-25"
              >
                Jelszó módosítása
              </a>
              <button type="submit" className="btn btn-success w-25">
                Adatok mentése
              </button>
              <a href="./" className="btn btn-danger w-25">
                Elvetés
              </a>
            </div>
          </div>
        </form>
      </main>
    </>
  );
}

export default EditProfile;

/* eslint-disable react-hooks/exhaustive-deps */
import { useNavigate } from "react-router-dom";
import { useUser } from "../contexts/UserContext";
import { useEffect, useState } from "react";
import { toast } from "sonner";
import { useLanguage } from "@/contexts/LanguageContext";

function Reg() {
  const { register, user, loading, error } = useUser();
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordAgain, setPasswordAgain] = useState("");
  const [username, setUsername] = useState("");
  const [bornDate, setBornDate] = useState("");

  const { t, loadedNamespaces, loadNamespace } = useLanguage();

  useEffect(() => {
    if (!loadedNamespaces.includes("auth"))
      loadNamespace("auth");
  }, [loadedNamespaces]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (password !== passwordAgain) {
      toast("A két jelszó nem egyezik!");
      return;
    }

    register(username, password, email, bornDate);
  };

  useEffect(() => {
    if (!loading && user) {
      navigate("/profil");
    }
  }, [user, loading, navigate]);

  return (
    <>
      <main className="nav-gap">
        <form onSubmit={handleSubmit}>
          <div className="form">
            <div className="form-box bg-dark text-light">
              <h1>{t('register', 'auth')}</h1>
              <hr />

              {/* FELHASZNÁLÓNÉV */}
              <div className="form-content mt-2">
                <label htmlFor="name" className="form-label">{t('username', 'auth')}:</label>
                <input
                  type="text"
                  name="name"
                  id="name"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  className="form-control"
                  placeholder={t('whats_your_name', 'auth')}
                  required
                />
              </div>

              {/* JELSZÓ */}
              <div className="form-content mt-2">
                <label htmlFor="password" className="form-label">{t('password', 'auth')}:</label>
                <input
                  type="password"
                  name="password"
                  id="password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  className="form-control"
                  placeholder={t('whats_your_password', 'auth')}
                  required
                />
              </div>

              {/* JELSZÓ ISMÉTLÉSE */}
              <div className="form-content mt-2">
                <label htmlFor="password-confirmation" className="form-label">{t('repeat_password', 'auth')}:</label>
                <input
                  type="password"
                  name="password-confirmation"
                  id="password-confirmation"
                  value={passwordAgain}
                  onChange={(e) => setPasswordAgain(e.target.value)}
                  className="form-control"
                  placeholder={t('repeat_your_password', 'auth')}
                  required
                />
              </div>

              {/* EMAIL CÍM */}
              <div className="form-content mt-2">
                <label htmlFor="email" className="form-label">{t('email', 'auth')}:</label>
                <input
                  type="email"
                  name="email"
                  id="email"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  className="form-control"
                  placeholder={t('whats_your_email', 'auth')}
                  required
                />
              </div>

              {/* SZÜLETÉSI DÁTUM */}
              <div className="form-content mt-2">
                <label htmlFor="date" className="form-label">{t('born_date', 'auth')}:</label>
                <input
                  type="date"
                  name="date"
                  id="date"
                  value={bornDate}
                  onChange={(e) => setBornDate(e.target.value)}
                  className="form-control"
                  required
                />
              </div>

              {/* SUBMIT GOMB */}
              <button type="submit" className="btn btn-success mt-5 w-100" disabled={loading}>
                {loading ? t('register', 'auth') + "..." : t('register', 'auth')}
              </button>

              {error && <p className="text-danger text-center mt-2">{error}</p>}

              <p className="text-center text-light mt-4" dangerouslySetInnerHTML={{ __html: t('already_registered', 'auth') }}>
              </p>
            </div>
          </div>
        </form>
      </main>
    </>
  );
}

export default Reg;

import { useEffect, useState } from "react";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { useLanguage } from "@/contexts/LanguageContext";

function Login() {
  const { login, user, loading, error } = useUser();
  const navigate = useNavigate();

  const { t, loadedNamespaces, loadNamespace } = useLanguage();

  useEffect(() => {
    if (!loadedNamespaces.includes("auth"))
      loadNamespace("auth");
  }, [loadedNamespaces]);

  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    login(email, password);
  };

  useEffect(() => {
    if (!loading && user) {
      navigate("/profil");
    }
  }, [user, loading, navigate]);

  return (
    <>
      {/* ############################
        #              Login           #
        ############################ */}
      <main className="nav-gap">
        <form action="/login" onSubmit={handleSubmit}>
          <div className="form">
            <div className="form-box bg-dark text-light">
              <h1>{t('login', 'auth')}</h1>
              <hr />


              {/* EMAIL CÍM */}
              <div className="form-content mt-2">
                <label htmlFor="email" className="form-label">{t('email', 'auth')}:</label>
                <input
                  type="email"
                  name="email"
                  id="email"
                  value={email} onChange={(e) => setEmail(e.target.value)}
                  className="form-control"
                  placeholder={t('whats_your_email', 'auth')}
                />
              </div>

              {/* JELSZÓ */}
              <div className="form-content mt-2">
                <label htmlFor="password" className="form-label">{t('password', 'auth')}:</label>
                <input
                  type="password"
                  name="password"
                  id="password"
                  value={password} onChange={(e) => setPassword(e.target.value)}
                  className="form-control"
                  placeholder={t('whats_your_password', 'auth')} />
              </div>

              {/* SUBMIT GOMB */}
              <button type="submit" className="btn btn-success mt-5 w-100">{t('login', 'auth')}</button>

              {error && <p className="text-danger text-center mt-2">{error}</p>}
              <p className="text-center text-light mt-4" dangerouslySetInnerHTML={{ __html: t('havent_registered', 'auth') }}></p>
            </div>
          </div>
        </form>
      </main>
    </>
  )
}

export default Login;




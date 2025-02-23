import { useEffect, useState } from "react";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";

function Login() {
  const { login, user, loading, error } = useUser();
  const navigate = useNavigate();

  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    login(email, password);
  };

  useEffect(() => {
    if (!loading && user) {
      navigate("/");
    }
  }, [user, loading, navigate]);

  return (
    <>
      {/* ############################
        #              Login           #
        ############################ */}
      <form action="/login" onSubmit={handleSubmit}>
        <div className="form">
          <div className="form-box bg-green">
            <h1>Bejelentkezés</h1>


            {/* EMAIL CÍM */}
            <div className="form-content mt-2">
              <label htmlFor="email" className="form-label">Email cím:</label>
              <input type="email" name="email" id="email" value={email} onChange={(e) => setEmail(e.target.value)} className="form-control" placeholder="pl.: pelda@domain.hu" />
            </div>

            {/* JELSZÓ */}
            <div className="form-content mt-2">
              <label htmlFor="password" className="form-label">Jelszó:</label>
              <input type="password" name="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} className="form-control" placeholder="Jelszó" />
            </div>

            {/* SUBMIT GOMB */}
            <button type="submit" className="btn btn-dark mt-4 w-100">Bejelentkezés</button>

            {error && <p className="text-danger text-center mt-2">{error}</p>}
            <p className="text-center text-light mt-4">Ha még nem jelentkezett be akkor <a href="/register" className="login-button">regisztráljon!</a></p>
          </div>
        </div>
      </form>
    </>
  )
}

export default Login;




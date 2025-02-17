function Login() {

    function login() {
        
    }

    return(
        <>
        {/* ############################
        #              Login           #
        ############################ */}
      <form action="/login">
        <div className="form">
          <div className="form-box">
            <h1>Bejelentkezés</h1>


            {/* EMAIL CÍM */}
            <div className="form-content mt-2">
              <label htmlFor="email" className="form-label">Email cím:</label>
              <input type="email" name="email" id="email" className="form-control" placeholder="pl.: pelda@domain.hu" />
            </div>
            
            {/* JELSZÓ */}
            <div className="form-content mt-2">
                <label htmlFor="password" className="form-label">Jelszó:</label>
                <input type="password" name="password" id="password" className="form-control" placeholder="Jelszó" />
            </div>

            {/* SUBMIT GOMB */}
            <button type="submit" onClick={login()} className="btn btn-dark mt-4 w-100">Bejelentkezés</button>
            <p className="text-center text-light mt-4">Ha még nem jelentkezett be akkor <a href="/register" className="text-info">regisztráljon!</a></p>
          </div>
        </div>
      </form>
    </>
    )
}

export default Login;
    
    
    

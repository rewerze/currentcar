function Reg() {

    function register() {
        
    }

    return(
        <>
        {/* ############################
        #              Reg             #
        ############################ */}
      <form action="/register">
        <div className="form">
          <div className="form-box bg-green">
            <h1>Regisztráció</h1>



            {/* FELHASZNÁLÓNÉV */}
            <div className="form-content mt-2">
              <label htmlFor="name" className="form-label">Felhasználó név:</label>
              <input type="text" name="name" id="name" className="form-control" placeholder="pl.: Nagy Sándor" />
            </div>

            
            {/* JELSZÓ */}
            <div className="form-content mt-2">
                <label htmlFor="password" className="form-label">Jelszó:</label>
                <input type="password" name="password" id="password" className="form-control" placeholder="Jelszó" />
            </div>


            {/* JELSZÓ ISMÉTLÉSE */}
            <div className="form-content mt-2">
                <label htmlFor="password-confirmation" className="form-label">Jelszó ismétlése:</label>
                <input type="password" name="password-confirmation" id="password-confirmation" className="form-control" placeholder="Jelszó" />
            </div>


            {/* EMAIL CÍM */}
            <div className="form-content mt-2">
              <label htmlFor="email" className="form-label">Email cím:</label>
              <input type="email" name="email" id="email" className="form-control" placeholder="pl.: pelda@domain.hu" />
            </div>


            {/* SZÜLETÉSI DÁTUM */}
            <div className="form-content mt-2">
              <label htmlFor="date" className="form-label">Születési dátum:</label>
              <input type="date" name="date" id="date" className="form-control" />
            </div>


            {/* SUBMIT GOMB */}
            <button type="submit" onClick={register()} className="btn btn-dark mt-4 w-100">Regisztráció</button>

            <p className="text-center text-light mt-4">Ha már regisztrált akkor <a href="/login" className="login-button">jelentkezzen be!</a></p>
          </div>
        </div>
      </form>
    </>
    )
}

export default Reg;
    
    
    

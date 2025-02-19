import { useNavigate } from "react-router-dom";

function Nav() {
    let navigate = useNavigate()


    return(
        <>
        {/* ############################
        #            NAVBAR            #
        ############################ */}
        <nav className="navbar navbar-expand-lg bg-body-tertiary w-100" data-bs-theme="dark">
            <div className="container-fluid mx-5">
            <a href="/" className="navbar-brand">CurRentCar</a>
            
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll" aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarScroll">
                <ul className="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll">
                <li className="nav-item">
                    <a className="nav-link active" aria-current="page" href="/utiterv">Úti terv</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link active" aria-current="page" href="/osszesauto">Összes autó</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link active" aria-current="page" href="/kovetelmenyek">Követelmények</a>
                </li>
                </ul>
                <div className="me-5 second-nav d-flex justify-content-start">
                    <button className="btn" type="button" id="lang">HU</button>
                    <a href="/register" className="btn">Regisztráció</a>
                </div>
            </div>
            </div>
        </nav>
    </>
    )
}

export default Nav;
    
    
    

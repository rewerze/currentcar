import { useNavigate } from "react-router-dom";
import { useUser } from "../contexts/UserContext";
import profil from "../assets/img/profile.jpg";
import brand from "../assets/img/brand.png"

function Nav() {
    const { user } = useUser();
    const navigate = useNavigate();


    return (
        <>
            {/* ############################
            #            NAVBAR            #
            ############################ */}
            <nav className="navbar navbar-expand-lg bg-dark w-100" data-bs-theme="dark">
                <div className="container-fluid mx-5">
                    <a href="/" className="navbar-brand"><img src={brand} alt="" className="brand-img" /> CurRentCar</a>

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
                        <div className="me-5 second-nav d-flex justify-content-start off-link">
                            <button className="btn text-light" type="button" id="lang">HU</button>
                            {
                                user && user.id ?
                                    <a onClick={() => navigate('/profil')} className="btn text-light">{user.username}<img src={profil} alt="" className='profile profile-nav' /></a>
                                    :
                                    <a onClick={() => navigate('/register')} className="btn">Regisztráció</a>
                            }
                        </div>
                    </div>
                </div>
            </nav>
        </>
    )
}

export default Nav;




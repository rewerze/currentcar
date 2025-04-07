import success from "../assets/img/success.svg";
import fail from "../assets/img/cancel.svg";


function Success() {
    return(
        <>
            <main className="nav-gap">
                <div className="d-flex justify-content-center">
                    <img src={success} className="success-icon" />
                    <img src={fail} className="success-icon" />
                </div>
                <div className="px-5">
                    <p className="text-center mt-5 text-success"><b>[autó brand + model]</b> sikeresen kibérelve a következő napokra:</p>
                    <p className="text-center"><b>2000.01.01 - 2000.01.01 </b></p>
                </div>
                <div className="px-5">
                    <p className="text-center mt-5 text-danger"><b>Bérlés sikertelen!</b> A következő hiba történt:</p>
                    <p className="text-center">hiba üzenet</p>
                </div>
            </main>
        </>
    )
}

export default Success;
function Footer() {
    return(
        <>
    {/* ############################
    #             FOOTER           #
    ############################ */}
      <footer>
            <div className="row">
                <div className="col-3">
                    <p>© 2025 CurRentCar, Inc. <br />
                        All rights reserved.</p>
                </div>
                <div className="col-3">
                    <p><b>Linkek</b></p>
                    <a href="/">Főoldal</a>
                    <a href="/osszesauto">Összes autó</a>
                    <a href="/kapcsolat">Kapcsolat</a>
                    <a href="/rolunk">Rólunk</a>
                </div>
                <div className="col-3">
                    <p><b>Szolgáltatásaink</b></p>
                    <a href="/berles">Autó bérlés</a>
                    <a href="/feladas">Autó feladása</a>
                    <a href="/biztonsag">Biztonság</a>
                    <a href="/faq">Gyakori kérdések</a>
                </div>
                <div className="col-3">
                    <p><b>Vedd fel velünk a kapcsolatot</b></p>
                    <a href="http://facebook.com" target="_blank">Facebook</a>
                    <a href="http://x.com" target="_blank">Twitter</a>
                    <a href="http://instagram.com" target="_blank">Instagram</a>
                    <a href="http://linkedin.com" target="_blank">LinkedIn</a>
                </div>
            </div>
      </footer>
    </>
    )
}

export default Footer;

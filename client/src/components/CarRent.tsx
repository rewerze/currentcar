function CarRent() {
    return(
        <>
            <main className="nav-gap">
                <h1 className="text-center">Autó bérlés folyamata</h1>
                <div className="car-rent">
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">Jelentkezz be!</h2>
                            <p>Fontos számunkra, hogy minden felhasználó biztonságosan érezze magát az oldalon és ahhoz hogy ezt biztosítsuk, mindenkinek kötelező létrhoznia egy saját profilt!</p>
                        </div>
                        <div className="d-flex justify-content-center p-2">
                            <a href="/register" className="btn btn-primary w-100 mt-3">Profil létrehozása</a>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">Módosítsd az adataidat!</h2>
                            <p>Az oldalon meg kell felelnie minden felhasználónak néhány követelménynek. Ezeket a fontos adatokat a profilján belül az "Adatok módosítása" gombra kattintva beállíthatja!</p>
                        </div>
                            <div className="d-flex justify-content-center p-2">
                                <a href="/kovetelmenyek" className="btn btn-primary w-100 mt-3">Követelmények</a>
                            </div>
                    </div>
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">Nézz körbe!</h2>                            
                            <p>Amint minden követelménynek megfelelt és be van jelentkezve, nézzen körbe az "Összes autó" menüpontban és vállasszon magának egy járművet!</p>
                        </div>
                            <div className="d-flex justify-content-center p-2">
                                <a href="/osszesauto" className="btn btn-primary w-100 mt-3">Autóink</a>
                            </div>
                    </div>
                </div>
            </main>
        </>
    )
}

export default CarRent;

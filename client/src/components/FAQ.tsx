function FAQ() {
    return (
        <>
            <main className="nav-gap">
                <h1 className="text-center p-2">
                    Gyakori kérdések
                </h1>

                <div className="mx-5">
                    <details>
                        <summary className="display-5">Fizetés után, mi a teendőm?
                            <hr className="w-100" />
                        </summary>
                        <p>Fizetés után el kell menned a kijelölt depóba (ezt az autó adatlapján megtalálod) és fizetési módszertől függően az ott dolgozó munkatársunknál elintézi a papírmunkákat.</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Milyen dokumentumokra van szükségem a bérléshez?
                            <hr className="w-100" />
                        </summary>
                        <p>Ahhoz, hogy autót bérelhessen nálunk, szükséges, hogy legyen jogosítványa és meglegyen az elérhetősége. Minden egyéb követelényt <a href="/kovetelmenyek">itt</a> tud megtekinteni!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Hogyan történik a bérlés folyamata?
                            <hr className="w-100" />
                        </summary>
                        <p>A bérléshez elsősorban be kell jelentkeznie, majd a szükséges dokumentumok adja meg a profilján és ezután már szabadon bérelhet bármilyen autót amit talál nálunk!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Mi van, ha a bérlés ideje alatt autótörés történik?
                            <hr className="w-100" />
                        </summary>
                        <p>A bérlő köteles kifizetni minden kárt ami éri a járművet míg az Ő használatában áll.</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Milyen módon tudom fizetni a bérlést?
                            <hr className="w-100" />
                        </summary>
                        <p>Online és helyszínen egyaránt ki tudod fizetni az autó árát kézpénzben vagy kártyával!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Mik a bérlés időtartama és költségei?
                            <hr className="w-100" />
                        </summary>
                        <p>Alapvetőn a bérlés napokra van mérve, van egy napi ár ki írva, nagyobban meg 1heti ár.</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Mi történik, ha késlekedem a visszavitelkor?
                            <hr className="w-100" />
                        </summary>
                        <p>Amennyivel az emberünk túllépi a vissza hozási időt óránként az óránkénti ár 2x-esét kell fizetni!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Visszavihetem az autót másik depóba, mint ahol átvettem?
                            <hr className="w-100" />
                        </summary>
                        <p>Nem. Fontos számunkra, hogy ha az eredeti tulajdonos szeretné vissza az autóját, akkor ne egy távolabbi helyre kelljen elutaznia érte.</p>
                    </details>
                </div>
            </main>
        </>
    )
}

export default FAQ;

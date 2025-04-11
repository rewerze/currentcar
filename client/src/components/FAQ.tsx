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
                        <p>Fizetés után el kell menned a kijelölt depóba (ezt az autó adatlapján megtalálod) és fizetési módszertől függően az ott dolgozó munkatársunk elintézi a papírmunkákat.</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Milyen dokumentumokra van szükségem a bérléshez?
                            <hr className="w-100" />
                        </summary>
                        <p>Ahhoz, hogy autót bérelhessen nálunk, szükséges, hogy legyen jogosítványa és meglegyen az elérhetősége. Minden egyéb követelményt <a href="/kovetelmenyek">itt</a> tud megtekinteni!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Hogyan történik a bérlés folyamata?
                            <hr className="w-100" />
                        </summary>
                        <p>A bérléshez elsősorban be kell jelentkeznie, majd a szükséges dokumentumokat megadni a profilján és ezután már szabadon bérelhet bármilyen autót amit talál nálunk!</p>
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
                        <p>Online és helyszínen egyaránt ki tudod fizetni az autó árát készpénzben vagy kártyával!</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Mik a bérlés időtartamai és költségei?
                            <hr className="w-100" />
                        </summary>
                        <p>A bérlés lehetséges időtartamát a bérbeadó adja meg, (ezt megtalálja az autó adatlapján). Eddig az időpontig bármeddig kibérelhető az autó, aminek elsősorban az alapárát kell kifizetni, majd ezután felszámolunk egy óradíjat, majd egy napidíjat, ami autótól függően szintén eltér.</p>
                    </details>
                </div>
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Mi történik, ha késlekedem a visszavitelkor?
                            <hr className="w-100" />
                        </summary>
                        <p>Amennyiben az bérlő túllépi a vissza hozási időt óránként az óránkénti ár 2x-esét kell fizetni!</p>
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
                <div className="mx-5 mt-5">
                    <details>
                        <summary className="display-5">Hány százalékát kapom meg a bérbeadott autómért?
                            <hr className="w-100" />
                        </summary>
                        <p>Az összeget az autó bérlés visszahozásáig tároljuk, majd a végösszeg 70%-át átutaljuk vagy készpénzben átveheti.</p>
                    </details>
                </div>
            </main>
        </>
    )
}

export default FAQ;

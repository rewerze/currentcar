function Requirements() {
    return(
        <>
            <main className="nav-gap">
                <h1 className="text-center">Követelmények</h1>
                <p className="text-center"><b>Minden adatot a profilodban, az "Adatok módosítása" menü pontban kitölthető / módosítható! <a href="/profil/modositas">Menjünk oda.</a></b></p>


                {/* A NEGYEDIK OSZLOP AZ JELÖLHETNÉ HOGY A FELHASZNÁLÓ MÁR MEGADTA-E AZ ADATÁT VAGY NEM. */}
                <table className="req-table mx-auto">
                    <tr>
                        <th className="w-25 p-1">Adat</th>
                        <th className="w-50 p-1">Leírás</th>
                        <th className="w-25 p-1">Prioritás</th>
                    </tr>
                    <tr>
                        <td className="p-1">Érvényes jogosítvány</td>
                        <td className="p-1">Szeretnénk biztosítani az utakon közlekedőknek is, a biztonságos vezetés élményét.</td>
                        <td className="p-1">NAGYON FONTOS</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">Elérhetőség</td>
                        <td className="p-1"><b>E-mail cím</b> és <b>telefonszám</b> minden esetben elérhető kell, hogy legyen számunkra.</td>
                        <td className="p-1">NAGYON FONTOS</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">IBAN</td>
                        <td className="p-1">IBAN száma a pénz utalásához szükséges, ha esetleg Ön töltött fel autót.</td>
                        <td className="p-1">TERVEZD BE</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">Életkor</td>
                        <td className="p-1">Az életkorodnak, muszáj betöltenie a 17-et!</td>
                        <td className="p-1">NAGYON FONTOS</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                </table>


                {/* ELLENŐRZÉS HOGY MEGVANNAK E ADVA AZ ADATOK MEGFELEL E VAGY NEM A FELHASZNÁLÓ MÁR */}
                <p className="text-center text-success mt-3"><b>Ön megfelel minden követelménynek, hogy kölcsönözhessen nálunk!</b></p>
                <p className="text-center text-danger mt-3"><b>Sajnos Ön még felel meg, hogy kölcsönözhessen nálunk!</b></p>
            </main>
        </>
    )
}

export default Requirements;

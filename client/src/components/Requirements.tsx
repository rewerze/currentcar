function Requirements() {
    return(
        <>
            <main className="nav-gap">
                <h1 className="text-center">Követelmények</h1>
                <table className="w-50 mx-auto">
                    <tr>
                        <th className="w-25 p-1">Adat</th>
                        <th className="w-50 p-1">Leírás</th>
                        <th className="w-25 p-1">Feltöltés</th>
                    </tr>
                    <tr>
                        <td className="p-1">Érvényes jogosítvány</td>
                        <td className="p-1">Szeretnénk biztosítani az utakon közlekedőknek is, a biztonságos vezetés élményét.</td>
                        <td className="p-1"><a href="/profil/modositas">Adatok módosítása</a></td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">Elérhetőség</td>
                        <td className="p-1"><b>E-mail cím</b> és <b>telefonszám</b> minden esetben elérhető kell hogy legyen számunkra.</td>
                        <td className="p-1"><a href="/profil/modositas">Adatok módosítása</a></td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>

                    </tr>
                </table>
            </main>
        </>
    )
}

export default Requirements;

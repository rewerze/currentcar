function PriceTable() {
    return(
        <>
            <main className="nav-gap">
                <div className="bg-dark price-page text-black">
                    <h1 className="text-center text-light">Jármű ajánlott árazás tábla</h1>
                    <div className="table-responsive">
                        <table className="table price-table mx-auto">
                            <thead>
                                <th></th>
                                <th className="text-danger">Gyenge</th>
                                <th className="text-warning">Megfelelő</th>
                                <th className="text-warning">Jó</th>
                                <th className="text-success">Kiválló</th>
                                <th className="text-success">Új</th>
                            </thead>
                            <tr>
                                <th>Alap ár:</th>
                                <td>4000 HUF</td>
                                <td>7000 HUF</td>
                                <td>13000 HUF</td>
                                <td>20000 HUF</td>
                                <td>30000 HUF</td>
                            </tr>
                            <tr>
                                <th>Óra ár:</th>
                                <td>300 HUF</td>
                                <td>700 HUF</td>
                                <td>1000 HUF</td>
                                <td>1400 HUF</td>
                                <td>1800 HUF</td>
                            </tr>
                            <tr>
                                <th>Napi ár:</th>
                                <td>500 HUF</td>
                                <td>1000 HUF</td>
                                <td>2000 HUF</td>
                                <td>3000 HUF</td>
                                <td>4000 HUF</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </main>
        </>
    )
}

export default PriceTable;
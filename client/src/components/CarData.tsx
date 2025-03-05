import car from "../assets/img/nepszeru_auto.png";

function CarData() {
    return(
        <>
        <main className="nav-gap">
            <div className="row">
                <div className="col-lg-5">
                    <img src={car} alt="" className="w-100" />
                </div>
                <div className="col-lg-7">
                    <h2 className="text-center display-5">Tulajdonságai</h2>
                    <div className="d-flex justify-content-center">
                        <table className="table adatlap-table">
                            <tr>
                                <th>Márka:</th>
                                <td>márka</td>
                            </tr>
                            <tr>
                                <th>Modell:</th>
                                <td>model</td>
                            </tr>
                            <tr>
                                <th>Állapot:</th>
                                <td>jó</td>
                            </tr>
                            <tr>
                                <th>Évjárat:</th>
                                <td>év</td>
                            </tr>
                            <tr>
                                <th>Autó típusa:</th>
                                <td>tipus1</td>
                            </tr>
                            <tr>
                                <th>Üzemanyag típusa:</th>
                                <td>tipus2</td>
                            </tr>
                            <tr>
                                <th>Sebességváltó típusa:</th>
                                <td>tipus3</td>
                            </tr>
                            <tr>
                                <th>Ülések száma:</th>
                                <td>ülés</td>
                            </tr>
                            <tr>
                                <th>Ajtók száma:</th>
                                <td>ajtó</td>
                            </tr>
                            <tr>
                                <th>Rendszám:</th>
                                <td>szam</td>
                            </tr>
                            <tr>
                                <th>Leírás:</th>
                                <td>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</td>
                            </tr>
                            <tr>
                                <th>Ár / óra:</th>
                                <td>10 HUF</td>
                            </tr>
                            <tr>
                                <th>Ár / nap:</th>
                                <td>100 HUF</td>
                            </tr>
                        </table>

                    </div>
                    <div className="d-flex justify-content-center adatlap-table-alatt">
                        <button className="btn btn-success">Vásárlás</button>
                    </div>
                </div>
            </div>
        </main>
        </>
    )


}

export default CarData;
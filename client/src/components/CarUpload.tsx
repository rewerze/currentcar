function CarUpload() {
    return(
        <>
            {/* KOCSI FELTÖLTÉS */}
            
            <main className="nav-gap">
                <div className="form">
                    <div className="form-box bg-dark">
                        <h1 className="text-center">Autó feltöltés</h1>


                        <div className="d-flex justify-content-center gap-3 upload-form">
                            <input type="text" placeholder="Márka" className="form-control"/>
                            <input type="text" placeholder="Modell" className="form-control"/>
                        </div>

                        <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                            <select name="condition" id="conidion" className="form-select w-75">
                                <option value="-">Állapot</option>
                                <option value="1">rossz</option>
                                <option value="2">jo</option>
                            </select>
                            <input type="text" placeholder="Évjárat" className="form-control w-25"/>
                        </div>

                        <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                            <select name="car_type" id="conidion" className="form-select w-25">
                                <option value="-">Autó típusa</option>
                                <option value="1">rossz</option>
                                <option value="2">jo</option>
                            </select>
                            <select name="fuel_type" id="conidion" className="form-select w-25">
                                <option value="-">Üzemanyag</option>
                                <option value="1">rossz</option>
                                <option value="2">jo</option>
                            </select>
                            <select name="transmission_type" id="conidion" className="form-select w-25">
                                <option value="-">Sebességváltó</option>
                                <option value="1">rossz</option>
                                <option value="2">jo</option>
                            </select>
                            <input type="text" placeholder="Rendszám" className="form-control w-25"/>
                        </div>

                        <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                            <input type="text" placeholder="Ülések száma" className="form-control w-25"/>
                            <input type="text" placeholder="Ajtók száma" className="form-control w-25"/>
                            <input type="text" placeholder="Ár / óra" className="form-control w-25"/>
                            <input type="text" placeholder="Ár / nap" className="form-control w-25"/>
                        </div>

                        <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                            <textarea name="description" id="description" placeholder="Leírás az autóhoz!" className="form-control" rows={10}></textarea>
                        </div>

                        <button className="btn btn-success w-100 mt-5 p-2">Autó felöltése</button>
                    </div>
                </div>
            </main>
        </>
    )
}

export default CarUpload;
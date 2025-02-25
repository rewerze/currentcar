function AllCar() {
    return(
    <>
    <main className="nav-gap">
        <h1 className="text-center">Összes autónk</h1>

        <form action="/osszesauto">
        <div className="search">

            {/* KERESÉS */}
            <div className="d-flex justify-content-center mb-3">
                <div className="form-floating w-50">
                    <input type="text" id="search-box" className="form-control" placeholder="Keresés"/>
                    <label htmlFor="search-box">Keresés</label>
                </div>
            </div>

            {/* SZŰRÉS */}
            <div className="d-flex justify-content-center gap-2 w-100">
                <div className="w-25">
                    <label htmlFor="search-box">Autó márkája</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
            </div>
        </div>
        </form>
    </main>
    </>
    )
}

export default AllCar;
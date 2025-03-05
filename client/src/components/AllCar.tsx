import car from "../assets/img/nepszeru_auto.png";


function AllCar() {
    return(
    <>
    <main className="nav-gap">
        <h1 className="text-center">Összes autó</h1>

        <form action="/osszesauto">
        <div className="search">

            {/* KERESÉS */}
            <div className="d-flex justify-content-center mb-3 mx-auto">
                <input type="text" id="search-box" className="form-control w-50" placeholder="Keresés"/>
            </div>

            {/* SZŰRÉS */}
            <div className="filter d-flex justify-content-center gap-2 w-100 mx-auto">
                <div className="w-25">
                    <label htmlFor="search-box">Autó márkája</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
                <div className="w-25">
                    <label htmlFor="search-box">Autó típusa</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
                <div className="w-25">
                    <label htmlFor="search-box">Autó minősége</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
            </div>

            <div className="filter d-flex justify-content-center gap-2 w-100 mt-2 mx-auto">
                <div className="w-25">
                    <label htmlFor="search-box">Sebességváltó típusa</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
                <div className="w-25">
                    <label htmlFor="search-box">Üzemanyag típusa</label>
                    <select name="car-type" id="car-type" className="form-select">
                        <option>Összes</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
                <div className="w-25">
                    <label htmlFor="search-box">Autó évjárata</label>
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

        <div className="cars mt-5">
            <div className="car-box bg-dark">
                <a href="/adatlap" className="off-link">
                <div>
                    <p className="text-center">
                        <img src={car} alt="car" className="car-image"/>
                    </p>
                </div>
                <div className="text-center">
                    <h3>Car name</h3>
                    <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                </div>
                </a>
            </div>
        </div>

    </main>
    </>
    )
}

export default AllCar;
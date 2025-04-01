import cancel_icon from "../assets/img/cancel.svg";
import save_icon from "../assets/img/save.svg";

function EditCar() {
  return (
    <>
      <main className="nav-gap">
        <form className="form">
          <div className="form-box bg-dark">
            <h1>KOCSI NÉV adatai módosítása</h1>

            {/* Ár */}
            <div className="car-edit">

                <div className="w-50">
                    <label htmlFor="hourly_price" className="form-label">
                    Óra ár
                    </label>
                    <input type="text" name="hourly_price" id="hourly_price" className="form-control" placeholder="Óra ár"/>
                </div>

                <div className="w-50">
                    <label htmlFor="daily_price" className="form-label">
                    Napi ár
                    </label>
                    <input type="text" name="daily_price" id="daily_price" className="form-control" placeholder="Napi ár" />
                </div>

            </div>
            

            {/* MEDDIG + EXRTA */}
            <div className="car-edit mt-1">
            <div className="w-50">
                    <label htmlFor="to" className="form-label">
                    Meddig?
                    </label>
                    <input type="date" name="to" id="to" className="form-control" />
                </div>

                <div className="w-50">
                    <label htmlFor="extras" className="form-label">
                    Extrák
                    </label>
                    <input type="text" name="extras" id="extras" className="form-control" placeholder="pl: baba ülés, sötétítő, stb.." />
                </div>
            </div>

            {/* LEÍRÁS */}
            <div className="car-edit mt-1">
                <div className="w-100">
                    <label htmlFor="description">Leírás</label>
                    <textarea name="description" id="description" className="form-control" rows={3}>Leírás</textarea>
                </div>
            </div>







            {/* GOMBOK */}
            <div className="d-flex justify-content-center mt-5 gap-3 icon-left edit-buttons">
              <button type="submit" className="btn btn-success w-50">
                <span>
                  <img src={save_icon} className="icon icon-small" />
                </span>
                <span>Adatok mentése</span>
              </button>
              <a href="./" className="btn btn-danger w-50">
                <span>
                  <img src={cancel_icon} className="icon icon-small" />
                </span>
                <span>Elvetés</span>
              </a>
            </div>
          </div>
        </form>
      </main>
    </>
  );
}

export default EditCar;

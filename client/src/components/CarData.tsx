import { useEffect, useState } from "react";
import carImage from "../assets/img/nepszeru_auto.png";
import { useParams } from "react-router-dom";
import { CarInfo } from "./interfaces/Car";
import { useLanguage } from "@/contexts/LanguageContext";
import { toast } from "sonner";
import  profile  from "../assets/img/profile.jpg";
import star from "../assets/img/filled-star.svg";

function CarData() {
  const { t, loadNamespace, language, loadedNamespaces } = useLanguage();
  const { id } = useParams<{ id: string }>();
  const [car, setCarInfo] = useState<CarInfo | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!loadedNamespaces.includes("CarDetail")) {
      loadNamespace("CarDetail");
    }
  }, [loadedNamespaces, loadNamespace]);

  useEffect(() => {
    const fetchCarData = async () => {
      const response = await fetch(`http://localhost:3000/api/car?id=${id}`, {
        credentials: "include",
      });

      if (!response.ok) {
        throw new Error(`Failed to fetch car data: ${response.status}`);
      }

      const data = await response.json();
      setCarInfo(data);
      setError(null);
      setIsLoading(false);
    };

    fetchCarData();
  }, [id]);

  if (!car) {
    return <></>;
  }

  function onPurchase(): void {
    console.log("asd")
    toast(t("purchaseSuccess", "CarDetail"))
  }

  return (
    <>
      <main className="nav-gap">
        <div className="row">
          <div className="col-lg-5">
          <div id="carouselExampleIndicators" className="carousel slide">
            <div className="carousel-indicators">
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" className="active" aria-current="true" aria-label="Slide 1"></button>
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div className="carousel-inner">
              <div className="carousel-item active">
                <img
                src={carImage}
                alt={`${car.car_brand} ${car.car_model}`}
                className="d-block w-100"
              />
            </div>
              <div className="carousel-item active">
                <img
                src={carImage}
                alt={`${car.car_brand} ${car.car_model}`}
                className="d-block w-100"
              />
            </div>
              <div className="carousel-item active">
                <img
                src={carImage}
                alt={`${car.car_brand} ${car.car_model}`}
                className="d-block w-100"
              />
            </div>
            <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
              <span className="carousel-control-prev-icon" aria-hidden="true"></span>
              <span className="visually-hidden">Előző</span>
            </button>
            <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
              <span className="carousel-control-next-icon" aria-hidden="true"></span>
              <span className="visually-hidden">Következő</span>
            </button>
          </div>
          </div>
          <div className="col-lg-7">
            <h2 className="text-center display-5">
              {t("properties", "CarDetail")}
            </h2>
            <div className="d-flex justify-content-center">
              <table className="table adatlap-table">
                <tbody>
                  <tr>
                    <th>{t("carBrand", "CarDetail")}:</th>
                    <td>{car.car_brand}</td>
                  </tr>
                  <tr>
                    <th>{t("carModel", "CarDetail")}:</th>
                    <td>{car.car_model}</td>
                  </tr>
                  <tr>
                    <th>{t("condition", "CarDetail")}:</th>
                    <td>{t(car.car_condition, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("year", "CarDetail")}:</th>
                    <td>{car.car_year}</td>
                  </tr>
                  <tr>
                    <th>{t("carType", "CarDetail")}:</th>
                    <td>{t(car.car_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("fuelType", "CarDetail")}:</th>
                    <td>{t(car.fuel_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("transmissionType", "CarDetail")}:</th>
                    <td>{t(car.transmission_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("seats", "CarDetail")}:</th>
                    <td>{car.seats}</td>
                  </tr>
                  <tr>
                    <th>{t("doors", "CarDetail")}:</th>
                    <td>{car.number_of_doors}</td>
                  </tr>
                  <tr>
                    <th>{t("regNumber", "CarDetail")}:</th>
                    <td>{car.car_regnumber}</td>
                  </tr>
                  <tr>
                    <th>{t("description", "CarDetail")}:</th>
                    <td>{car.car_description}</td>
                  </tr>
                  <tr>
                    <th>{t("pricePerHour", "CarDetail")}:</th>
                    <td>
                      {car.price_per_hour} {language === "hu" ? "HUF" : "EUR"}
                    </td>
                  </tr>
                  <tr>
                    <th>{t("pricePerDay", "CarDetail")}:</th>
                    <td>
                      {car.price_per_day} {language === "hu" ? "HUF" : "EUR"}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div className="d-flex justify-content-center adatlap-table-alatt">
              <button className="btn btn-success" onClick={onPurchase}>
                {t("purchase", "CarDetail")}
              </button>
            </div>
          </div>
        </div>


        <div className="car-comment mt-5 w-50 mx-auto">
            <h2 className="text-center">Vélemények</h2>
            <hr />

            <form action="/adatlap">
            <div className="my-2 mt-5">
              <div className="row">
                <div className="col-md comment-header">
                <a href="/profil">
                <img src={profile} alt="" className="profile-sm" />
                </a>
                <span className="star-range"><input type="range" name="star" id="star" min={1} max={5} defaultValue={3}/></span> {/* IDEIGLENES MEGOLDÁS */}
                </div>
                <div className="col-md">
                  <select name="comment_category" id="comment_category" className="form-select car-comment-select">
                    <option value="">értékelés típus</option>
                    <option value="">értékelés típus</option>
                    <option value="">értékelés típus</option>
                  </select>
                </div>
              </div>

            </div>
            <textarea name="comment" id="comment" className="w-100 form-control" rows={3} placeholder="Írd meg te is a véleményed!"></textarea>
            <button className="btn btn-primary mt-2 py-2 w-25">Küldés</button>
            </form>

            <div className="comment-section">
                <div className="comment-box bg-light">
                    <div className="comment-content">
                        <img src={profile} alt="" className='profile' />
                        <div className="comment-text">
                            <h5><span><b>{t('name', 'MainPage')}</b></span><br />vélemény típus: 5/3</h5>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
      </main>
    </>
  );
}

export default CarData;

import { useEffect, useState } from "react";
import carImage from "../assets/img/nepszeru_auto.png";
import { useParams } from "react-router-dom";
import { CarInfo } from "./interfaces/Car";
import { useLanguage } from "@/contexts/LanguageContext";
import { toast } from "sonner";
import  profile  from "../assets/img/profile.jpg";

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
            <img
              src={carImage}
              alt={`${car.car_brand} ${car.car_model}`}
              className="w-100"
            />
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

            <div className="my-2 mt-5">
              <div className="row">
                <div className="col-md">
                <a href="/profil">
                <img src={profile} alt="" className="profile-sm" />
                </a>
                <span>★★★★★</span> {/* IDEIGLENES MEGOLDÁS */}
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

            <div className="comment-section">
                <div className="comment-box bg-light">
                    <div className="comment-content">
                        <img src={profile} alt="" className='profile' />
                        <div className="comment-text">
                            <h5><span><b>{t('name', 'MainPage')}</b></span> <span>★★★★★</span> {/* IDEIGLENES MEGOLDÁS */}<br />vélemény típus</h5>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
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

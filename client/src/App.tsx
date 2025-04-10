import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/css/elements.css";
import "./assets/css/colors.css";
import "./assets/css/mobile.css";
import depo from "./assets/img/miert_a_currentcar.png";
import nepszeru from "./assets/img/nepszeru_auto.png";
import profil from "./assets/img/profile.jpg";
import { useLanguage } from "./contexts/LanguageContext";
import { SetStateAction, useEffect, useState } from "react";
import axios from "axios";
import { buildApiUrl } from "./lib/utils";
import { CarInfo } from "./components/interfaces/Car";
import { Review } from "./components/interfaces/Review";

function App() {
  const { t, loadedNamespaces, loadNamespace } = useLanguage();
  const [reviews, setReviews] = useState<Review[]>([]);
  const [popularCars, setPopularCars] = useState<CarInfo[]>([]);
  const [averagePrice, setAveragePrice] = useState<number>();
  const [depoLocations, setDepoLocations] = useState<
    { location_id: number; location: string; postcode: number }[]
  >([]);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [filteredDepoLocations, setFilteredDepoLocations] = useState<
    { location_id: number; location: string; postcode: number }[]
  >([]);
  const [closestDepo, setClosestDepo] = useState<{
    location_id: number;
    location: string;
    postcode: number;
  } | null>(null);

  useEffect(() => {
    if (!loadedNamespaces.includes("MainPage")) loadNamespace("MainPage");
  }, [loadedNamespaces, loadNamespace]);

  useEffect(() => {
    const fetchCarData = async () => {
      try {
        const response = await fetch(buildApiUrl(`/getDepos`), {
          credentials: "include",
        });

        if (!response.ok) {
          throw new Error(`Failed to fetch depo data: ${response.status}`);
        }

        const data = await response.json();
        setDepoLocations(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchCarData();
  }, []);

  useEffect(() => {
    const fetchRandomReviews = async () => {
      try {
        const response = await axios.get(buildApiUrl("/randomReviews"), {
          withCredentials: true,
        });

        setReviews(response.data);
      } catch (err) {
        console.error("Failed to fetch random reviews", err);
      }
    };

    const fetchPopularCars = async () => {
      try {
        const response = await axios.get(buildApiUrl("/popularCars"), {
          withCredentials: true,
        });

        setPopularCars(response.data.mostPopularCars);
        setAveragePrice(response.data.averagePriceOfAllCars);
      } catch (err) {
        console.error("Failed to fetch popular cars", err);
      }
    };

    fetchRandomReviews();
    fetchPopularCars();
  }, []);

  const calculatePostcodeDistance = (
    postcode1: number,
    postcode2: number
  ): number => {
    return Math.abs(postcode1 - postcode2);
  };

  useEffect(() => {
    if (searchTerm.trim() === "") {
      setFilteredDepoLocations(depoLocations);
      setClosestDepo(null);
      return;
    }

    const searchValue = searchTerm.trim();

    const searchNumberValue = parseInt(searchValue, 10);
    const isValidNumber = !isNaN(searchNumberValue);

    const exactMatches = depoLocations.filter((depo) => {
      const postcodeStr =
        depo.postcode !== undefined && depo.postcode !== null
          ? depo.postcode.toString()
          : "";

      return postcodeStr.includes(searchValue);
    });

    if (exactMatches.length > 0) {
      setFilteredDepoLocations(exactMatches);
      setClosestDepo(null);
    } else if (isValidNumber) {
      let closest: SetStateAction<{
        location_id: number;
        location: string;
        postcode: number;
      } | null> = null;
      let minDistance = Number.MAX_SAFE_INTEGER;

      depoLocations.forEach((depo) => {
        if (depo.postcode !== undefined && depo.postcode !== null) {
          const distance = calculatePostcodeDistance(
            depo.postcode,
            searchNumberValue
          );
          if (distance < minDistance) {
            minDistance = distance;
            closest = depo;
          }
        }
      });

      if (closest) {
        setClosestDepo(closest);
        setFilteredDepoLocations([
          closest,
          ...depoLocations.filter(
            (d) =>
              d.location_id !==
              (
                closest as {
                  location_id: number;
                  location: string;
                  postcode: number;
                }
              )?.location_id
          ),
        ]);
      } else {
        setFilteredDepoLocations([]);
        setClosestDepo(null);
      }
    } else {
      setFilteredDepoLocations([]);
      setClosestDepo(null);
    }
  }, [searchTerm, depoLocations]);

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
  };

  return (
    <>
      {/* ############################
    #           GOOGLE MAP         #
    ############################ */}
      <main>
        <section id="kezdes">
          <div className="terkep">
            <div className="row">
              <div className="col-lg mt-5">
                <p>{t("findNearestDepot", "MainPage")}</p>
                <input
                  type="text"
                  className="form-control"
                  placeholder={t("currentPosition", "MainPage")}
                  id="hely"
                  value={searchTerm}
                  onChange={handleSearchChange}
                />
                <small className="text-muted mt-1 d-block">
                  {t("searchByPostcode", "MainPage")}
                </small>
              </div>
              <div className="col-lg mt-3">
                <table className="big-table w-50">
                  <thead>
                    <tr>
                      <th>{t("depoLocations", "MainPage")}</th>
                    </tr>
                  </thead>
                  <tbody>
                    {depoLocations.length > 0 ? (
                      filteredDepoLocations.length > 0 ? (
                        filteredDepoLocations.map((depo) => (
                          <tr key={depo.location_id}>
                            <td>{depo.location}</td>
                          </tr>
                        ))
                      ) : (
                        <tr>
                          <td colSpan={2} className="text-center">
                            No matching depots found
                          </td>
                        </tr>
                      )
                    ) : (
                      <tr>
                        <td colSpan={2} className="text-center">
                          Loading depot locations...
                        </td>
                      </tr>
                    )}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </section>

        {/* ############################
    #       MIÉRT A CURRENTCAR     #
    ############################ */}
        <section id="miert_a_currentcar" className="bg-dark shadow">
          <h1 className="text-light">{t("whyTheCurrentCar", "MainPage")}</h1>
          <div className="row center">
            <div className="col-lg-6">
              <p className="text-light">{t("introText", "MainPage")}</p>

              <h2>{t("whyChooseUs", "MainPage")}</h2>

              <p>{t("easyFastProcess", "MainPage")}</p>
              <p>{t("secureRenting", "MainPage")}</p>
              <p>{t("wideCarSelection", "MainPage")}</p>
              <p>{t("flexiblePricing", "MainPage")}</p>
              <p>{t("communityReviews", "MainPage")}</p>
            </div>
            <div className="col-lg-6 miert-img">
              <img src={depo} alt="" />
            </div>
          </div>
        </section>

        {/* ############################
    #        NÉPSZERŰ AUTÓINK     #
    ############################ */}
        <section id="nepszeru">
          <h1 className="right">{t("mostPopularCars", "MainPage")}</h1>
          <div className="row d-flex justify-content-center">
            {Array.isArray(popularCars) &&
              popularCars.map((car) => (
                <div className="col col-md-4 autok bg-dark" key={car.car_id}>
                  <a href={`/adatlap/` + car.car_id} className="off-link">
                    <p>
                      <img
                        src={
                          car.car_id
                            ? `${
                                import.meta.env.PROD
                                  ? "/api"
                                  : "http://localhost:3000/api"
                              }/getCarImage?car_id=${car.car_id}`
                            : nepszeru
                        }
                        onError={(e) => {
                          (e.target as HTMLImageElement).src = nepszeru;
                        }}
                        alt=""
                      />
                    </p>
                    <hr />
                    <h2>
                      {car.car_brand} {car.car_model}
                    </h2>
                    <p>{t("clickForMoreInfo", "MainPage")}</p>
                  </a>
                </div>
              ))}
          </div>
        </section>

        {/* ############################
    #           UTAZÁSI ÁR        #
    ############################ */}
        <section id="ar" className="bg-dark shadow">
          <h1 className="text-light">{t("carPrices", "MainPage")}</h1>
          <div className="row">
            <div className="col-lg-8">
              <p className="text-light">
                {t("pricingTransparent", "MainPage")}
              </p>
              <p className="text-light">{t("pricingUpfront", "MainPage")}</p>
              <p className="text-light">{t("pricingVariety", "MainPage")}</p>
              <p className="text-light">{t("pricingDiscount", "MainPage")}</p>
            </div>
            <div className="col-lg-4">
              <p className="penz text-blue">
                {Intl.NumberFormat("en-US").format(
                  Math.round(averagePrice || 0)
                )}{" "}
                HUF
              </p>
            </div>
          </div>
        </section>

        {/* ############################
    #           VÉLEMÉNYEK         #
    ############################ */}
        <section id="velemenyek">
          <h1 className="right">{t("reviews", "MainPage")}</h1>
          <div className="comments">
            {reviews.map((review) => (
              <div className="comment-box bg-light" key={review.review_id}>
                <div className="comment-content">
                  <img src={profil} alt="" className="profile" />
                  <div className="comment-text">
                    <h5>{review.user_name}</h5>
                    <div className="rating">
                      {[...Array(5)].map((_, i) => (
                        <span key={i} className="star">
                          {i < review.review_rating ? (
                            <i className="fas fa-star text-warning"></i>
                          ) : (
                            <i className="far fa-star text-warning"></i>
                          )}
                        </span>
                      ))}
                    </div>
                    <p>{review.review_message}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </section>
      </main>
    </>
  );
}

export default App;

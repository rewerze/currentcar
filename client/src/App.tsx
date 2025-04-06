import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/css/elements.css";
import "./assets/css/colors.css";
import "./assets/css/mobile.css";
import depo from "./assets/img/miert_a_currentcar.png";
import nepszeru from "./assets/img/nepszeru_auto.png";
import profil from "./assets/img/profile.jpg";
import { useLanguage } from "./contexts/LanguageContext";
import { useEffect, useState } from "react";
import axios from "axios";
import { buildApiUrl } from "./lib/utils";
import { CarInfo } from "./components/interfaces/Car";
import { Review } from "./components/interfaces/Review";

function App() {
  const { t, loadedNamespaces, loadNamespace } = useLanguage();
  const [reviews, setReviews] = useState<Review[]>([]);
  const [popularCars, setPopularCars] = useState<CarInfo[]>([]);

  useEffect(() => {
    if (!loadedNamespaces.includes("MainPage")) loadNamespace("MainPage");
  }, [loadedNamespaces, loadNamespace]);

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

        setPopularCars(response.data);
      } catch (err) {
        console.error("Failed to fetch popular cars", err);
      }
    };

    fetchRandomReviews();
    fetchPopularCars();
  }, []);
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
                <p>
                  {t('findNearestDepot', 'MainPage')}
                </p>
                <input
                  type="text"
                  className="form-control"
                  placeholder={t('currentPosition', 'MainPage')}
                  id="hely"
                />
              </div>
              <div className="col-lg mt-3">
                <iframe
                  width="600"
                  height="450"
                  style={{ border: 0 }}
                  loading="lazy"
                  allowFullScreen
                  referrerPolicy="no-referrer-when-downgrade"
                  src="https://www.google.com/maps/embed/v1/place?key=AIzaSyAN5SYLwcDXzm06exMmnIbr4pXsA4Z8ohc
    &q=Space+Needle,Seattle+WA"
                ></iframe>
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
              <p className="text-light">
                {t("introText", "MainPage")}
              </p>

              <h2>{t("whyChooseUs", "MainPage")}</h2>

              <p>
                {t("easyFastProcess", "MainPage")}
              </p>
              <p>
                {t("secureRenting", "MainPage")}
              </p>
              <p>
                {t("wideCarSelection", "MainPage")}
              </p>
              <p>
                {t("flexiblePricing", "MainPage")}
              </p>
              <p>
                {t("communityReviews", "MainPage")}
              </p>
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
            {Array.isArray(popularCars) && popularCars.map((car) => (
              <div className="col col-md-4 autok bg-dark" key={car.car_id}>
                <a href={`/adatlap/` + car.car_id} className="off-link">
                  <p>
                    <img src={car.car_id ? `${import.meta.env.PROD ? "/api" : "http://localhost:3000/api"}/getCarImage?car_id=${car.car_id}` : nepszeru} onError={(e) => {
                      (e.target as HTMLImageElement).src = nepszeru;
                    }} alt="" />
                  </p>
                  <hr />
                  <h2>{car.car_brand} {car.car_model}</h2>
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
                A CurRentCar-nál nálunk az árazás átlátható és rugalmas – pont, ahogy neked kényelmes.
              </p>
              <p className="text-light">🧾 A bérlési díjakat mindig előre látod – nincs apró betűs rész vagy váratlan kiadás.</p>
              <p className="text-light">🔄 Minden jármű tulajdonosa saját árakat állíthat be, így a kínálat sokszínű, te pedig biztosan találsz a pénztárcádhoz illő ajánlatot – akár egy napra, hétvégére vagy hosszabb időre bérelnél.</p>
              <p className="text-light">💰 Több napos bérlésre extra kedvezmények járhatnak – minél hosszabb ideig használod az autót, annál jobban jársz.</p>
              <p className="text-light">🛡️ Egyes autók esetében letét szükséges lehet, amit a bérlés végén visszakapsz, ha minden rendben zajlott. A bérlési folyamat során minden fontos információt világosan megjelenítünk.</p>
            </div>
            <div className="col-lg-4">
              <p className="penz text-blue">{t("priceAmount", "MainPage")}</p>
            </div>
          </div>
        </section>

        {/* ############################
    #           VÉLEMÉNYEK         #
    ############################ */}
        <section id="velemenyek">
          <h1 className="right">{t("reviews", "MainPage")}</h1>
          <div className="comments">
            {
              reviews.map((review) => (
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
              ))
            }
          </div>
        </section>
      </main>
    </>
  );
}

export default App;

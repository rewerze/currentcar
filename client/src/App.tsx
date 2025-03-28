import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/css/elements.css";
import "./assets/css/colors.css";
import "./assets/css/mobile.css";
import map from "./assets/img/googlemap.png";
import depo from "./assets/img/miert_a_currentcar.png";
import nepszeru from "./assets/img/nepszeru_auto.png";
import profil from "./assets/img/profile.jpg";
import { useLanguage } from "./contexts/LanguageContext";
import { useEffect } from "react";

function App() {
  const { t, loadedNamespaces, loadNamespace } = useLanguage();

  useEffect(() => {
    if (!loadedNamespaces.includes("MainPage")) loadNamespace("MainPage");
  }, [loadedNamespaces]);
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
                  Lorem Ipsum is simply dummy text of the printing and
                  typesetting industry.
                </p>
                <input
                  type="text"
                  className="form-control"
                  placeholder="Jelenlegi helyzeted"
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
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's standard dummy
                text ever since the 1500s, when an unknown printer took a galley
                of type and scrambled it to make a type specimen book. It has
                survived not only five centuries, but also the leap into
                electronic typesetting, remaining essentially unchanged. It was
                popularised in the 1960s with the release of Letraset sheets
                containing Lorem Ipsum passages, and more recently with desktop
                publishing software like Aldus PageMaker including versions of
                Lorem Ipsum.
              </p>
            </div>
            <div className="col-lg-6">
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
            <div className="col col-md-4 autok bg-dark">
              <a href="/adatlap" className="off-link">
                <p>
                  <img src={nepszeru} alt="" />
                </p>
                <hr />
                <h2>{t("xyzCar", "MainPage")}</h2>
                <p>{t("clickForMoreInfo", "MainPage")}</p>
              </a>
            </div>
            <div className="col col-md-4 autok bg-dark">
              <a href="/adatlap" className="off-link">
                <p>
                  <img src={nepszeru} alt="" />
                </p>
                <hr />
                <h2>{t("xyzCar", "MainPage")}</h2>
                <p>{t("clickForMoreInfo", "MainPage")}</p>
              </a>
            </div>
            <div className="col col-md-4 autok bg-dark">
              <a href="/adatlap" className="off-link">
                <p>
                  <img src={nepszeru} alt="" />
                </p>
                <hr />
                <h2>{t("xyzCar", "MainPage")}</h2>
                <p>{t("clickForMoreInfo", "MainPage")}</p>
              </a>
            </div>
          </div>
        </section>

        {/* ############################
    #           UTAZÁSI ÁR        #
    ############################ */}
        <section id="ar" className="bg-dark shadow">
          <h1 className="text-light">{t("travelPrices", "MainPage")}</h1>
          <div className="row">
            <div className="col-lg-8">
              <p className="text-light">
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's standard dummy
                text ever since the 1500s, when an unknown printer took a galley
                of type and scrambled it to make a type specimen book. It has
                survived not only five centuries, but also the leap into
                electronic typesetting, remaining essentially unchanged. It was
                popularised in the 1960s with the release of Letraset sheets
                containing Lorem Ipsum passages, and more recently with desktop
                publishing software like Aldus PageMaker including versions of
                Lorem Ipsum.
              </p>
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
            <div className="comment-box bg-light">
              <div className="comment-content">
                <img src={profil} alt="" className="profile" />
                <div className="comment-text">
                  <h5>{t("name", "MainPage")}</h5>
                  <p>
                    Lorem Ipsum is simply dummy text of the printing and
                    typesetting industry.
                  </p>
                </div>
              </div>
            </div>
            <div className="comment-box bg-light">
              <div className="comment-content">
                <img src={profil} alt="" className="profile" />
                <div className="comment-text">
                  <h5>{t("name", "MainPage")}</h5>
                  <p>
                    Lorem Ipsum is simply dummy text of the printing and
                    typesetting industry.
                  </p>
                </div>
              </div>
            </div>
            <div className="comment-box bg-light">
              <div className="comment-content">
                <img src={profil} alt="" className="profile" />
                <div className="comment-text">
                  <h5>{t("name", "MainPage")}</h5>
                  <p>
                    Lorem Ipsum is simply dummy text of the printing and
                    typesetting industry.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </section>
      </main>
    </>
  );
}

export default App;

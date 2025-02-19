import 'bootstrap/dist/css/bootstrap.min.css';
import "./assets/css/elements.css"
import "./assets/css/colors.css"
import "./assets/css/mobile.css"
import map from './assets/img/googlemap.png';
import depo from './assets/img/miert_a_currentcar.png';
import nepszeru from './assets/img/nepszeru_auto.png';
import profil from './assets/img/profile.jpg';

function App() {

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
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                        <input type="text" className="form-control" placeholder="Jelenlegi helyzeted" id="hely"/>
                    </div>
                    <div className="col-lg mt-3">
                        <img src={map} alt="" />
                    </div>
                </div>
            </div>
        </section>




    {/* ############################
    #       MIÉRT A CURRENTCAR     #
    ############################ */}
        <section id="miert_a_currentcar" className='bg-dark shadow'>
            <h1 className="text-light">Miért a CurRentCar?</h1>
            <div className="row center">
                <div className="col-lg-6">
                    <p className="text-light">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
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
            <h1 className="right">Legnépszerűbb autóink</h1>
            <div className="row d-flex justify-content-center">
                <div className="col col-md-4 autok bg-green">
                    <a href="/adatlap" className="text-dark">
                        <p><img src={nepszeru} alt="" /></p>
                        <hr />
                        <h2>XYZ autó</h2>
                        <p>További információkért kattints a képre</p>
                    </a>
                </div>
                <div className="col col-md-4 autok bg-green">
                    <a href="/adatlap" className="text-dark">
                        <p><img src={nepszeru} alt="" /></p>
                        <hr />
                        <h2>XYZ autó</h2>
                        <p>További információkért kattints a képre</p>
                    </a>
                </div>
                <div className="col col-md-4 autok bg-green">
                    <a href="/adatlap" className="text-dark">
                      <p><img src={nepszeru} alt="" /></p>
                      <hr />
                      <h2>XYZ autó</h2>
                      <p>További információkért kattints a képre</p>
                    </a>
                </div>
            </div>
        </section>






    {/* ############################
    #           UTAZÁSI ÁR        #
    ############################ */}
        <section id="ar" className="bg-dark shadow">
            <h1 className="text-light">Utazási árakról</h1>
            <div className="row">
                <div className="col-lg-8">
                    <p className="text-light">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                    </p>
                </div>
                <div className="col-lg-4">
                    <p className="penz text-blue">9999 HUF</p>
                </div>
            </div>
        </section>




    {/* ############################
    #           VÉLEMÉNYEK         #
    ############################ */}
        <section id="velemenyek">
            <h1 className="right">Vélemények</h1>
            <div className="comments">
                <div className="comment-box bg-light">
                    <div className="comment-content">
                        <img src={profil} alt="" className='profile' />
                        <div className="comment-text">
                            <h5>Név</h5>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                        </div>
                    </div>
                </div>
                <div className="comment-box bg-light">
                    <div className="comment-content">
                    <img src={profil} alt="" className='profile' />
                        <div className="comment-text">
                            <h5>Név</h5>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                        </div>
                    </div>
                </div>
                <div className="comment-box bg-light">
                    <div className="comment-content">
                    <img src={profil} alt="" className='profile' />
                        <div className="comment-text">
                            <h5>Név</h5>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
      </main>
    </>
  )
}

export default App

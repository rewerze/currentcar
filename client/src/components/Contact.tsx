import mail from "../assets/img/mail.svg";
import phone from "../assets/img/phone.svg";
import contact from "../assets/img/contact.png";
import location from "../assets/img/location.svg";

function Contact() {
    return(
        <>
            <main className="nav-gap">
                <div className="row contact">
                    <div className="col-md contact-text">
                    <h1 className="text-center">Kapcsolat</h1>
                        <p className="mt-5 text-center">Ha hibát bárhol hibát talál akkor kérem jelezze nekünk a következő helyeken:</p>
                        <ul>
                                <li><span><img src={mail} className="icon" /></span><a href="mailto:david.benedek@verebelyszki.hu">david.benedek@verebelyszki.hu</a></li>
                                <li><span><img src={mail} className="icon" /></span><a href="mailto:kosa.mark@verebelyszki.hu">kosa.mark@verebelyszki.hu</a></li>
                                <li><span><img src={mail} className="icon" /></span><a href="mailto:suhajda.zsolt@verebelyszki.hu">suhajda.zsolt@verebelyszki.hu</a></li>

                                <li className="mt-4"><span><img src={phone} className="icon" /></span><a href="tel:+(981) 401-7534">(981) 401-7534</a></li>

                                <li className="mt-1"><span><img src={location} className="icon" /></span><span><a href="https://www.google.com/maps/place//data=!4m2!3m1!1s0x4741db939c5746e7:0xf93af4f99f4b38a8?sa=X&ved=1t:8290&ictx=111">Budapest, Üteg u. 15, 1139</a></span></li>
                        </ul>
                    </div>
                    <div className="col-md contact-img">
                        <img src={contact} />
                    </div>
                </div>
            </main>
        </>
    )
}

export default Contact;

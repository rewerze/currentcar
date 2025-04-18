import mail from "../assets/img/mail.svg";
import phone from "../assets/img/phone.svg";
import contact from "../assets/img/contact.png";
import location from "../assets/img/location.svg";
import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function Contact() {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("Contact")) {
            loadNamespace("Contact");
        }
    }, [loadedNamespaces, loadNamespace]);

    return (
        <main className="nav-gap">
            <div className="row contact">
                <div className="col-md contact-text">
                    <h1 className="text-center">{t('contact', 'Contact')}</h1>
                    <p className="mt-5 text-center">
                        {t('text', 'Contact')}
                    </p>
                    <table className="contact-table">
                        <tbody>
                            <tr>
                                <td>
                                    <img src={mail} className="icon" alt="mail ikon" />
                                    <a href="mailto:david.benedek@verebelyszki.hu">david.benedek@verebelyszki.hu</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src={mail} className="icon" alt="mail ikon" />
                                    <a href="mailto:kosa.mark@verebelyszki.hu">kosa.mark@verebelyszki.hu</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src={mail} className="icon" alt="mail ikon" />
                                    <a href="mailto:suhajda.zsolt@verebelyszki.hu">suhajda.zsolt@verebelyszki.hu</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src={phone} className="icon" alt="telefon ikon" />
                                    <a href="tel:+19814017534">(981) 401-7534</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src={location} className="icon" alt="lokáció ikon" />
                                    <a href="https://www.google.com/maps/place//data=!4m2!3m1!1s0x4741db939c5746e7:0xf93af4f99f4b38a8?sa=X&ved=1t:8290&ictx=111" target="_blank" rel="noopener noreferrer">
                                        Budapest, Üteg u. 15, 1139
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div className="col-md contact-img">
                    <img src={contact} alt="Kapcsolat illusztráció" />
                </div>
            </div>
        </main>
    );
}

export default Contact;

import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function AboutUs() {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("AboutUs")) {
            loadNamespace("AboutUs");
        }
    }, [loadedNamespaces, loadNamespace]);

    return (
        <main className="nav-gap">
            <h1 className="text-center">Rólunk</h1>
            <p className="text-center mt-3 mb-5 fs-4">
                A CurRentCar weboldal és alkamlamazás fejlesztői, akik igyekeznek az oldal tökéletes működésében!
            </p>
            <div className="row aboutus-team">
                <div className="about-card">
                    <h2 className="text-center">Kósa Márk</h2>
                    <p className="text-center"><b>Web · Backend</b></p>
                    <p className="about-bio">placeholder</p>
                </div>
                <div className="about-card">
                    <h2 className="text-center">Suhajda Zsolt Péter</h2>
                    <p className="text-center"><b>Web · Frontend</b></p>
                    <p className="about-bio">placeholder</p>
                </div>
                <div className="about-card">
                    <h2 className="text-center">Dávid Benedek</h2>
                    <p className="text-center"><b>Asztali alkalmazás</b></p>
                    <p className="about-bio">placeholder</p>
                </div>
            </div>
        </main>
    );
}

export default AboutUs;

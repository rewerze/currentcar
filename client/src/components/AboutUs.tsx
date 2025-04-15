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
            <h1 className="text-center">{t("title", "AboutUs")}</h1>
            <p className="text-center mt-3 mb-5 fs-4">{t("text", "AboutUs")}</p>
            <div className="row aboutus-team">
                <div className="about-card">
                    <h2 className="text-center">Kósa Márk Milán</h2>
                    <p className="text-center"><b>Web · Backend</b></p>
                    <p className="about-bio">{t("kmDesc", "AboutUs")}</p>
                </div>
                <div className="about-card">
                    <h2 className="text-center">Suhajda Zsolt Péter</h2>
                    <p className="text-center"><b>Web · Frontend</b></p>
                    <p className="about-bio">{t("szsDesc", "AboutUs")}</p>
                </div>
                <div className="about-card">
                    <h2 className="text-center">Dávid Benedek</h2>
                    <p className="text-center"><b>{t("dbJob", "AboutUs")}</b></p>
                    <p className="about-bio">{t("dbDesc", "AboutUs")}</p>
                </div>
            </div>
        </main>
    );
}

export default AboutUs;

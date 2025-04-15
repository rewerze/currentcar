import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function CarRent() {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("CarRent")) {
            loadNamespace("CarRent");
        }
    }, [loadedNamespaces, loadNamespace]);

    return (
        <>
            <main className="nav-gap">
                <h1 className="text-center">{t("title", "CarRent")}</h1>
                <div className="car-rent">
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">{t("stepOneTitle", "CarRent")}</h2>
                            <p>{t("stepOneDescription", "CarRent")}</p>
                        </div>
                        <div className="d-flex justify-content-center p-2">
                            <a href="/register" className="btn btn-primary w-100 mt-3">
                                {t("stepOneButton", "CarRent")}
                            </a>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">{t("stepTwoTitle", "CarRent")}</h2>
                            <p>{t("stepTwoDescription", "CarRent")}</p>
                        </div>
                        <div className="d-flex justify-content-center p-2">
                            <a href="/kovetelmenyek" className="btn btn-primary w-100 mt-3">
                                {t("stepTwoButton", "CarRent")}
                            </a>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card-body">
                            <h2 className="text-center">{t("stepThreeTitle", "CarRent")}</h2>
                            <p>{t("stepThreeDescription", "CarRent")}</p>
                        </div>
                        <div className="d-flex justify-content-center p-2">
                            <a href="/osszesauto" className="btn btn-primary w-100 mt-3">
                                {t("stepThreeButton", "CarRent")}
                            </a>
                        </div>
                    </div>
                </div>
            </main>
        </>
    );
}

export default CarRent;

import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function FAQ() {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("FAQ")) {
            loadNamespace("FAQ");
        }
    }, [loadedNamespaces, loadNamespace]);

    return (
        <>
        <main className="nav-gap">
            <h1 className="text-center p-2">
                {t("faq_title", "FAQ")}
            </h1>

            <div className="mx-5">
                <details>
                    <summary className="display-5">{t("q1", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a1", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q2", "FAQ")}<hr className="w-100" /></summary>
                    <p>
                        {t("a2", "FAQ")} <a href="/kovetelmenyek">{t("a2_link", "FAQ")}</a>
                    </p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q3", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a3", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q4", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a4", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q5", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a5", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q6", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a6", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q7", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a7", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q8", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a8", "FAQ")}</p>
                </details>
            </div>

            <div className="mx-5 mt-5">
                <details>
                    <summary className="display-5">{t("q9", "FAQ")}<hr className="w-100" /></summary>
                    <p>{t("a9", "FAQ")}</p>
                </details>
            </div>
        </main>
        </>
    )
}

export default FAQ;

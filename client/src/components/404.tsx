import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function NotFound() {
    const { t, loadedNamespaces, loadNamespace } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("NotFound"))
            loadNamespace("NotFound");
    }, [loadedNamespaces]);
    return (
        <>
            <main className="nav-gap">
                <h1 className="text-center notfound">{t('title', 'NotFound')}</h1>
                <p className="text-center">{t('message', 'NotFound')}</p>
                <p className="text-center">
                    <a href="/" className="btn btn-primary w-25">{t('back', 'NotFound')}</a>
                </p>
            </main>
        </>
    )
}

export default NotFound;
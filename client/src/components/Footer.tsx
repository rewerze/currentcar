import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function Footer() {
    const { t, loadedNamespaces, loadNamespace } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("Footer"))
            loadNamespace("Footer");
    }, [loadedNamespaces]);
    return(
        <>
    {/* ############################
    #             FOOTER           #
    ############################ */}
      <footer className="bg-dark text-light">
            <div className="row">
                <div className="col-3">
                    <p dangerouslySetInnerHTML={{ __html: t('copyright', 'Footer')}}></p>
                </div>
                <div className="col-3">
                    <p><b>{t('links', 'Footer')}</b></p>
                    <a href="/">{t('homepage', 'Footer')}</a>
                    <a href="/kapcsolat">{t('contact', 'Footer')}</a>
                    <a href="/rolunk">{t('aboutUs', 'Footer')}</a>
                    <a href="/gyik">{t('faq', 'Footer')}</a>
                </div>
                <div className="col-3">
                    <p><b>{t('ourServices', 'Footer')}</b></p>
                    <a href="/berles">{t('carRental', 'Footer')}</a>
                    <a href="/feladas">{t('carListing', 'Footer')}</a>
                    <a href="/osszesauto">{t('allcar', 'Footer')}</a>
                </div>
                <div className="col-3">
                    <p><b>{t('contactUs', 'Footer')}</b></p>
                    <a href="http://facebook.com" target="_blank">Facebook</a>
                    <a href="http://x.com" target="_blank">Twitter</a>
                    <a href="http://instagram.com" target="_blank">Instagram</a>
                    <a href="http://linkedin.com" target="_blank">LinkedIn</a>
                </div>
            </div>
      </footer>
    </>
    )
}

export default Footer;

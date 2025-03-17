import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

function Requirements() {
    const { t, loadedNamespaces, loadNamespace } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("requirements"))
            loadNamespace("requirements");
    }, [loadedNamespaces]);
    return (
        <>
            <main className="nav-gap">
                <h1 className="text-center">{t('requirements', 'requirements')}</h1>
                <p className="text-center"><b dangerouslySetInnerHTML={{ __html: t('editData', 'requirements') }}></b></p>


                {/* A NEGYEDIK OSZLOP AZ JELÖLHETNÉ HOGY A FELHASZNÁLÓ MÁR MEGADTA-E AZ ADATÁT VAGY NEM. */}
                <table className="req-table mx-auto">
                    <tr>
                        <th className="w-25 p-1">{t('data', 'requirements')}</th>
                        <th className="w-50 p-1">{t('description', 'requirements')}</th>
                        <th className="w-25 p-1">{t('priority', 'requirements')}</th>
                    </tr>
                    <tr>
                        <td className="p-1">{t('validLicense', 'requirements')}</td>
                        <td className="p-1">{t('validLicenseDescription', 'requirements')}</td>
                        <td className="p-1">{t('validLicensePriority', 'requirements')}</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('contact', 'requirements')}</td>
                        <td className="p-1">{t('contactDescription', 'requirements')}</td>
                        <td className="p-1">{t('contactPriority', 'requirements')}</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('iban', 'requirements')}</td>
                        <td className="p-1">{t('ibanDescription', 'requirements')}</td>
                        <td className="p-1">{t('ibanPriority', 'requirements')}</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('age', 'requirements')}</td>
                        <td className="p-1">{t('ageDescription', 'requirements')}</td>
                        <td className="p-1">{t('agePriority', 'requirements')}</td>
                        <td className="p-1 fs-5">✅</td>
                    </tr>
                </table>


                {/* ELLENŐRZÉS HOGY MEGVANNAK E ADVA AZ ADATOK MEGFELEL E VAGY NEM A FELHASZNÁLÓ MÁR */}
                <p className="text-center text-success mt-3"><b>{t('success', 'requirements')}</b></p>
                <p className="text-center text-danger mt-3"><b>{t('fail', 'requirements')}</b></p>
            </main>
        </>
    )
}

export default Requirements;

import { useLanguage } from "@/contexts/LanguageContext";
import { useUser } from "@/contexts/UserContext";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function Requirements() {
    const { user, loading } = useUser();
    const { t, loadedNamespaces, loadNamespace } = useLanguage();
    const navigate = useNavigate();

    const [allRequirementsMet, setAllRequirementsMet] = useState(false);

    useEffect(() => {
        if (!loadedNamespaces.includes("requirements"))
            loadNamespace("requirements");
    }, [loadedNamespaces]);

    const checkRequirements = () => {
        const requirements = [
            user?.driver_license_expiry != null && user?.driver_license_number != null,
            user?.user_email != null && Number(user?.u_phone_number) != 0,
            user?.user_iban != null,
            user?.born_at != null && new Date().getFullYear() - new Date(user?.born_at).getFullYear() >= 17,
        ];

        setAllRequirementsMet(requirements.every(Boolean));
    };

    useEffect(() => {
        if (!user && !loading) {
            navigate("/")
        }
    }, [user, loading])

    useEffect(() => {
        if (!loading && user) {
            checkRequirements();
        }
    }, [user, loading]);

    return (
        <>
            <main className="nav-gap mx-3">
                <h1 className="text-center">{t('requirements', 'requirements')}</h1>
                <p className="text-center"><b dangerouslySetInnerHTML={{ __html: t('editData', 'requirements') }}></b></p>


                {/* A NEGYEDIK OSZLOP AZ JELÖLHETNÉ HOGY A FELHASZNÁLÓ MÁR MEGADTA-E AZ ADATÁT VAGY NEM. */}
                <table className="req-table mx-auto">
                    <tr>
                        <th className="w-25 p-1">{t('data', 'requirements')}</th>
                        <th className="w-75 p-1">{t('description', 'requirements')}</th>
                    </tr>
                    <tr>
                        <td className="p-1">{t('validLicense', 'requirements')}</td>
                        <td className="p-1">{t('validLicenseDescription', 'requirements')}</td>
                        <td className="p-1 fs-5">{user?.driver_license_expiry != undefined && user.driver_license_number != undefined ? "✅" : "❌"}</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('contact', 'requirements')}</td>
                        <td className="p-1">{t('contactDescription', 'requirements')}</td>
                        <td className="p-1 fs-5">{user?.user_email != undefined && Number(user.u_phone_number) != 0 ? "✅" : "❌"}</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('iban', 'requirements')}</td>
                        <td className="p-1">{t('ibanDescription', 'requirements')}</td>
                        <td className="p-1 fs-5">{user?.user_iban != undefined ? "✅" : "❌"}</td>
                    </tr>
                    <tr>
                        <td className="p-1">{t('age', 'requirements')}</td>
                        <td className="p-1">{t('ageDescription', 'requirements')}</td>
                        <td className="p-1 fs-5">{user?.born_at != undefined && new Date().getFullYear() - new Date(user?.born_at).getFullYear() >= 17 ? "✅" : "❌"}</td>
                    </tr>
                </table>


                {/* ELLENŐRZÉS HOGY MEGVANNAK E ADVA AZ ADATOK MEGFELEL E VAGY NEM A FELHASZNÁLÓ MÁR */}
                <p className={`text-center mt-3 ${allRequirementsMet ? 'text-success' : 'text-danger'}`}>
                    <b>{allRequirementsMet ? t('success', 'requirements') : t('fail', 'requirements')}</b>
                </p>
            </main>
        </>
    )
}

export default Requirements;

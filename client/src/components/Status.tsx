import success from "../assets/img/success.svg";
import fail from "../assets/img/cancel.svg";
import { useEffect, useRef, useState } from "react";
import { buildApiUrl } from "@/lib/utils";
import axios, { AxiosError } from "axios";
import { toast } from "sonner";
import { useNavigate, useParams } from "react-router-dom";
import { useLanguage } from "@/contexts/LanguageContext";
import { useUser } from "@/contexts/UserContext";
import { CarInfo } from "./interfaces/Car";

function Success() {
    const { user, loading } = useUser();
    const { t, loadNamespace, loadedNamespaces } = useLanguage();
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();
    const [car, setCarInfo] = useState<CarInfo | null>(null);
    const [startDate, setStartDate] = useState<Date>();
    const [endDate, setEndDate] = useState<Date>();
    const [successfulPurchase, setSuccessfulPurchase] = useState<boolean>(false);
    const [error, setError] = useState<string>();
    const [purchaseLoading, setPurchaseLoading] = useState<boolean>(true);
    const hasRunRef = useRef(false);

    useEffect(() => {
        const fetchCarData = async () => {
            try {
                const response = await fetch(buildApiUrl(`/car?id=${id}`), {
                    credentials: "include",
                });

                if (!response.ok) {
                    throw new Error(`Failed to fetch car data: ${response.status}`);
                }

                const data = await response.json();
                setCarInfo(data);
            } catch (error) {
                console.error(error);
                toast.error(t("errorFetchingCar", "CarDetail"));
            }
        };

        fetchCarData();
    }, [id, t]);

    useEffect(() => {
        if (!loading && !user) {
            navigate("/login")
        }
    }, [user, loading]);

    useEffect(() => {
        if (!loadedNamespaces.includes("CarDetail")) {
            loadNamespace("CarDetail");
        }
    }, [loadedNamespaces, loadNamespace]);

    useEffect(() => {
        if (hasRunRef.current) return;
        hasRunRef.current = true;
        const urlParams = new URLSearchParams(window.location.search);
        const paypalOrderId = urlParams.get("token");
        const paymentStatus = urlParams.get("PayerID");

        if (paypalOrderId && paymentStatus) {
            const completePaypalPayment = async () => {
                try {
                    const response = await axios.post(
                        buildApiUrl("/paypal/capture-order"),
                        {
                            orderID: paypalOrderId,
                            car_id: id,
                        },
                        {
                            withCredentials: true,
                        }
                    );

                    if (response.data.success) {
                        setStartDate(response.data.startDate);
                        setEndDate(response.data.endDate);
                        toast.success(t("purchaseSuccess", "CarDetail"));
                        window.history.replaceState(
                            {},
                            document.title,
                            window.location.pathname
                        );
                        setSuccessfulPurchase(true);
                        setPurchaseLoading(false); 0
                    } else {
                        toast.error(response.data.error || t("paypalError", "CarDetail"));
                        setError(response.data.error || t("paypalError", "CarDetail"));
                        setPurchaseLoading(false);
                    }
                } catch (error) {
                    console.error("Error completing PayPal payment:", error);
                    //toast.error(t("paypalError", "CarDetail"));
                    setError(((error as AxiosError)?.response?.data as { error: string }).error || t("paypalError", "CarDetail"));
                    setPurchaseLoading(false);
                }
            };

            completePaypalPayment();
        } else {
            navigate("/osszesauto")
        }
    }, [id]);

    if (purchaseLoading) {
        return (
            <>
                <main className="nav-gap">
                    <div className="text-center px-5">
                        <p>Loading...</p>
                    </div>
                </main>
            </>
        )
    }

    return (
        <>
            <main className="nav-gap">
                <div className="d-flex justify-content-center">
                    {
                        successfulPurchase ? (
                            <img src={success} className="success-icon" />
                        ) : (
                            <img src={fail} className="success-icon" />
                        )
                    }
                </div>
                {
                    successfulPurchase ? (
                        <div className="px-5">
                            <p className="text-center mt-5 text-success"><b>{car?.car_brand} {car?.car_model}</b> {t('successfullyPurchased', 'CarDetail')}</p>
                            <p className="text-center"><b>{startDate ? new Date(startDate).toLocaleDateString() : new Date().toLocaleDateString()} - {endDate ? new Date(endDate).toLocaleDateString() : new Date().toLocaleDateString()} </b></p>
                        </div>
                    ) : (
                        <div className="px-5">
                            <p className="text-center mt-5 text-danger" dangerouslySetInnerHTML={{ __html: t('rentFailed', 'CarDetail') }}></p>
                            <p className="text-center">{error}</p>
                        </div>
                    )
                }
            </main>
        </>
    )
}

export default Success;
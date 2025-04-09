import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect, useState } from "react";
import "../assets/css/modal.css";

function PaymentModal({ isOpen, onClose, onPurchase }: { isOpen: boolean, onClose: () => void, onPurchase: (fromDate: string, toDate: string, paymentMethod: string) => void; }) {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();
    const [fromDate, setFromDate] = useState('');
    const [toDate, setToDate] = useState('');
    const [paymentMethod, setPaymentMethod] = useState('');

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        onPurchase(fromDate, toDate, paymentMethod);
    };

    useEffect(() => {
        if (!loadedNamespaces.includes("Payment")) {
            loadNamespace("Payment");
        }
    }, [loadedNamespaces, loadNamespace]);

    if (!isOpen) return null;
    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal-content bg-dark" onClick={e => e.stopPropagation()}>
                <div className="modal-header">
                    <button type="button" className="close-button" onClick={onClose}>×</button>
                </div>
                <div className="modal-body">
                    <form className="form" onSubmit={handleSubmit}>
                        <div>
                            <h1>{t('rent_period', 'Payment')}</h1>
                            <h2 className="mt-3">{t('rent_period', 'Payment')}:</h2>
                            <div className="rent-time">
                                <label htmlFor="from">{t('from', 'Payment')}</label>
                                <label htmlFor="to">{t('until', 'Payment')}</label>
                            </div>
                            <div className="rent-time mt-2">
                                <input
                                    type="date"
                                    name="from"
                                    id="from"
                                    max="9999-12-31"
                                    className="form-control"
                                    value={fromDate}
                                    onChange={(e) => setFromDate(e.target.value)}
                                />
                                <input
                                    type="date"
                                    name="to"
                                    id="to"
                                    max="9999-12-31"
                                    className="form-control"
                                    value={toDate}
                                    onChange={(e) => setToDate(e.target.value)}
                                />
                            </div>
                            <h2 className="mt-4">{t('payment_method', 'Payment')}</h2>
                            <div className="payment-method">
                                <input type="radio" name="payment-method" id="cash" value="cash" className="form-check-input" onChange={(_) => setPaymentMethod('cash')} />
                                <label htmlFor="cash">{t('cash', 'Payment')}</label>
                                <input type="radio" name="payment-method" id="card" value="card" className="form-check-input" onChange={(_) => setPaymentMethod('card')} />
                                <label htmlFor="card" className="form-check-label">{t('card', 'Payment')}</label>
                            </div>
                            <button className="w-100 btn btn-success mt-5">{t('to_payment', 'Payment')}</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default PaymentModal;
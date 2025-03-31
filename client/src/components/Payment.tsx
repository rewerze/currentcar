import { useState } from "react";

function PaymentModal({ isOpen, onClose, onPurchase }: { isOpen: boolean, onClose: () => void, onPurchase: (fromDate: string, toDate: string, paymentMethod: string) => void; }) {
    const [fromDate, setFromDate] = useState('');
    const [toDate, setToDate] = useState('');
    const [paymentMethod, setPaymentMethod] = useState('');
    if (!isOpen) return null;

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        onPurchase(fromDate, toDate, paymentMethod);
    };

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal-content" onClick={e => e.stopPropagation()}>
                <div className="modal-header">
                    <button type="button" className="close-button" onClick={onClose}>×</button>
                </div>
                <div className="modal-body">
                    <form className="form" onSubmit={handleSubmit}>
                        <div className="form-box bg-dark">
                            <h1>Fizetés</h1>
                            <h2 className="mt-3">Bérlés időtartalma:</h2>
                            <div className="rent-time">
                                <label htmlFor="from">Mettől?</label>
                                <label htmlFor="to">Meddig?</label>
                            </div>
                            <div className="rent-time mt-2">
                                <input
                                    type="date"
                                    name="from"
                                    id="from"
                                    className="form-control"
                                    value={fromDate}
                                    onChange={(e) => setFromDate(e.target.value)}
                                />
                                <input
                                    type="date"
                                    name="to"
                                    id="to"
                                    className="form-control"
                                    value={toDate}
                                    onChange={(e) => setToDate(e.target.value)}
                                />
                            </div>
                            <h2 className="mt-4">Hogyan szeretne fizetni?</h2>
                            <div className="payment-method">
                                <input type="radio" name="payment-method" id="cash" value="cash" className="form-check-input" onChange={(_) => setPaymentMethod('cash')} />
                                <label htmlFor="cash">Kézpénzben</label>
                                <input type="radio" name="payment-method" id="card" value="card" className="form-check-input" onChange={(_) => setPaymentMethod('card')} />
                                <label htmlFor="card" className="form-check-label">Kártyával</label>
                            </div>
                            <button className="w-100 btn btn-success mt-5">Tovább a fizetéshez</button>
                        </div>
                    </form>
                </div>
            </div>

            <style>{`
        .modal-overlay {
          position: fixed;
          top: 0;
          left: 0;
          right: 0;
          bottom: 0;
          background-color: rgba(0, 0, 0, 0.5);
          display: flex;
          justify-content: center;
          align-items: center;
          z-index: 1000;
        }
        
        .modal-content {
          padding: 20px;
          border-radius: 5px;
          max-width: 500px;
          width: 90%;
          max-height: 90vh;
          overflow-y: auto;
        }
        
        .modal-header {
          display: flex;
          justify-content: flex-end;
        }
        
        .close-button {
          background: none;
          border: none;
          font-size: 24px;
          cursor: pointer;
        }
      `}</style>
        </div>
    );
}

export default PaymentModal;
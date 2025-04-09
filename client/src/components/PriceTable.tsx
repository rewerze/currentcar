import { useEffect } from "react";
import "../assets/css/modal.css";

function PriceTableModal({ isOpen, onClose }: { isOpen: boolean, onClose: () => void }) {
    useEffect(() => {
        const handleEsc = (event: KeyboardEvent) => {
            if (event.key === "Escape") onClose();
        };
        window.addEventListener("keydown", handleEsc);
        return () => window.removeEventListener("keydown", handleEsc);
    }, [onClose]);

    if (!isOpen) return null;

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal-content text-light bg-dark" onClick={(e) => e.stopPropagation()}>
                <div className="modal-header">
                    <button type="button" className="close-button" onClick={onClose}>×</button>
                </div>
                <div className="modal-body">
                    <h1 className="text-center text-light">Jármű ajánlott árazás tábla</h1>
                    <div className="table-responsive mt-4">
                        <table className="table price-table mx-auto text-light">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th className="text-danger">Gyenge</th>
                                    <th className="text-warning">Megfelelő</th>
                                    <th className="text-warning">Jó</th>
                                    <th className="text-success">Kiválló</th>
                                    <th className="text-success">Új</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>Alap ár:</th>
                                    <td>4000 HUF</td>
                                    <td>7000 HUF</td>
                                    <td>13000 HUF</td>
                                    <td>20000 HUF</td>
                                    <td>30000 HUF</td>
                                </tr>
                                <tr>
                                    <th>Óra ár:</th>
                                    <td>300 HUF</td>
                                    <td>700 HUF</td>
                                    <td>1000 HUF</td>
                                    <td>1400 HUF</td>
                                    <td>1800 HUF</td>
                                </tr>
                                <tr>
                                    <th>Napi ár:</th>
                                    <td>500 HUF</td>
                                    <td>1000 HUF</td>
                                    <td>2000 HUF</td>
                                    <td>3000 HUF</td>
                                    <td>4000 HUF</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default PriceTableModal;
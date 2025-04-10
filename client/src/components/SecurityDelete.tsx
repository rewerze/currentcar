import { useLanguage } from "@/contexts/LanguageContext";
import { useEffect } from "react";

interface SecurityDeleteProps {
    isOpen: boolean;
    onClose: () => void;
    onConfirm: () => void;
}

function SecurityDelete({ isOpen, onClose, onConfirm }: SecurityDeleteProps) {
    const { t, loadNamespace, loadedNamespaces } = useLanguage();

    useEffect(() => {
        if (!loadedNamespaces.includes("Security")) {
            loadNamespace("Security");
        }
    }, [t, loadNamespace, loadedNamespaces]);
    if (!isOpen) return null;

    return (
        <div className="modal-overlay" style={{
            position: 'fixed',
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
            backgroundColor: 'rgba(0, 0, 0, 0.5)',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            zIndex: 1000
        }}>
            <div className="modal-content text-light bg-dark" style={{
                padding: '20px',
                borderRadius: '5px',
                width: '90%',
                maxWidth: '500px',
                position: 'relative'
            }}>
                <div className="modal-header">
                    <button
                        type="button"
                        className="btn btn-outline-light"
                        onClick={onClose}
                        style={{
                            position: 'absolute',
                            right: '10px',
                            top: '10px',
                            width: '30px',
                            height: '30px',
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                            padding: '0',
                            fontSize: '20px',
                            lineHeight: '1',
                            borderRadius: '50%'
                        }}
                    >
                        ×
                    </button>
                </div>
                <div className="modal-body">
                    <h3 className="text-center text-light">{t('confirmDelete', 'Security')}</h3>
                    <div className="d-flex gap-3 mt-4">
                        <button className="btn btn-success w-50" onClick={onClose}>{t('decline', 'Security')}</button>
                        <button className="btn btn-danger w-50" onClick={onConfirm}>{t('accept', 'Security')}</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default SecurityDelete;
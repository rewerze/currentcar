function SecurityDelete() {
    return(
        <>
<div className="modal-overlay">
            <div className="modal-content text-light bg-dark">
                <div className="modal-header">
                    {/* <button type="button" className="close-button" onClick={onClose}>×</button> */}
                </div>
                <div className="modal-body">
                    <h1 className="text-center text-light">Biztos törlöd a profilod?</h1>
                    <div className="d-flex gap-3">
                        <button className="btn btn-success w-50">Nem, mégse szeretném.</button>
                        <button className="btn btn-danger w-50">Igen, biztos vagyok!</button>
                    </div>
                </div>
            </div>
        </div>
        </>
    )
}

export default SecurityDelete;

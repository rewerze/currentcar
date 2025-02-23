function Password() {
    return(
        <>
        <main>
            <form action="/jelszo-modositas" className="form">
                <div className="form-box bg-dark text-light">
                    <h1>Jelszó módosítás</h1>
                    <hr />

                    {/* RÉGI JELSZÓ */}
                    <div className="form-content mt-2">
                    <label htmlFor="password" className="form-label">Régi jelszava:</label>
                    <input
                        type="password"
                        name="password"
                        id="password"
                        // value={passwordOld}
                        onChange={(e) => setPassword(e.target.value)}
                        className="form-control w-100"
                        placeholder="Adja meg a régi jelszavát"
                        required
                    />
                    </div>
                    
                    {/* ÚJ JELSZÓ */}
                    <div className="form-content mt-2">
                    <label htmlFor="password" className="form-label">Új jelszava:</label>
                    <input
                        type="password"
                        name="password"
                        id="password"
                        // value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="form-control w-100"
                        placeholder="Mi legyen az új jelszava?"
                        required
                    />
                    </div>

                    {/* JELSZÓ ISMÉTLÉSE */}
                    <div className="form-content mt-2">
                    <label htmlFor="password-confirmation" className="form-label">Új jelszava ismétlése:</label>
                    <input
                        type="password"
                        name="password-confirmation"
                        id="password-confirmation"
                        // value={passwordAgain}
                        onChange={(e) => setPasswordAgain(e.target.value)}
                        className="form-control w-100"
                        placeholder="Írd be mégegyszer!"
                        required
                    />
                    </div>

                    <div className="d-flex justify-content-center gap-2">
                        <button className="btn btn-warning w-100 mt-5" type="submit">Jelszó módosítása</button>
                        <a className="btn btn-danger w-100 mt-5" href="/profil">Mégse</a>
                    </div>
                </div>
            </form>
        </main>
        </>
    )
}

export default Password;
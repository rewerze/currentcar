/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useEffect, useState } from "react";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";

function Password() {
    const { resetPass, loading, error, user } = useUser();
    const [oldPassword, setOldPassword] = useState("");
    const [password, setPassword] = useState("");
    const [passwordAgain, setPasswordAgain] = useState("");
    const navigate = useNavigate();

    async function changePassword(e: React.FormEvent) {
        e.preventDefault();


        await resetPass(oldPassword, password, passwordAgain)
    }

    useEffect(() => {
        if (!loading && !user) {
            navigate('/login')
        }
    }, [user, loading, navigate])

    return (
        <>
            <main className="nav-gap">
                <form onSubmit={changePassword} className="form">
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
                                value={oldPassword}
                                onChange={(e) => setOldPassword(e.target.value)}
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
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                className="form-control w-100"
                                placeholder="Mi legyen az új jelszava?"
                                required
                            />
                            <p className="m-0"><b className="text-danger">A jelszavad tartalmazzon a következő feltételek mindegyikéből legalább egyet:</b> nagybetű, szám, speciális karakter. Példa jelszó: Almafa123!</p>
                        </div>

                        {/* JELSZÓ ISMÉTLÉSE */}
                        <div className="form-content mt-2">
                            <label htmlFor="password-confirmation" className="form-label">Új jelszava ismétlése:</label>
                            <input
                                type="password"
                                name="password-confirmation"
                                id="password-confirmation"
                                value={passwordAgain}
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
                        {error && <p className="text-danger text-center mt-2">{error}</p>}
                    </div>
                </form>
            </main>
        </>
    )
}

export default Password;
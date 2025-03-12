function EditProfile() {
    return(
        <>
            <main className="nav-gap">
                <form action="/profil/modositas" method="post" className="form">

                    <div className="form-box bg-dark">
                        <h1>Felhasználói adatok módosítása</h1>
                        
                        {/* FELHASZNÁLÓNÉV */}
                        <label htmlFor="user_name" className="form-label">Felhasználó név:</label>
                        <input type="text" name="user_name" id="user_name" className="form-control" />
                        
                        {/* EMAIL CÍM */}
                        <label htmlFor="user_name" className="form-label mt-3">E-mail cím:</label>
                        <input type="text" name="user_name" id="user_name" className="form-control" />
                        
                        {/* TELEFONSZÁM */}
                        <label htmlFor="user_name" className="form-label mt-3">Telefonszám:</label>
                        <input type="text" name="user_name" id="user_name" className="form-control" />
                        
                        {/* Jogosítvány szám */}
                        <label htmlFor="user_name" className="form-label mt-3">Jogosítvány szám:</label>
                        <input type="text" name="user_name" id="user_name" className="form-control" />
                        
                        {/* Jogosítvány lejárati dátuma */}
                        <label htmlFor="user_name" className="form-label mt-3">Jogosítvány lejárati dátuma:</label>
                        <input type="text" name="user_name" id="user_name" className="form-control" />
                        
                        <div className="d-flex justify-content-center mt-5 gap-3">
                            <a href="/profil/kepcsere" className="btn btn-light">Profilkép csere</a>
                            <button type="submit" className="btn btn-success">Adatok mentése</button>
                            <a href="/profil/jelszo-modositas" className="btn btn-warning">Jelszó módosítása</a>
                        </div>
                    </div>
                </form>
            </main>
        </>
    )
}

export default EditProfile;

function EditProfile() {
    return(
        <>
            <main className="nav-gap">
                <form action="/profil/modositas" method="post" className="form">

                    <div className="form-body bg-dark">

                        {/* FELHASZNÁLÓNÉV */}
                        <label htmlFor="user_name">Felhasználó név:</label>
                        <input type="text" name="user_name" id="user_name" />
                    </div>
                </form>
            </main>
        </>
    )
}

export default EditProfile;

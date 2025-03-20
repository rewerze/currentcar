import upload from "../assets/img/upload.svg"

function ProfilePicture() {
    return(
        <>
        
        <main className="nav-gap">
            <div className="drop-zone d-flex justify-content-center">
                <img src={upload} />
                <p>Húzz ide egy fájlt vagy válassz ki egyet!</p>
            </div>
        </main>
        
        </>
    )
}

export default ProfilePicture;
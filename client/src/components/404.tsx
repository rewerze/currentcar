function NotFound() {
    return(
        <>
            <main className="nav-gap">
                <h1 className="text-center notfound">ERROR 404 - Az oldal nem található</h1>
                <p className="text-center">Sajnáljuk, ez az oldal nem létezik vagy más útvonalon található.</p>
                <p className="text-center">
                <a href="/" className="btn btn-primary w-25">Térjen vissza a főoldalra!</a>
                </p>
            </main>
        </>
    )
}

export default NotFound;
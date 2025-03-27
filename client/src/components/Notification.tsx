function Notification() {
    return(
    <>
        <main className="nav-gap">
            <h1 className="text-center">Értesítések</h1>
            <div className="notif bg-dark">
                <div className="row">
                        <h2>Bejövő értesítések</h2>
                    <div className="col-md-4 notif-hidden">
                        <div className="notif-card mt-5">
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                            <div className="notif-card-content">
                                <button>
                                <h3>Értesítés cím</h3>
                                <p>rövid részlet az értesítés elejéből...</p>
                                </button>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-8">
                        <div className="notif-message">
                            <h2>Értesítés cím</h2>
                            <p>az egész üzenet</p>
                            <button className="btn btn-primary">Vissza</button>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </>
    )
}

export default Notification;
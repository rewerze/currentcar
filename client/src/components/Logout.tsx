import { useEffect } from "react";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";

export default function Logout() {
    const { user, loading, logout, setUser } = useUser()
    const navigate = useNavigate()
    useEffect(() => {
        if (!loading && user && setUser) {
            logout();
            setUser(null);
            navigate('/')
        }
    }, [user, loading, logout, navigate, setUser])

    return (
        <></>
    )
}
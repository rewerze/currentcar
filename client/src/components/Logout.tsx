import { useEffect } from "react";
import { useUser } from "../contexts/UserContext";
import { useNavigate } from "react-router-dom";

export default function Logout() {
    const { user, loading, logout } = useUser()
    const navigate = useNavigate()
    useEffect(() => {
        if (!loading && user) {
            logout()
            navigate('/')
        }
    }, [user, loading, logout, navigate])

    return (
        <></>
    )
}
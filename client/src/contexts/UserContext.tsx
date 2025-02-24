/* eslint-disable react-refresh/only-export-components */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { createContext, useState, useEffect, useContext } from "react";
import axios from "axios";

type UserRole = "admin" | "user"

export type User = {
    id: number;
    email: string;
    username: string;
    born_date: string;
    role: UserRole;
    jogositvany_szam: string;
    jogositvany_lejarat: number;
    phone_number: string;
};

export type UserContextType = {
    user: User | null;
    loading: boolean;
    error?: string | null;
    setUser?: React.Dispatch<React.SetStateAction<User | null>>;
    logout: () => void;
    register: (username: string, password: string, email: string, bornDate: string) => void;
    login: (email: string, password: string) => void;
    resetPass: (oldPassword: string, newPassword: string) => Promise<void>;
    setError: (message: string | null) => void;
};

const buildApiUrl = (endpoint: string) => {
    const baseUrl = process.env.NODE_ENV !== "production" ? "http://localhost:3000" : "";
    return `${baseUrl}/api${endpoint}`;
};

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<User | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                const response = await axios.get(buildApiUrl("/auth/verify"), { withCredentials: true });
                setUser(response.data.user);
            } catch (err) {
                setError("");
            } finally {
                setLoading(false);
            }
        };

        fetchUser();
    }, []);

    const logout = async () => {
        try {
            await axios.post(buildApiUrl("/auth/logout"), {}, {
                withCredentials: true,
            });
            setUser(null);
        } catch (err) {
            setError("Error logging out.");
        }
    };

    const register = async (username: string, password: string, email: string, bornDate: string) => {
        setLoading(true)
        setError(null)

        try {
            const response = await axios.post(buildApiUrl("/auth/register"), {
                username,
                password,
                email,
                bornDate
            }, {
                withCredentials: true
            })

            setLoading(false)
            setUser(response.data.user)
        } catch (err: any) {
            setLoading(false)
            setError(err.response?.data?.error || "Registration failed. Please try again.")
        }
    }

    const login = async (email: string, password: string) => {
        setLoading(true)
        setError(null)

        try {
            const response = await axios.post(buildApiUrl("/auth/login"), {
                email,
                password
            }, {
                withCredentials: true
            })

            setLoading(false)
            setUser(response.data.user)
        } catch (err: any) {
            setLoading(false)
            setError(err.response?.data?.error || "Login failed. Please try again.")
        }
    }

    const resetPass = async (oldPassword: string, newPassword: string) => {
        setLoading(true)
        setError(null)

        try {
            const response = await axios.post(buildApiUrl("/auth/reset-password"), {
                oldPassword,
                newPassword
            }, {
                withCredentials: true
            })

            setLoading(false)
            setUser(response.data.user)
            await logout()
        } catch (err: any) {
            setLoading(false)
            setError(err.response?.data?.error || "Password reset failed. Please try again.")
        }
    }


    return (
        <UserContext.Provider value={{ user, loading, error, setUser, logout, register, login, resetPass, setError }}>
            {children}
        </UserContext.Provider>
    );
};

export const useUser = () => {
    const context = useContext(UserContext);
    if (!context) {
        throw new Error("useUser must be used within a UserProvider");
    }
    return context;
};

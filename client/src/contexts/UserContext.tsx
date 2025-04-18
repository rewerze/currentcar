/* eslint-disable react-refresh/only-export-components */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { createContext, useState, useEffect, useContext } from "react";
import axios from "axios";
import { buildApiUrl } from "@/lib/utils";

type UserRole = "admin" | "user";

export type User = {
  user_id: number; // user_id (Primary Key, AUTO_INCREMENT, int(11))
  user_email: string; // user_email (varchar(50))
  user_name: string; // user_name (varchar(35))
  password: string; // password (varchar(70))
  born_at: Date; // born_at (datetime)
  created_at: Date; // created_at (datetime)
  updated_at: Date; // updated_at (datetime)
  user_active: boolean; // user_active (tinyint(1), default: 1)
  u_phone_number: string; // u_phone_number (varchar(20))
  user_areacode: number; // user_areacode (int(11))
  user_role: UserRole; // user_role (enum('admin', 'user'))
  driver_license_number: string; // driver_license_number (varchar(40))
  driver_license_expiry: Date; // driver_license_expiry (date)
  profile_picture: string; // profile_picture (varchar(255))
  user_iban: string; // user_iban (varchar)
};

export type UserContextType = {
  user: User | null;
  loading: boolean;
  error?: string | null;
  setUser?: React.Dispatch<React.SetStateAction<User | null>>;
  logout: () => void;
  register: (
    username: string,
    password: string,
    email: string,
    bornDate: string
  ) => void;
  login: (email: string, password: string) => void;
  resetPass: (
    oldPassword: string,
    newPassword: string,
    passwordAgain: string
  ) => Promise<void>;
  setError: (message: string | null) => void;
  fetchUser: () => void;
};

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(buildApiUrl("/auth/verify"), {
          withCredentials: true,
        });
        setUser(response.data.user);
      } catch (err) {
        setError("");
      } finally {
        setLoading(false);
      }
    };

    fetchUser();
  }, []);

  const fetchUser = async () => {
    try {
      const response = await axios.get(buildApiUrl("/auth/verify"), {
        withCredentials: true,
      });
      setUser(response.data.user);
    } catch (err) {
      setError("");
    } finally {
      setLoading(false);
    }
  };

  const logout = async () => {
    try {
      await axios.post(
        buildApiUrl("/auth/logout"),
        {},
        {
          withCredentials: true,
        }
      );
      setUser(null);
    } catch (err) {
      setError("Error logging out.");
    }
  };

  const register = async (
    username: string,
    password: string,
    email: string,
    bornDate: string
  ) => {
    setLoading(true);
    setError(null);

    try {
      const response = await axios.post(
        buildApiUrl("/auth/register"),
        {
          username,
          password,
          email,
          bornDate,
        },
        {
          withCredentials: true,
        }
      );

      setLoading(false);
      setUser(response.data.user);
    } catch (err: any) {
      setLoading(false);
      setError(
        err.response?.data?.error || "Registration failed. Please try again."
      );
    }
  };

  const login = async (email: string, password: string) => {
    setLoading(true);
    setError(null);

    try {
      const response = await axios.post(
        buildApiUrl("/auth/login"),
        {
          email,
          password,
        },
        {
          withCredentials: true,
        }
      );

      setLoading(false);
      setUser(response.data.user);
    } catch (err: any) {
      setLoading(false);
      setError(err.response?.data?.error || "Login failed. Please try again.");
    }
  };

  const resetPass = async (
    oldPassword: string,
    newPassword: string,
    passwordAgain: string
  ) => {
    setLoading(true);
    setError(null);

    try {
      const response = await axios.post(
        buildApiUrl("/auth/reset-password"),
        {
          oldPassword,
          newPassword,
          passwordAgain,
        },
        {
          withCredentials: true,
        }
      );

      setLoading(false);
      setUser(response.data.user);
      await logout();
    } catch (err: any) {
      setLoading(false);
      setError(
        err.response?.data?.error || "Password reset failed. Please try again."
      );
    }
  };

  return (
    <UserContext.Provider
      value={{
        user,
        loading,
        error,
        setUser,
        logout,
        register,
        login,
        resetPass,
        setError,
        fetchUser
      }}
    >
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

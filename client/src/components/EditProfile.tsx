import { useUser } from "@/contexts/UserContext";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

import cancel_icon from "../assets/img/cancel.svg";
import password_icon from "../assets/img/password.svg";
import save_icon from "../assets/img/save.svg";
import upload_icon from "../assets/img/upload.svg";
import { toast } from "sonner";
import axios from "axios";
import { buildApiUrl } from "@/lib/utils";

function EditProfile() {
  const { user, loading, fetchUser } = useUser();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    user_name: "",
    user_email: "",
    born_at: new Date(),
    u_phone_number: "",
    driver_license_number: "",
    driver_license_expiry: new Date(),
    user_iban: "",
  });

  useEffect(() => {
    if (user) {
      setFormData({
        user_name: user.user_name || "",
        user_email: user.user_email || "",
        born_at: user.born_at || "",
        u_phone_number: user.u_phone_number || "",
        driver_license_number: user.driver_license_number || "",
        driver_license_expiry: user.driver_license_expiry || "",
        user_iban: user.user_iban || "",
      });
    }
  }, [user]);

  useEffect(() => {
    if (!user && !loading) {
      navigate("/register");
    }
  }, [user, loading, navigate]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (Object.keys(formData).length === 0) {
      toast.error("Please provide at least one field to update");
      return;
    }

    if (formData.driver_license_expiry != null) {
      if (new Date(formData.driver_license_expiry).getTime() < new Date().getTime()) {
        toast.error("A jogosítványod lejárati dátuma csak a jövőben lehet!")
        return;
      }
    }

    try {
      const response = await axios.put(buildApiUrl("/profile/edit"), formData, {
        withCredentials: true,
        headers: {
          "Content-Type": "application/json",
        },
      });

      toast.success(response.data.message || "Profile updated successfully");

      fetchUser()
      navigate("/profil");
    } catch (error: unknown) {
      if (axios.isAxiosError(error)) {
        const errorMessage =
          error.response?.data?.error || "Failed to update profile";
        toast.error(errorMessage);
      } else {
        toast.error("An unexpected error occurred");
      }

      console.error("Profile update error:", error);
    }
  };

  if (loading || !user) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <main className="nav-gap">
        <form onSubmit={handleSubmit} className="form">
          <div className="form-box bg-dark">
            <h1>Felhasználói adatok módosítása</h1>

            {/* FELHASZNÁLÓNÉV */}
            <label htmlFor="user_name" className="form-label">
              Felhasználónév:
            </label>
            <input
              type="text"
              name="user_name"
              id="user_name"
              value={formData.user_name}
              onChange={handleChange}
              className="form-control"
            />

            {/* EMAIL CÍM */}
            <label htmlFor="user_email" className="form-label mt-3">
              E-mail cím:
            </label>
            <input
              type="text"
              name="user_email"
              id="user_email"
              disabled
              value={formData.user_email}
              onChange={handleChange}
              className="form-control"
            />

            {/* SZÜLETÉSI DÁTUM */}
            <label htmlFor="born_at" className="form-label mt-3">
              Születési dátum:
            </label>
            <input
              type="text"
              name="born_at"
              id="born_at"
              value={
                formData.born_at
                  ? new Date(formData.born_at).toLocaleString("hu-HU", {
                    year: "numeric",
                    month: "numeric",
                    day: "numeric",
                  })
                  : ""
              }
              disabled
              className="form-control"
            />

            {/* TELEFONSZÁM */}
            <label htmlFor="u_phone_number" className="form-label mt-3">
              Telefonszám:
            </label>
            <input
              type="text"
              name="u_phone_number"
              id="u_phone_number"
              placeholder="+36xx xxx xxxx"
              value={formData.u_phone_number}
              onChange={handleChange}
              className="form-control"
            />

            {/* Jogosítvány szám */}
            <label htmlFor="driver_license_number" className="form-label mt-3">
              Jogosítvány szám:
            </label>
            <input
              type="text"
              name="driver_license_number"
              id="driver_license_number"
              value={formData.driver_license_number}
              onChange={handleChange}
              className="form-control"
            />

            {/* Jogosítvány lejárati dátuma */}
            <label htmlFor="driver_license_expiry" className="form-label mt-3">
              Jogosítvány lejárati dátuma:
            </label>
            <input
              type="date"
              name="driver_license_expiry"
              id="driver_license_expiry"
              onChange={handleChange}
              className="form-control"
            />

            {/* IBAN SZÁM */}
            <label htmlFor="user_iban" className="form-label mt-3">
              IBAN:
            </label>
            <input
              type="text"
              name="user_iban"
              id="user_iban"
              value={formData.user_iban}
              onChange={handleChange}
              className="form-control"
            />

            <div className="d-flex justify-content-center mt-5 gap-3 icon-left edit-buttons">
              <a href="/profil/profilkep" className="btn btn-light w-25">
                <span>
                  <img src={upload_icon} className="icon icon-small" />
                </span>
                <span>Profilkép csere</span>
              </a>
              <a
                href="/profil/jelszo-modositas"
                className="btn btn-warning w-25"
              >
                <span>
                  <img src={password_icon} className="icon icon-small" />
                </span>
                <span>Jelszó módosítása</span>
              </a>
              <button type="submit" className="btn btn-success w-25">
                <span>
                  <img src={save_icon} className="icon icon-small" />
                </span>
                <span>Adatok mentése</span>
              </button>
              <a href="./" className="btn btn-danger w-25">
                <span>
                  <img src={cancel_icon} className="icon icon-small" />
                </span>
                <span>Elvetés</span>
              </a>
            </div>
          </div>
        </form>
      </main>
    </>
  );
}

export default EditProfile;

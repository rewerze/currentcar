import { useEffect, useState } from "react";
import cancel_icon from "../assets/img/cancel.svg";
import save_icon from "../assets/img/save.svg";
import { buildApiUrl } from "@/lib/utils";
import { useUser } from "@/contexts/UserContext";
import { useLanguage } from "@/contexts/LanguageContext";
import { CarInfo } from "./interfaces/Car";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "sonner";
import { format } from 'react-string-format';
import axios from "axios";

function EditCar() {
  const { user, loading } = useUser();
  const { t, loadNamespace, loadedNamespaces } = useLanguage();
  const { id } = useParams<{ id: string }>();
  const [car, setCarInfo] = useState<CarInfo | null>(null);
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    car_id: "",
    car_price: "",
    car_description: "",
    car_type: "",
    seats: "",
    number_of_doors: "",
    insurance_id: "",
    car_model: "",
    car_regnumber: "",
    price_per_hour: "",
    price_per_day: "",
    car_condition: "",
    mileage: "",
    car_year: "",
    fuel_type: "",
    transmission_type: "",
    car_brand: "",
    available_until: "",
    extras: ""
  });

  useEffect(() => {
    if (!user && !loading) {
      navigate('/')
    }
  }, [user, loading, navigate]);

  useEffect(() => {
    if (!loadedNamespaces.includes("EditCar")) {
      loadNamespace("EditCar");
    }
  }, [loadedNamespaces, loadNamespace]);

  useEffect(() => {
    const fetchCarData = async () => {
      try {
        const response = await fetch(buildApiUrl(`/car?id=${id}`), {
          credentials: "include",
        });

        if (!response.ok) {
          throw new Error(`Failed to fetch car data: ${response.status}`);
        }

        const data = await response.json();
        setCarInfo(data);

        // Populate form data from fetched car data
        setFormData({
          car_id: data.car_id || "",
          car_price: data.car_price || "",
          car_description: data.car_description || "",
          car_type: data.car_type || "",
          seats: data.seats || "",
          number_of_doors: data.number_of_doors || "",
          insurance_id: data.insurance_id || "",
          car_model: data.car_model || "",
          car_regnumber: data.car_regnumber || "",
          price_per_hour: data.price_per_hour || "",
          price_per_day: data.price_per_day || "",
          car_condition: data.car_condition || "",
          mileage: data.mileage || "",
          car_year: data.car_year || "",
          fuel_type: data.fuel_type || "",
          transmission_type: data.transmission_type || "",
          car_brand: data.car_brand || "",
          available_until: data.available_until || "",
          extras: data.extras || ""
        });
      } catch (error) {
        console.error(error);
        toast.error(t("errorFetchingCar", "EditCar"));
      }
    };

    if (id) {
      fetchCarData();
    }
  }, [id, t]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value, type } = e.target as HTMLInputElement;

    setFormData((prevData) => ({
      ...prevData,
      [name]: type === 'checkbox' ? (e.target as HTMLInputElement).checked : value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Basic validation
    if (!formData.price_per_hour || !formData.price_per_day) {
      toast.error(t("priceRequired", "EditCar") || "Hourly and daily prices are required");
      return;
    }

    if (!formData.car_description || formData.car_description.length < 10) {
      toast.error(t("descriptionTooShort", "EditCar") || "Description is too short");
      return;
    }

    // Create the payload with only the fields we want to update
    const updatePayload = {
      car_id: formData.car_id,
      car_description: formData.car_description,
      price_per_hour: formData.price_per_hour,
      price_per_day: formData.price_per_day,
      available_until: formData.available_until,
      extras: formData.extras,
    };

    try {
      await axios.put(buildApiUrl("/car/edit"), updatePayload, {
        withCredentials: true,
        headers: {
          "Content-Type": "application/json",
        },
      });

      toast.success(t("carUpdatedSuccess", "EditCar") || "Car updated successfully");
      navigate("/profil");
    } catch (error: unknown) {
      if (axios.isAxiosError(error)) {
        const errorMessage =
          error.response?.data?.error || t("failedToUpdateCar", "EditCar") || "Failed to update car";
        toast.error(errorMessage);
      } else {
        toast.error(t("unexpectedError", "EditCar") || "An unexpected error occurred");
      }

      console.error("Car update error:", error);
    }
  };

  if (loading || !car) {
    return <div>{t("loading", "EditCar") || "Loading..."}</div>;
  }

  return (
    <>
      <main className="nav-gap">
        <form onSubmit={handleSubmit} className="form">
          <div className="form-box bg-dark">
            <h1>{format(t('edit_car', 'EditCar'), car?.car_brand, car?.car_model)}</h1>

            {/* Árak */}
            <div className="car-edit">
              
            <div className="w-100">
                <label htmlFor="base_price" className="form-label">
                  Napi ár
                </label>
                <input
                  type="number"
                  name="base_price"
                  id="base_price"
                  className="form-control"
                  // placeholder={t('daily_price', 'EditCar')}
                  // value={formData.price_per_day}
                  onChange={handleChange}
                />
              </div>

              <div className="w-100">
                <label htmlFor="price_per_hour" className="form-label">
                  {t('hourly_price', 'EditCar')}
                </label>
                <input
                  type="number"
                  name="price_per_hour"
                  id="price_per_hour"
                  className="form-control"
                  placeholder={t('hourly_price', 'EditCar')}
                  value={formData.price_per_hour}
                  onChange={handleChange}
                />
              </div>

              <div className="w-100">
                <label htmlFor="price_per_day" className="form-label">
                  {t('daily_price', 'EditCar')}
                </label>
                <input
                  type="number"
                  name="price_per_day"
                  id="price_per_day"
                  className="form-control"
                  placeholder={t('daily_price', 'EditCar')}
                  value={formData.price_per_day}
                  onChange={handleChange}
                />
              </div>
            </div>

            {/* MEDDIG + EXTRA */}
            <div className="car-edit mt-1">
              <div className="w-100">
                <label htmlFor="available_until" className="form-label">
                  {t('until_when', 'EditCar')}
                </label>
                <input
                  type="date"
                  name="available_until"
                  max="9999-12-31"
                  id="available_until"
                  className="form-control"
                  value={formData.available_until}
                  onChange={handleChange}
                />
              </div>
            </div>

            {/* LEÍRÁS */}
            <div className="car-edit mt-1">
              <div className="w-100">
                <label htmlFor="car_description">{t('description', 'EditCar')}</label>
                <textarea
                  name="car_description"
                  id="car_description"
                  className="form-control"
                  rows={3}
                  value={formData.car_description}
                  onChange={handleChange}
                ></textarea>
              </div>
            </div>

            {/* GOMBOK */}
            <div className="d-flex justify-content-center mt-5 gap-3 icon-left edit-buttons">
              <button type="submit" className="btn btn-success w-50">
                <span>
                  <img src={save_icon} className="icon icon-small" alt="Save" />
                </span>
                <span>{t('save_data', 'EditCar')}</span>
              </button>
              <a href="/profil" className="btn btn-danger w-50">
                <span>
                  <img src={cancel_icon} className="icon icon-small" alt="Cancel" />
                </span>
                <span>{t('cancel', 'EditCar')}</span>
              </a>
            </div>
          </div>
        </form>
      </main>
    </>
  );
}

export default EditCar;
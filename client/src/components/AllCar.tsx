import { useState, useEffect, ChangeEvent, FormEvent } from "react";
import carDefaultImage from "../assets/img/nepszeru_auto.png";
import { FilterState } from "./interfaces/FilterState";
import { CarInfo as Car } from "./interfaces/Car";
import { useLanguage } from "@/contexts/LanguageContext";
import translations from "./translations/API";

function AllCar() {
  const { t, loadedNamespaces, loadNamespace } = useLanguage();

  useEffect(() => {
    if (!loadedNamespaces.includes("AllCar")) {
      loadNamespace("AllCar");
    }
  }, [loadedNamespaces, loadNamespace]);
  const [cars, setCars] = useState<Car[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [filters, setFilters] = useState<FilterState>({
    search: "",
    brand: "Összes",
    type: "Összes",
    condition: "Összes",
    transmission: "Összes",
    fuel: "Összes",
    year: "Összes",
  });
  const filterKeys = ["search", "brand", "type", "condition", "transmission", "fuel", "year"] as const;
  const defaultValues = ["Összes", "All"];
  type FilterKey = (typeof filterKeys)[number];

  const buildApiUrl = (endpoint: string) => {
    const baseUrl =
      process.env.NODE_ENV !== "production"
        ? "http://localhost:3000"
        : window.location.origin;
    return `${baseUrl}/api${endpoint}`;
  };

  const getTranslatedFilterValue = (category: keyof typeof translations, value: string) => {
    if (filterKeys.includes(category as FilterKey)) {
      const key = category as FilterKey;
      const filterValue = filters[key];

      if (!filterValue) return value;

      const translationCategory = translations[category] as { [key: string]: string };
      if (translationCategory && typeof translationCategory === "object" && filterValue in translationCategory) {
        return translationCategory[filterValue];
      }
    }
    return value;
  };

  useEffect(() => {
    const fetchCars = async () => {
      try {
        setLoading(true);

        // Construct query parameters for filtering
        const queryParams = new URLSearchParams();

        if (filters.search) {
          queryParams.append("q", filters.search);
        }

        Object.entries(filters).forEach(([key, value]) => {
          if (!defaultValues.includes(value)) {
            queryParams.append(key, getTranslatedFilterValue(key as keyof typeof translations, value));
          }
        });

        console.log(queryParams.toString());

        const queryString = queryParams.toString();
        const endpoint = queryString ? `/cars/search?${queryString}` : `/cars`;

        const response = await fetch(buildApiUrl(endpoint), {
          credentials: "include",
        });

        if (!response.ok) {
          throw new Error("Network response was not ok");
        }

        const data: Car[] = await response.json();
        console.log("Fetched cars data:", data);
        setCars(data);
        setLoading(false);
      } catch (error) {
        setError((error as Error).message);
        setLoading(false);
      }
    };

    fetchCars();
  }, [filters]);

  const handleFilterChange = (e: ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFilters((prevFilters) => ({
      ...prevFilters,
      [name]: value,
    }));
  };

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFilters((prevFilters) => ({
      ...prevFilters,
      search: e.target.value,
    }));
  };

  const formatPrice = (price: string | number): string => {
    return Number(price).toLocaleString("hu-HU") + " Ft";
  };

  const getUniqueOptions = (field: keyof Car): string[] => {
    if (!cars.length) return [];
    const options = [
      ...new Set(
        cars
          .map((car) => car[field])
          .filter((value) => value !== undefined && value !== null)
          .map((value) => String(value))
      ),
    ];
    return options;
  };

  return (
    <>
      <main className="nav-gap">
        <h1 className="text-center">{t('allCars', 'AllCar')}</h1>

        <form
          action="/osszesauto"
          onSubmit={(e: FormEvent) => e.preventDefault()}
        >
          <div className="search">
            {/* KERESÉS */}
            <div className="d-flex justify-content-center mb-3 mx-auto gap-3">
              <input
                type="text"
                id="search-box"
                name="search"
                className="form-control w-50"
                placeholder={t('search', 'AllCar') + "..."}
                value={filters.search}
                onChange={handleSearchChange}
              />
              <button className="btn btn-danger" onClick={() => {
                setFilters(({
                  search: "",
                  brand: "Összes",
                  type: "Összes",
                  condition: "Összes",
                  transmission: "Összes",
                  fuel: "Összes",
                  year: "Összes",
                }));
              }}>{t('clear', 'AllCar')}</button>
            </div>

            {/* SZŰRÉS */}
            <div className="filter d-flex justify-content-center gap-2 w-100 mx-auto">
              <div className="w-25">
                <label htmlFor="brand">{t('brand', 'AllCar')}</label>
                <select
                  name="brand"
                  id="brand"
                  className="form-select"
                  value={filters.brand}
                  onChange={handleFilterChange}
                >
                  <option>{t('all', 'AllCar')}</option>
                  {getUniqueOptions("car_brand").map((brand, index) => (
                    <option key={index} value={brand}>
                      {brand}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="type">{t('type', 'AllCar')}</label>
                <select
                  name="type"
                  id="type"
                  className="form-select"
                  value={filters.type}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", 'AllCar')}</option>
                  {getUniqueOptions("car_type").map((type, index) => (
                    <option key={index} value={type}>
                      {t(type, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="condition">{t('condition', 'AllCar')}</label>
                <select
                  name="condition"
                  id="condition"
                  className="form-select"
                  value={filters.condition}
                  onChange={handleFilterChange}
                >
                  <option>{t('all', 'AllCar')}</option>
                  {getUniqueOptions("car_condition").map((condition, index) => (
                    <option key={index} value={condition}>
                      {t(condition, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
            </div>

            <div className="filter d-flex justify-content-center gap-2 w-100 mt-2 mx-auto">
              <div className="w-25">
                <label htmlFor="transmission">{t('transmission', 'AllCar')}</label>
                <select
                  name="transmission"
                  id="transmission"
                  className="form-select"
                  value={filters.transmission}
                  onChange={handleFilterChange}
                >
                  <option>{t('all', 'AllCar')}</option>
                  {getUniqueOptions("transmission_type").map(
                    (transmission, index) => (
                      <option key={index} value={transmission}>
                        {t(transmission, "AllCar")}
                      </option>
                    )
                  )}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="fuel">{t('fuel', 'AllCar')}</label>
                <select
                  name="fuel"
                  id="fuel"
                  className="form-select"
                  value={filters.fuel}
                  onChange={handleFilterChange}
                >
                  <option>{t('all', 'AllCar')}</option>
                  {getUniqueOptions("fuel_type").map((fuel, index) => (
                    <option key={index} value={fuel}>
                      {t(fuel, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="year">{t('year', 'AllCar')}</label>
                <select
                  name="year"
                  id="year"
                  className="form-select"
                  value={filters.year}
                  onChange={handleFilterChange}
                >
                  <option>{t('all', 'AllCar')}</option>
                  {getUniqueOptions("car_year").map((year, index) => (
                    <option key={index} value={year}>
                      {year}
                    </option>
                  ))}
                </select>
              </div>
            </div>
          </div>
        </form>

        {loading ? (
          <div className="text-center mt-5">
            <p>{t('loading', 'AllCar')}...</p>
          </div>
        ) : error ? (
          <div className="text-center mt-5">
            <p>{t('error', 'AllCar')}: {error}</p>
          </div>
        ) : (
          <div className="cars mt-5 d-flex flex-wrap justify-content-center gap-4">
            {cars.length > 0 ? (
              cars.map((car) => (
                <div className="car-box bg-dark" key={car.car_id}>
                  <a href={`/adatlap/${car.car_id}`} className="off-link">
                    <div>
                      <p className="text-center">
                        <img
                          src={car.image || carDefaultImage}
                          alt={`${car.car_brand} ${car.car_model}`}
                          className="car-image"
                        />
                      </p>
                    </div>
                    <div className="text-center p-3">
                      <h3>
                        {car.car_brand} {car.car_model}
                      </h3>
                      <p className="text-truncate mb-2">
                        {car.car_description}
                      </p>

                      <div className="d-flex justify-content-between">
                        <span className="badge bg-primary">{car.car_year}</span>
                        <span className="badge bg-secondary">
                          {t(car.car_type, "car_type")}
                        </span>
                        <span className="badge bg-info">
                          {t(car.car_condition, "AllCar")}
                        </span>
                      </div>

                      <div className="d-flex justify-content-between mt-2">
                        <span className="badge bg-success">
                          {t(car.fuel_type, "AllCar")}
                        </span>
                        <span className="badge bg-warning text-dark">
                          {t(car.transmission_type, "AllCar")}
                        </span>
                      </div>

                      <div className="d-flex justify-content-between align-items-center mt-3">
                        <small>{t('seats', 'AllCar')}: {car.seats}</small>
                        <small>{t('doors', 'AllCar')}: {car.number_of_doors}</small>
                        <small>{car.mileage.toLocaleString()} km</small>
                      </div>

                      <hr className="my-2 border-secondary" />

                      <div className="d-flex justify-content-between">
                        <div className="text-start">
                          <div>
                            <small>
                              {t('hour', 'AllCar')}: {formatPrice(car.price_per_hour)}
                            </small>
                          </div>
                          <div>
                            <small>{t('day', 'AllCar')}: {formatPrice(car.price_per_day)}</small>
                          </div>
                        </div>
                        <div className="text-end">
                          <strong className="text-success">
                            {formatPrice(car.car_price)}
                          </strong>
                        </div>
                      </div>
                    </div>
                  </a>
                </div>
              ))
            ) : (
              <div className="text-center w-100">
                <p>{t('noResults', 'AllCar')}</p>
              </div>
            )}
          </div>
        )}
      </main>
    </>
  );
}

export default AllCar;

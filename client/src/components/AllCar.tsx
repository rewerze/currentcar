import { useState, useEffect, ChangeEvent, FormEvent, useRef } from "react";
import carDefaultImage from "../assets/img/nepszeru_auto.png";
import { FilterState } from "./interfaces/FilterState";
import { CarInfo as Car } from "./interfaces/Car";
import { useLanguage } from "@/contexts/LanguageContext";
import translations from "./translations/API";
import { buildApiUrl } from "@/lib/utils";

interface PaginationData {
  total: number;
  totalPages: number;
  currentPage: number;
  limit: number;
}

interface ApiResponse {
  data: Car[];
  pagination: PaginationData;
}

function AllCar() {
  const { t, loadedNamespaces, loadNamespace } = useLanguage();

  useEffect(() => {
    if (!loadedNamespaces.includes("AllCar")) {
      loadNamespace("AllCar");
    }
  }, [loadedNamespaces, loadNamespace]);

  const [cars, setCars] = useState<Car[]>([]);
  // Store all available options from initial load
  const [allOptions, setAllOptions] = useState<Record<string, string[]>>({
    car_brand: [],
    car_type: [],
    car_condition: [],
    transmission_type: [],
    fuel_type: [],
    car_year: [],
  });
  // Store dynamically filtered options based on selected filters
  const [filteredOptions, setFilteredOptions] = useState<Record<string, string[]>>({
    car_brand: [],
    car_type: [],
    car_condition: [],
    transmission_type: [],
    fuel_type: [],
    car_year: [],
  });
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  // Store all cars data for client-side filtering
  const allCarsRef = useRef<Car[]>([]);

  const [pagination, setPagination] = useState<PaginationData>({
    total: 0,
    totalPages: 0,
    currentPage: 1,
    limit: 12
  });

  const [filters, setFilters] = useState<FilterState>({
    search: "",
    brand: "Összes",
    type: "Összes",
    condition: "Összes",
    transmission: "Összes",
    fuel: "Összes",
    year: "Összes",
  });

  const filterKeys = [
    "search",
    "brand",
    "type",
    "condition",
    "transmission",
    "fuel",
    "year",
  ] as const;

  const defaultValues = ["Összes", "All"];
  type FilterKey = (typeof filterKeys)[number];

  const getTranslatedFilterValue = (
    category: keyof typeof translations,
    value: string
  ) => {
    if (filterKeys.includes(category as FilterKey)) {
      const key = category as FilterKey;
      const filterValue = filters[key];

      if (!filterValue) return value;

      const translationCategory = translations[category] as {
        [key: string]: string;
      };
      if (
        translationCategory &&
        typeof translationCategory === "object" &&
        filterValue in translationCategory
      ) {
        return translationCategory[filterValue];
      }
    }
    return value;
  };

  // This function gets all available unique options from the initial data load
  const extractUniqueOptions = (data: Car[]) => {
    const options: Record<string, string[]> = {
      car_brand: [],
      car_type: [],
      car_condition: [],
      transmission_type: [],
      fuel_type: [],
      car_year: [],
    };

    Object.keys(options).forEach(field => {
      const fieldOptions = [...new Set(
        data
          .map((car) => car[field as keyof Car])
          .filter((value) => value !== undefined && value !== null)
          .map((value) => String(value))
      )];
      options[field as keyof typeof options] = fieldOptions;
    });

    return options;
  };

  const fetchCars = async (page = 1, isInitialLoad = false) => {
    try {
      setLoading(true);

      const queryParams = new URLSearchParams();

      queryParams.append("page", page.toString());
      queryParams.append("limit", pagination.limit.toString());

      if (filters.search) {
        queryParams.append("q", filters.search);
      }

      Object.entries(filters).forEach(([key, value]) => {
        if (!defaultValues.includes(value)) {
          queryParams.append(
            key,
            getTranslatedFilterValue(key as keyof typeof translations, value)
          );
        }
      });

      console.log(queryParams.toString());

      const queryString = queryParams.toString();
      const endpoint = `/cars/search?${queryString}`;

      const response = await fetch(buildApiUrl(endpoint), {
        credentials: "include",
      });

      if (!response.ok) {
        throw new Error("Network response was not ok");
      }

      const result: ApiResponse = await response.json();
      console.log("Fetched cars data:", result);

      setCars(result.data);
      setPagination(result.pagination);

      // On initial load, store all possible filter options
      if (isInitialLoad && result.data.length > 0) {
        setAllOptions(extractUniqueOptions(result.data));
      }

      setLoading(false);
    } catch (error) {
      setError((error as Error).message);
      setLoading(false);
    }
  };

  // Function to update available options based on current filter selection
  const updateFilteredOptions = (currentFilters: FilterState) => {
    // Skip if we don't have all cars data yet
    if (allCarsRef.current.length === 0) return;
    
    // Start with all cars
    let filteredCars = [...allCarsRef.current];
    
    // Apply each active filter
    if (currentFilters.brand !== "Összes" && currentFilters.brand !== "All") {
      filteredCars = filteredCars.filter(car => car.car_brand === currentFilters.brand);
    }
    
    if (currentFilters.type !== "Összes" && currentFilters.type !== "All") {
      filteredCars = filteredCars.filter(car => car.car_type === currentFilters.type);
    }
    
    if (currentFilters.condition !== "Összes" && currentFilters.condition !== "All") {
      filteredCars = filteredCars.filter(car => car.car_condition === currentFilters.condition);
    }
    
    if (currentFilters.transmission !== "Összes" && currentFilters.transmission !== "All") {
      filteredCars = filteredCars.filter(car => car.transmission_type === currentFilters.transmission);
    }
    
    if (currentFilters.fuel !== "Összes" && currentFilters.fuel !== "All") {
      filteredCars = filteredCars.filter(car => car.fuel_type === currentFilters.fuel);
    }
    
    if (currentFilters.year !== "Összes" && currentFilters.year !== "All") {
      filteredCars = filteredCars.filter(car => String(car.car_year) === currentFilters.year);
    }
    
    // Extract available options from the filtered cars
    setFilteredOptions(extractUniqueOptions(filteredCars));
  };

  // Initial load to get all available options
  useEffect(() => {
    // On component mount, fetch all cars to get complete option lists
    const fetchAllOptions = async () => {
      try {
        const response = await fetch(buildApiUrl("/cars/search?limit=1000"), {
          credentials: "include",
        });
        
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        
        const result: ApiResponse = await response.json();
        
        // Store all cars for client-side filtering
        allCarsRef.current = result.data;
        
        // Store all possible filter options
        if (result.data.length > 0) {
          const options = extractUniqueOptions(result.data);
          setAllOptions(options);
          setFilteredOptions(options); // Initially, filtered options are the same as all options
        }
        
        // Proceed with normal fetch for the first page with filters
        fetchCars(1);
      } catch (error) {
        setError((error as Error).message);
        setLoading(false);
      }
    };
    
    fetchAllOptions();
  }, []);

  // This effect handles filter changes
  useEffect(() => {
    fetchCars(1);
  }, [filters]);

  const handlePageChange = (page: number) => {
    if (page < 1 || page > pagination.totalPages) return;
    fetchCars(page);
  };

  const handleFilterChange = (e: ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFilters((prevFilters) => {
      const newFilters = {
        ...prevFilters,
        [name]: value,
      };
      
      // Update available options based on the new filter selection
      updateFilteredOptions(newFilters);
      
      return newFilters;
    });
  };

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFilters((prevFilters) => {
      const newFilters = {
        ...prevFilters,
        search: e.target.value,
      };
      
      // We don't update filtered options based on search text
      // since search is handled by the server and not used for client-side filtering
      
      return newFilters;
    });
  };

  const formatPrice = (price: string | number): string => {
    return Number(price).toLocaleString("hu-HU") + " Ft";
  };

  // Get options from the filtered list if available, otherwise fall back to all options
  const getOptions = (field: keyof typeof allOptions): string[] => {
    // If a filter is applied, return the filtered options for other dropdowns
    // except for the current one that's being changed
    
    // Map the field name to the corresponding filter key
    const filterFieldMap: Record<string, keyof FilterState> = {
      car_brand: 'brand',
      car_type: 'type',
      car_condition: 'condition',
      transmission_type: 'transmission',
      fuel_type: 'fuel',
      car_year: 'year'
    };
    
    const filterKey = filterFieldMap[field];
    
    // For the current filter being changed, show all options
    // For example, if user has selected a Brand and is now looking at Fuel options,
    // show only fuels available for that brand
    if (filterKey && filters[filterKey] === "Összes" || filters[filterKey] === "All") {
      // For filters that are "All", show filtered options based on other selections
      return filteredOptions[field] || [];
    } else if (filterKey) {
      // For the specific filter being changed (like brand), always show all options
      // This allows changing from one brand to another directly
      return allOptions[field] || [];
    }
    
    return allOptions[field] || [];
  };

  const Pagination = () => {
    const { totalPages, currentPage } = pagination;

    if (totalPages <= 1) return null;

    let startPage = Math.max(1, currentPage - 2);
    const endPage = Math.min(totalPages, startPage + 4);

    if (endPage - startPage < 4) {
      startPage = Math.max(1, endPage - 4);
    }

    const pages = Array.from({ length: endPage - startPage + 1 }, (_, i) => startPage + i);

    return (
      <div aria-label="Page navigation" className="mt-4">
        <ul className="pagination justify-content-center">
          <li className={`page-item ${currentPage === 1 ? 'disabled' : ''}`}>
            <button
              className="page-link"
              onClick={() => handlePageChange(currentPage - 1)}
              disabled={currentPage === 1}
            >
              &laquo;
            </button>
          </li>

          {startPage > 1 && (
            <>
              <li className="page-item">
                <button className="page-link" onClick={() => handlePageChange(1)}>1</button>
              </li>
              {startPage > 2 && (
                <li className="page-item disabled">
                  <span className="page-link">...</span>
                </li>
              )}
            </>
          )}

          {pages.map(page => (
            <li key={page} className={`page-item ${currentPage === page ? 'active' : ''}`}>
              <button
                className="page-link"
                onClick={() => handlePageChange(page)}
              >
                {page}
              </button>
            </li>
          ))}

          {endPage < totalPages && (
            <>
              {endPage < totalPages - 1 && (
                <li className="page-item disabled">
                  <span className="page-link">...</span>
                </li>
              )}
              <li className="page-item">
                <button className="page-link" onClick={() => handlePageChange(totalPages)}>
                  {totalPages}
                </button>
              </li>
            </>
          )}

          <li className={`page-item ${currentPage === totalPages ? 'disabled' : ''}`}>
            <button
              className="page-link"
              onClick={() => handlePageChange(currentPage + 1)}
              disabled={currentPage === totalPages}
            >
              &raquo;
            </button>
          </li>
        </ul>
      </div>
    );
  };

  return (
    <>
      <main className="nav-gap">
        <h1 className="text-center">{t("allCars", "AllCar")}</h1>

        <form
          action="/osszesauto"
          onSubmit={(e: FormEvent) => e.preventDefault()}
        >
          <div className="search">
            { }
            <div className="d-flex justify-content-center mb-3 mx-auto gap-3">
              <input
                type="text"
                id="search-box"
                name="search"
                className="form-control w-50"
                placeholder={t("search", "AllCar") + "..."}
                value={filters.search}
                onChange={handleSearchChange}
              />
                              <button
                className="btn btn-danger"
                onClick={() => {
                  // Reset all filters
                  const resetFilters = {
                    search: "",
                    brand: "Összes",
                    type: "Összes",
                    condition: "Összes",
                    transmission: "Összes",
                    fuel: "Összes",
                    year: "Összes",
                  };
                  
                  setFilters(resetFilters);
                  
                  // Reset filtered options to all options
                  setFilteredOptions({...allOptions});
                }}
              >
                {t("clear", "AllCar")}
              </button>
            </div>

            { }
            <div className="filter d-flex justify-content-center gap-2 w-100 mx-auto">
              <div className="w-25">
                <label htmlFor="brand">{t("brand", "AllCar")}</label>
                <select
                  name="brand"
                  id="brand"
                  className="form-select"
                  value={filters.brand}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("car_brand").map((brand, index) => (
                    <option key={index} value={brand}>
                      {brand}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="type">{t("type", "AllCar")}</label>
                <select
                  name="type"
                  id="type"
                  className="form-select"
                  value={filters.type}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("car_type").map((type, index) => (
                    <option key={index} value={type}>
                      {t(type, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="condition">{t("condition", "AllCar")}</label>
                <select
                  name="condition"
                  id="condition"
                  className="form-select"
                  value={filters.condition}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("car_condition").map((condition, index) => (
                    <option key={index} value={condition}>
                      {t(condition, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
            </div>

            <div className="filter d-flex justify-content-center gap-2 w-100 mt-2 mx-auto">
              <div className="w-25">
                <label htmlFor="transmission">
                  {t("transmission", "AllCar")}
                </label>
                <select
                  name="transmission"
                  id="transmission"
                  className="form-select"
                  value={filters.transmission}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("transmission_type").map(
                    (transmission, index) => (
                      <option key={index} value={transmission}>
                        {t(transmission, "AllCar")}
                      </option>
                    )
                  )}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="fuel">{t("fuel", "AllCar")}</label>
                <select
                  name="fuel"
                  id="fuel"
                  className="form-select"
                  value={filters.fuel}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("fuel_type").map((fuel, index) => (
                    <option key={index} value={fuel}>
                      {t(fuel, "AllCar")}
                    </option>
                  ))}
                </select>
              </div>
              <div className="w-25">
                <label htmlFor="year">{t("year", "AllCar")}</label>
                <select
                  name="year"
                  id="year"
                  className="form-select"
                  value={filters.year}
                  onChange={handleFilterChange}
                >
                  <option>{t("all", "AllCar")}</option>
                  {getOptions("car_year").map((year, index) => (
                    <option key={index} value={year}>
                      {year}
                    </option>
                  ))}
                </select>
              </div>
            </div>
          </div>
        </form>

        { }
        {loading ? (
          <div className="text-center mt-5">
            <p>{t("loading", "AllCar")}...</p>
          </div>
        ) : error ? (
          <div className="text-center mt-5">
            <p>
              {t("error", "AllCar")}: {error}
            </p>
          </div>
        ) : (
          <>
            <div className="cars mt-5 d-flex flex-wrap justify-content-center gap-4">
              {cars.length > 0 ? (
                cars.map((car) => (
                  <div className="car-box bg-dark" key={car.car_id}>
                    <a href={`/adatlap/${car.car_id}`} className="off-link">
                      <div>
                        <p className="text-center car-image">
                          <img
                            src={
                              car.car_id
                                ? `${import.meta.env.PROD ? "/api" : "http://localhost:3000/api"}/getCarImage?car_id=${car.car_id}`
                                : carDefaultImage
                            }
                            alt={`${car.car_brand} ${car.car_model}`}
                            onError={(e) => {
                              (e.target as HTMLImageElement).src = carDefaultImage;
                            }}
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
                            {t(car.car_type, "AllCar")}
                          </span>
                          <span className="badge bg-info text-dark">
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
                          <small>
                            {t("seats", "AllCar")}: {car.seats}
                          </small>
                          <small>
                            {t("doors", "AllCar")}: {car.number_of_doors}
                          </small>
                          <small>{car.mileage.toLocaleString()} km</small>
                        </div>

                        <hr className="my-2 border-secondary" />

                        <div className="d-flex justify-content-between">
                          <div className="text-start">
                            <div>
                              <small>
                                {t("hour", "AllCar")}:{" "}
                                {formatPrice(car.price_per_hour)}
                              </small>
                            </div>
                            <div>
                              <small>
                                {t("day", "AllCar")}:{" "}
                                {formatPrice(car.price_per_day)}
                              </small>
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
                  <p>{t("noResults", "AllCar")}</p>
                </div>
              )}
            </div>

            { }
            <Pagination />
            { }
            {cars.length > 0 && (
              <div className="text-center mt-3">
                <p>
                  {t("showing", "AllCar")} {(pagination.currentPage - 1) * pagination.limit + 1}-
                  {Math.min(pagination.currentPage * pagination.limit, pagination.total)} {t("of", "AllCar")} {pagination.total} {t("results", "AllCar")}
                </p>
              </div>
            )}
          </>
        )}
      </main>
    </>
  );
}

export default AllCar;
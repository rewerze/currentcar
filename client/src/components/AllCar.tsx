import { useState, useEffect, ChangeEvent, FormEvent } from 'react';
import carDefaultImage from "../assets/img/nepszeru_auto.png";
import { FilterState } from './interfaces/FilterState';
import { Car } from './interfaces/Car';
import { translations } from './translations/AllCar';


function AllCar() {
    const [cars, setCars] = useState<Car[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [filters, setFilters] = useState<FilterState>({
        search: '',
        brand: 'Összes',
        type: 'Összes',
        condition: 'Összes',
        transmission: 'Összes',
        fuel: 'Összes',
        year: 'Összes'
    });

    const buildApiUrl = (endpoint: string) => {
        const baseUrl = process.env.NODE_ENV !== "production" ? "http://localhost:3000" : window.location.origin;
        return `${baseUrl}/api${endpoint}`;
    };

    useEffect(() => {
        const fetchCars = async () => {
            try {
                setLoading(true);
                
                // Construct query parameters for filtering
                const queryParams = new URLSearchParams();
                
                if (filters.search) {
                    queryParams.append('q', filters.search);
                }
                
                if (filters.brand !== 'Összes') {
                    queryParams.append('brand', filters.brand);
                }
                
                if (filters.type !== 'Összes') {
                    queryParams.append('type', filters.type);
                }
                
                if (filters.condition !== 'Összes') {
                    queryParams.append('condition', filters.condition);
                }
                
                if (filters.transmission !== 'Összes') {
                    queryParams.append('transmission', filters.transmission);
                }
                
                if (filters.fuel !== 'Összes') {
                    queryParams.append('fuel', filters.fuel);
                }
                
                if (filters.year !== 'Összes') {
                    queryParams.append('year', filters.year);
                }
                
                const queryString = queryParams.toString();
                const endpoint = queryString ? `/cars/search?${queryString}` : `/cars`;
                
                const response = await fetch(buildApiUrl(endpoint), {
                    credentials: "include"
                });
                
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                
                const data: Car[] = await response.json();
                console.log('Fetched cars data:', data);
                setCars(data);
                setLoading(false);
            } catch (error) {
                setError((error as Error).message);
                setLoading(false);
            }
        };

        fetchCars();
    }, [filters]);

    // Handle filter changes
    const handleFilterChange = (e: ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFilters(prevFilters => ({
            ...prevFilters,
            [name]: value
        }));
    };

    // Handle search input
    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFilters(prevFilters => ({
            ...prevFilters,
            search: e.target.value
        }));
    };

    const formatPrice = (price: string | number): string => {
        return Number(price).toLocaleString('hu-HU') + ' Ft';
    };
    
    const translate = (category: keyof typeof translations, value: string): string => {
        return translations[category][value as keyof typeof translations[typeof category]] || value;
    };

    const getUniqueOptions = (field: keyof Car): string[] => {
        if (!cars.length) return [];
        const options = [...new Set(cars
            .map(car => car[field])
            .filter(value => value !== undefined && value !== null)
            .map(value => String(value))
        )];
        return options;
    };

    return (
        <>
        <main className="nav-gap">
            <h1 className="text-center">Összes autó</h1>

            <form action="/osszesauto" onSubmit={(e: FormEvent) => e.preventDefault()}>
            <div className="search">

                {/* KERESÉS */}
                <div className="d-flex justify-content-center mb-3 mx-auto">
                    <input 
                        type="text" 
                        id="search-box" 
                        name="search"
                        className="form-control w-50" 
                        placeholder="Keresés"
                        value={filters.search}
                        onChange={handleSearchChange}
                    />
                </div>

                {/* SZŰRÉS */}
                <div className="filter d-flex justify-content-center gap-2 w-100 mx-auto">
                    <div className="w-25">
                        <label htmlFor="brand">Autó márkája</label>
                        <select 
                            name="brand" 
                            id="brand" 
                            className="form-select"
                            value={filters.brand}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('car_brand').map((brand, index) => (
                                <option key={index} value={brand}>{brand}</option>
                            ))}
                        </select>
                    </div>
                    <div className="w-25">
                        <label htmlFor="type">Autó típusa</label>
                        <select 
                            name="type" 
                            id="type" 
                            className="form-select"
                            value={filters.type}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('car_type').map((type, index) => (
                                <option key={index} value={type}>{translate('car_type', type)}</option>
                            ))}
                        </select>
                    </div>
                    <div className="w-25">
                        <label htmlFor="condition">Autó minősége</label>
                        <select 
                            name="condition" 
                            id="condition" 
                            className="form-select"
                            value={filters.condition}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('car_condition').map((condition, index) => (
                                <option key={index} value={condition}>{translate('car_condition', condition)}</option>
                            ))}
                        </select>
                    </div>
                </div>

                <div className="filter d-flex justify-content-center gap-2 w-100 mt-2 mx-auto">
                    <div className="w-25">
                        <label htmlFor="transmission">Sebességváltó típusa</label>
                        <select 
                            name="transmission" 
                            id="transmission" 
                            className="form-select"
                            value={filters.transmission}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('transmission_type').map((transmission, index) => (
                                <option key={index} value={transmission}>
                                    {translate('transmission_type', transmission)}
                                </option>
                            ))}
                        </select>
                    </div>
                    <div className="w-25">
                        <label htmlFor="fuel">Üzemanyag típusa</label>
                        <select 
                            name="fuel" 
                            id="fuel" 
                            className="form-select"
                            value={filters.fuel}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('fuel_type').map((fuel, index) => (
                                <option key={index} value={fuel}>{translate('fuel_type', fuel)}</option>
                            ))}
                        </select>
                    </div>
                    <div className="w-25">
                        <label htmlFor="year">Autó évjárata</label>
                        <select 
                            name="year" 
                            id="year" 
                            className="form-select"
                            value={filters.year}
                            onChange={handleFilterChange}
                        >
                            <option>Összes</option>
                            {getUniqueOptions('car_year').map((year, index) => (
                                <option key={index} value={year}>{year}</option>
                            ))}
                        </select>
                    </div>
                </div>
            </div>
            </form>

            {loading ? (
                <div className="text-center mt-5">
                    <p>Autók betöltése...</p>
                </div>
            ) : error ? (
                <div className="text-center mt-5">
                    <p>Hiba történt: {error}</p>
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
                                        <h3>{car.car_brand} {car.car_model}</h3>
                                        <p className="text-truncate mb-2">{car.car_description}</p>
                                        
                                        <div className="d-flex justify-content-between">
                                            <span className="badge bg-primary">{car.car_year}</span>
                                            <span className="badge bg-secondary">{translate('car_type', car.car_type)}</span>
                                            <span className="badge bg-info">{translate('car_condition', car.car_condition)}</span>
                                        </div>
                                        
                                        <div className="d-flex justify-content-between mt-2">
                                            <span className="badge bg-success">{translate('fuel_type', car.fuel_type)}</span>
                                            <span className="badge bg-warning text-dark">{translate('transmission_type', car.transmission_type)}</span>
                                        </div>
                                        
                                        <div className="d-flex justify-content-between align-items-center mt-3">
                                            <small>Ülések: {car.seats}</small>
                                            <small>Ajtók: {car.number_of_doors}</small>
                                            <small>{car.mileage.toLocaleString()} km</small>
                                        </div>
                                        
                                        <hr className="my-2 border-secondary" />
                                        
                                        <div className="d-flex justify-content-between">
                                            <div className="text-start">
                                                <div><small>Óra: {formatPrice(car.price_per_hour)}</small></div>
                                                <div><small>Nap: {formatPrice(car.price_per_day)}</small></div>
                                            </div>
                                            <div className="text-end">
                                                <strong className="text-success">{formatPrice(car.car_price)}</strong>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        ))
                    ) : (
                        <div className="text-center w-100">
                            <p>Nincs a keresésnek megfelelő autó</p>
                        </div>
                    )}
                </div>
            )}
        </main>
        </>
    );
}

export default AllCar;
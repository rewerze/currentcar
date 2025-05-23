import React, { useState, useEffect, ChangeEvent, FormEvent } from 'react';
import axios from 'axios';
import { toast } from 'sonner';
import { useLanguage } from '@/contexts/LanguageContext';
import { buildApiUrl } from '@/lib/utils';
import { CarInfo } from './interfaces/Car';
import { CarCondition, CarType, FuelType, TransmissionType } from './enums/Car';
import { useUser } from '@/contexts/UserContext';
import { useNavigate } from 'react-router-dom';
import PriceTableModal from "./PriceTable";

const CarUpload: React.FC = () => {
    const { t, loadedNamespaces, loadNamespace } = useLanguage();
    const { user, loading } = useUser();
    const navigate = useNavigate();
    const [isPriceModalOpen, setPriceModalOpen] = useState(false);
    const [depoLocations, setDepoLocations] = useState<{ location_id: number, location: string }[]>([]);

    useEffect(() => {
        if (!loading && !user) {
            navigate('/login');
        }
    }, [user, loading]);

    useEffect(() => {
        const fetchCarData = async () => {
            try {
                const response = await fetch(buildApiUrl(`/getDepos`), {
                    credentials: "include",
                });

                if (!response.ok) {
                    throw new Error(`Failed to fetch depo data: ${response.status}`);
                }

                const data = await response.json();
                setDepoLocations(data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchCarData();
    }, []);

    useEffect(() => {
        if (!loadedNamespaces.includes("CarUpload")) {
            loadNamespace("CarUpload");
        }
    }, [loadedNamespaces, loadNamespace]);

    const [formData, setFormData] = useState<CarInfo>({
        car_brand: '',
        car_model: '',
        car_condition: CarCondition.EXCELLENT,
        car_year: 0,
        car_type: CarType.SEDAN,
        fuel_type: FuelType.DIESEL,
        transmission_type: TransmissionType.AUTOMATIC,
        car_regnumber: '',
        seats: 0,
        number_of_doors: 0,
        price_per_hour: 0,
        price_per_day: 0,
        car_description: '',
        image: '',
        car_id: 0,
        car_price: '0',
        car_active: false,
        insurance_id: 0,
        mileage: 0,
        available_to: new Date(),
        extras: '',
        depo: 'Andrássy út 66, Budapest, Hungary',
        location_id: '1'
    });

    const [files, setFiles] = useState<File[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    const carConditions = [
        { value: CarCondition.NEW, label: 'new' },
        { value: CarCondition.EXCELLENT, label: 'excellent' },
        { value: CarCondition.GOOD, label: 'good' },
        { value: CarCondition.FAIR, label: 'fair' },
        { value: CarCondition.POOR, label: 'poor' }
    ];

    const carTypes = [
        { value: CarType.CONVERTIBLE, label: 'convertible' },
        { value: CarType.COUPE, label: 'coupe' },
        { value: CarType.HATCHBACK, label: 'hatchback' },
        { value: CarType.MINIVAN, label: 'minivan' },
        { value: CarType.SEDAN, label: 'sedan' },
        { value: CarType.SUV, label: 'suv' },
        { value: CarType.WAGON, label: 'wagon' }
    ];

    const fuelTypes = [
        { value: FuelType.PETROL, label: 'petrol' },
        { value: FuelType.DIESEL, label: 'diesel' },
        { value: FuelType.ELECTRIC, label: 'electric' },
        { value: FuelType.HYBRID, label: 'hybrid' },
        { value: FuelType.GAS, label: 'gas' }
    ];

    const transmissionTypes = [
        { value: TransmissionType.AUTOMATIC, label: 'automatic' },
        { value: TransmissionType.MANUAL, label: 'manual' },
        { value: TransmissionType.SEMI_AUTOMATIC, label: 'semiAutomatic' },
        { value: TransmissionType.CVT, label: 'cvt' }
    ];

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>): void => {
        const { name, value } = e.target;
        setFormData(prevData => ({
            ...prevData,
            [name]: value
        }));
    };

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>): void => {
        if (e.target.files) {
            setFiles(Array.from(e.target.files));
        }
    };

    const handleSubmit = async (e: FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        setIsLoading(true);

        const requiredFields: (keyof CarInfo)[] = ['car_brand', 'car_model', 'car_condition', 'car_year', 'car_type',
            'fuel_type', 'transmission_type', 'car_regnumber', 'seats',
            'number_of_doors', 'price_per_hour', 'price_per_day', 'car_description', 'available_to', 'depo', 'car_price'];

        const emptyFields = requiredFields.filter(field => !formData[field]);

        if (emptyFields.length > 0) {
            toast.error(t('fillAllFields', 'CarUpload'));
            setIsLoading(false);
            return;
        }

        if (files.length === 0) {
            toast.error(t('uploadOneImage', 'CarUpload'));
            setIsLoading(false);
            return;
        }

        try {
            const submitData = new FormData();

            Object.keys(formData).forEach(key => {
                const value = formData[key as keyof CarInfo];
                submitData.append(key, value !== undefined ? String(value) : '');
            });

            files.forEach(file => {
                submitData.append('car_picture', file);
            });

            await axios.post(buildApiUrl('/upload'), submitData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                },
                withCredentials: true
            });

            toast.success(t('uploadSuccess', 'CarUpload'));

            setFormData({
                car_brand: '',
                car_model: '',
                car_condition: CarCondition.EXCELLENT,
                car_year: 0,
                car_type: CarType.SEDAN,
                fuel_type: FuelType.DIESEL,
                transmission_type: TransmissionType.AUTOMATIC,
                car_regnumber: '',
                seats: 0,
                number_of_doors: 0,
                price_per_hour: 0,
                price_per_day: 0,
                car_description: '',
                image: '',
                car_id: 0,
                car_price: '',
                car_active: false,
                insurance_id: 0,
                mileage: 0,
                available_to: new Date(),
                extras: '',
                depo: 'Andrássy út 66, Budapest, Hungary',
                location_id: '1'
            });
            setFiles([]);

        } catch (error) {
            console.error('Error uploading car:', error);

            if (axios.isAxiosError(error) && error.response?.data?.errors) {
                const errorMessages = error.response.data.errors
                    .map((err: unknown) => {
                        if (typeof err === 'object' && err !== null && 'msg' in err) {
                            return (err as { msg: string }).msg;
                        }
                        return t('unknownError', 'CarUpload');
                    })
                    .join(', ');
                toast.error(errorMessages);
            } else {
                if (axios.isAxiosError(error) && error.response) {
                    console.log(error);
                    toast.error(error.response.data.error);
                } else {
                    toast.error("unknown error");
                }
            }
        } finally {
            setIsLoading(false);
        }
    };

    const currentYear = new Date().getFullYear();

    return (
        <>
            <main className="nav-gap">
                <div className="form">
                    <div className="form-box bg-dark">
                        <h1 className="text-center">{t('carUpload', 'CarUpload')}</h1>

                        <form onSubmit={handleSubmit}>

                            {/* BRAND + MODEL */}
                            <h2>Autó adatai</h2>
                            <div className="d-flex justify-content-center gap-3 upload-form">
                                <div className='upload-data'>
                                    <label htmlFor="car_brand">{t('carBrand', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="car_brand"
                                        type="text"
                                        name="car_brand"
                                        value={formData.car_brand}
                                        onChange={handleChange}
                                        placeholder={t('carBrand', 'CarUpload')}
                                        className="form-control"
                                    />
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="car_model">{t('carModel', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="car_model"
                                        type="text"
                                        name="car_model"
                                        value={formData.car_model}
                                        onChange={handleChange}
                                        placeholder={t('carModel', 'CarUpload')}
                                        className="form-control"
                                    />
                                </div>
                            </div>


                            {/* CAR YEAR + REG NUMBER */}
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className='upload-data'>
                                    <label htmlFor="car_regnumber">{t('regNumber', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="car_regnumber"
                                        type="text"
                                        name="car_regnumber"
                                        value={formData.car_regnumber}
                                        onChange={handleChange}
                                        placeholder={t('regNumber', 'CarUpload')}
                                        className="form-control"
                                    />
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="car_year">{t('year', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="car_year"
                                        type="number"
                                        name="car_year"
                                        value={formData.car_year}
                                        onChange={handleChange}
                                        placeholder={t('year', 'CarUpload')}
                                        className="form-control"
                                        min="1900"
                                        max={currentYear}
                                    />
                                </div>
                            </div>

                            {/* CONDITION + TYPE + FUEL +  TRANSMISSION */}
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className='upload-data'>
                                    <label htmlFor="car_condition">{t('condition', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <select
                                        id="car_condition"
                                        name="car_condition"
                                        value={formData.car_condition}
                                        onChange={handleChange}
                                        className="form-select"
                                    >
                                        {carConditions.map((condition) => (
                                            <option key={condition.value} value={condition.value}>
                                                {t(condition.label, 'CarUpload')}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="car_type">{t('carType', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <select
                                        id="car_type"
                                        name="car_type"
                                        value={formData.car_type}
                                        onChange={handleChange}
                                        className="form-select"
                                    >
                                        {carTypes.map((type) => (
                                            <option key={type.value} value={type.value}>
                                                {t(type.label, 'CarUpload')}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="fuel_type">{t('fuelType', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <select
                                        id="fuel_type"
                                        name="fuel_type"
                                        value={formData.fuel_type}
                                        onChange={handleChange}
                                        className="form-select w-25"
                                    >
                                        {fuelTypes.map((type) => (
                                            <option key={type.value} value={type.value}>
                                                {t(type.label, 'CarUpload')}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="transmission_type">{t('transmissionType', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <select
                                        id="transmission_type"
                                        name="transmission_type"
                                        value={formData.transmission_type}
                                        onChange={handleChange}
                                        className="form-select"
                                    >
                                        {transmissionTypes.map((type) => (
                                            <option key={type.value} value={type.value}>
                                                {t(type.label, 'CarUpload')}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                            </div>


                            {/* SEAT + DOORS */}
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className='upload-data'>
                                    <label htmlFor="seats">{t('seats', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="seats"
                                        type="number"
                                        name="seats"
                                        value={formData.seats}
                                        onChange={handleChange}
                                        placeholder={t('seats', 'CarUpload')}
                                        className="form-control"
                                        min="1"
                                    />
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="number_of_doors">{t('doors', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="number_of_doors"
                                        type="number"
                                        name="number_of_doors"
                                        value={formData.number_of_doors}
                                        onChange={handleChange}
                                        placeholder={t('doors', 'CarUpload')}
                                        className="form-control"
                                        min="1"
                                    />
                                </div>
                            </div>

                            {/* IMAGE */}
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className="upload-data">
                                    <label htmlFor="car_picture">{t('imageUpload', 'CarUpload')}: <i>{t('recommendedSizes', 'CarUpload')}</i><span className='text-danger'>*</span></label>
                                    <input
                                        id="car_picture"
                                        type="file"
                                        name="car_picture"
                                        onChange={handleFileChange}
                                        className="form-control form-control-lg"
                                        multiple
                                        accept="image/*"
                                    />
                                    {files.length > 0 && (
                                        <div className="mt-2">
                                            <p>{files.length} kép kiválasztva</p>
                                            <div className="selected-files">
                                                {files.map((file, index) => (
                                                    <span key={index} className="badge bg-primary me-1">
                                                        {file.name}
                                                    </span>
                                                ))}
                                            </div>
                                        </div>
                                    )}
                                </div>
                            </div>

                            {/* DESCRIPTION */}
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className="upload-data">
                                    <label htmlFor="car_description">{t('description', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <textarea
                                        id="car_description"
                                        name="car_description"
                                        value={formData.car_description}
                                        onChange={handleChange}
                                        placeholder={t('description', 'CarUpload')}
                                        className="form-control"
                                        rows={4}
                                    ></textarea>
                                </div>
                            </div>

                            {/* PRICES */}
                            <div className='upload-price'>
                                <h2 className='mt-5'>{t('pricing', 'CarUpload')}</h2>
                                <button type="button" className="btn btn-primary" onClick={() => setPriceModalOpen(true)}>{t('viewPrices', 'CarUpload')}</button>
                            </div>
                            <PriceTableModal isOpen={isPriceModalOpen} onClose={() => setPriceModalOpen(false)} />
                            <div className="d-flex justify-content-center gap-3 mt-3 upload-form">
                                <div className='upload-data'>
                                    <label htmlFor="car_price">{t('basePrice', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="car_price"
                                        type="number"
                                        name="car_price"
                                        value={formData.car_price}
                                        onChange={handleChange}
                                        className="form-control"
                                        min="0"
                                    />
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="price_per_hour">{t('pricePerHour', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="price_per_hour"
                                        type="number"
                                        name="price_per_hour"
                                        value={formData.price_per_hour}
                                        onChange={handleChange}
                                        className="form-control"
                                        min="0"
                                    />
                                </div>
                                <div className='upload-data'>
                                    <label htmlFor="price_per_day">{t('pricePerDay', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="price_per_day"
                                        type="number"
                                        name="price_per_day"
                                        value={formData.price_per_day}
                                        onChange={handleChange}
                                        className="form-control"
                                        min="0"
                                    />
                                </div>
                            </div>

                            {/* AVAILABLE TO */}
                            <h2 className='mt-5'>{t('location', 'CarUpload')}</h2>
                            <div className="d-flex justify-content-center gap-3 upload-form mt-2">
                                <div className='upload-data'>
                                    <label htmlFor="to">{t('available_to', 'CarUpload')}<span className='text-danger'>*</span></label>
                                    <input
                                        id="to"
                                        type="date"
                                        name="available_to"
                                        max="9999-12-31"
                                        value={formData.available_to.toString()}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>

                                <div className='upload-data'>
                                    <label htmlFor="location_id">{t('chooseDepo', 'CarUpload')} <span className='text-danger'>*</span></label>
                                    <select
                                        id="location_id"
                                        name="location_id"
                                        value={formData.location_id}
                                        onChange={handleChange}
                                        className="form-select">
                                        {
                                            depoLocations.map((depo) => (
                                                <option key={depo.location_id} value={depo.location_id}>
                                                    {depo.location}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                            </div>

                            <p className='mt-5'><b dangerouslySetInnerHTML={{ __html: t('fieldsRequired', 'CarUpload') }}></b></p>

                            <button
                                type="submit"
                                className="btn btn-success w-100 p-2"
                                disabled={isLoading}
                            >
                                {isLoading ? t('uploading', 'CarUpload') : t('uploadCar', 'CarUpload')}
                            </button>
                        </form>
                    </div>
                </div>
            </main>
        </>
    );
}

export default CarUpload;
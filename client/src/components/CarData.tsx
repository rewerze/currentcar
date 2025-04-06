import { useEffect, useState, FormEvent } from "react";
import carImage from "../assets/img/nepszeru_auto.png";
import { useParams } from "react-router-dom";
import { CarInfo } from "./interfaces/Car";
import { useLanguage } from "@/contexts/LanguageContext";
import { toast } from "sonner";
import profile from "../assets/img/profile.jpg";
import { Comment } from "./interfaces/Comment";
import { buildApiUrl } from "@/lib/utils";
import { useUser } from "@/contexts/UserContext";
import axios, { AxiosError } from "axios";
import PaymentModal from "./Payment";

function CarData() {
  const { user, loading } = useUser();
  const { t, loadNamespace, language, loadedNamespaces } = useLanguage();
  const { id } = useParams<{ id: string }>();
  const [car, setCarInfo] = useState<CarInfo | null>(null);
  const [images, setImages] = useState<string[]>([]);
  const [comments, setComments] = useState<Comment[]>([]);
  const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  const [newComment, setNewComment] = useState({
    message: "",
    stars: 5,
    category: "comfort"
  });
  const [loading2, setLoading] = useState<boolean>(false);

  useEffect(() => {
    if (!loading && user) {
      setIsLoggedIn(true)
    }
  }, [user, loading])

  useEffect(() => {
    if (!loadedNamespaces.includes("CarDetail")) {
      loadNamespace("CarDetail");
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
        setImages(data.images || []);
      } catch (error) {
        console.error(error);
        toast.error(t("errorFetchingCar", "CarDetail"));
      }
    };

    fetchCarData();
  }, [id, t, isModalOpen]);

  useEffect(() => {
    const fetchComments = async () => {
      try {
        const response = await fetch(buildApiUrl(`/comments?carId=${id}`), {
          credentials: "include",
        });

        if (!response.ok) {
          throw new Error(`Failed to fetch comments: ${response.status}`);
        }

        const data = await response.json();
        setComments(data);
      } catch (error) {
        console.error("Failed to fetch comments:", error);
      }
    };

    if (id) {
      fetchComments();
    }
  }, [id]);

  if (!car) {
    return <div className="nav-gap text-center">Loading...</div>;
  }

  async function onCarPurchase(fromDate: string, toDate: string, paymentMethod: string): Promise<void> {
    if (car?.car_active == false) {
      setIsModalOpen(false);
      return;
    }

    if (user && !loading) {
      try {
        const response = await axios.post(
          buildApiUrl("/rent"),
          {
            car_id: id,
            start_date: fromDate,
            end_date: toDate,
            pickup_location: "Default Pickup Location",
            dropoff_location: "Default Dropoff Location",
            payment_method: paymentMethod == "card" ? "credit_card" : "cash",
            discount_code: ""
          },
          {
            withCredentials: true
          }
        );

        if (response.data.success) {
          toast.success(t("purchaseSuccess", "CarDetail"));
          setIsModalOpen(false);
        } else {
          console.log(response.data.error)
          toast.error(response.data.error || t("purchaseError", "CarDetail"));
          setIsModalOpen(false);
        }
      } catch (error) {
        console.error("Error renting car:", error);
        if (error instanceof AxiosError) {
          toast.error(
            (error.response?.data as { error?: string })?.error ||
            error.message ||
            (t("purchaseError", "CarDetail") as string) ||
            ""
          );
        } else {
          toast.error("An unknown error occurred.");
        }
      }
    } else {
      toast.error(t("signIn", "CarDetail"));
    }
  }

  async function onPurchase(): Promise<void> {
    openModal();
  }

  const handleCommentChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    setNewComment({
      ...newComment,
      message: e.target.value
    });
  };

  const handleStarChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewComment({
      ...newComment,
      stars: parseInt(e.target.value)
    });
  };

  const handleCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setNewComment({
      ...newComment,
      category: e.target.value
    });
  };

  const handleSubmitComment = async (e: FormEvent) => {
    e.preventDefault();

    if (!isLoggedIn) {
      toast.error(t("loginRequired", "CarDetail"));
      return;
    }

    if (!newComment.message.trim()) {
      toast.error(t("commentRequired", "CarDetail"));
      return;
    }

    setLoading(true);

    try {
      const response = await fetch(buildApiUrl("/comments"), {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify({
          carId: id,
          message: newComment.message,
          stars: newComment.stars,
          ratingCategory: newComment.category
        }),
      });

      if (!response.ok) {
        throw new Error(`Failed to submit comment: ${response.status}`);
      }

      const newCommentData = await response.json();

      setComments([newCommentData, ...comments]);

      setNewComment({
        message: "",
        stars: 5,
        category: "comfort"
      });

      toast.success(t("commentSubmitted", "CarDetail"));
    } catch (error) {
      console.error("Error submitting comment:", error);
      toast.error(t("errorSubmittingComment", "CarDetail"));
    } finally {
      setLoading(false);
    }
  };

  return (
    <>
      <PaymentModal isOpen={isModalOpen} onClose={closeModal} onPurchase={onCarPurchase} />
      <main className="nav-gap">
        <div className="row">
          <div className="col-lg-4 car-data-col">
            <div className="col-lg-4 car-data-col">
              <div id="carouselExampleIndicators" className="carousel slide carousel-dark">
                <div className="carousel-inner">
                  {images && images.length > 0 ? (
                    images.map((image, index) => (
                      <div className={`carousel-item ${index === 0 ? 'active' : ''}`} key={index}>
                        <img
                          src={`${import.meta.env.PROD ? "/api" : "http://localhost:3000/api"}/uploads/${image}`}
                          alt={`${car.car_brand} ${car.car_model} - ${index + 1}`}
                          className="d-block w-100 car-data-img"
                          onError={(e) => { (e.target as HTMLImageElement).src = carImage }}
                        />
                      </div>
                    ))
                  ) : (
                    <>
                      <div className="carousel-item active">
                        <img
                          src={car.car_id ? `${import.meta.env.PROD ? "/api" : "http://localhost:3000/api"}/getCarImage?car_id=${car.car_id}` : carImage}
                          alt={`${car.car_brand} ${car.car_model}`}
                          className="d-block w-100 car-data-img"
                          onError={(e) => { (e.target as HTMLImageElement).src = carImage }}
                        />
                      </div>
                    </>
                  )}
                </div>
                <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                  <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                  <span className="visually-hidden">Previous</span>
                </button>
                <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                  <span className="carousel-control-next-icon" aria-hidden="true"></span>
                  <span className="visually-hidden">Next</span>
                </button>
              </div>
            </div>
          </div>
          <div className="col-lg-7">
            <h2 className="text-center display-5">
              {t("properties", "CarDetail")}
            </h2>
            <div className="d-flex justify-content-center">
              <table className="table adatlap-table">
                <tbody>
                  <tr>
                    <th>{t("carBrand", "CarDetail")}:</th>
                    <td>{car.car_brand}</td>
                  </tr>
                  <tr>
                    <th>{t("carModel", "CarDetail")}:</th>
                    <td>{car.car_model}</td>
                  </tr>
                  <tr>
                    <th>{t("condition", "CarDetail")}:</th>
                    <td>{t(car.car_condition, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("year", "CarDetail")}:</th>
                    <td>{car.car_year}</td>
                  </tr>
                  <tr>
                    <th>{t("carType", "CarDetail")}:</th>
                    <td>{t(car.car_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("fuelType", "CarDetail")}:</th>
                    <td>{t(car.fuel_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("transmissionType", "CarDetail")}:</th>
                    <td>{t(car.transmission_type, "CarDetail")}</td>
                  </tr>
                  <tr>
                    <th>{t("seats", "CarDetail")}:</th>
                    <td>{car.seats}</td>
                  </tr>
                  <tr>
                    <th>{t("doors", "CarDetail")}:</th>
                    <td>{car.number_of_doors}</td>
                  </tr>
                  <tr>
                    <th>{t("regNumber", "CarDetail")}:</th>
                    <td>{car.car_regnumber}</td>
                  </tr>
                  <tr>
                    <th>{t("description", "CarDetail")}:</th>
                    <td>{car.car_description}</td>
                  </tr>
                  <tr>
                    <th>{t("pricePerHour", "CarDetail")}:</th>
                    <td>
                      {car.price_per_hour} {language === "hu" ? "HUF" : "EUR"}
                    </td>
                  </tr>
                  <tr>
                    <th>{t("pricePerDay", "CarDetail")}:</th>
                    <td>
                      {car.price_per_day} {language === "hu" ? "HUF" : "EUR"}
                    </td>
                  </tr>
                  <tr>
                    <th>{t("availableUntil", "CarDetail")}:</th>
                    <td>{new Date(car.available_to).toLocaleDateString()}</td>
                  </tr>
                  <tr>
                    <th>Itt vehető át:</th>
                    <td>cím google maps-es link-kel</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div className="d-flex justify-content-center adatlap-table-alatt">
              <button className="btn btn-success" onClick={onPurchase} disabled={!!(car.car_active != true || (car.car_owner && car.car_owner == user?.user_id))}>
                {car.car_owner && car.car_owner == user?.user_id ? t('cantRentOwn', 'CarDetail') : car.car_active ? t("purchase", "CarDetail") : t("rented", "CarDetail")}
              </button>
            </div>
          </div>
        </div>

        <div className="car-comment mt-5 w-50 mx-auto">
          <h2 className="text-center">{t("reviews", "CarDetail")}</h2>
          <hr />

          {!isLoggedIn && (
            <h3 className="text-center text-danger">{t("loginRequired", "CarDetail")}</h3>
          )}

          <form onSubmit={handleSubmitComment}>
            <div className="my-2 mt-5">
              <div className="row">
                <div className="col-md comment-header">
                  <a href="/profil">
                    <img src={isLoggedIn ? `${import.meta.env.PROD
                      ? "/api/uploads/profile-pictures/"
                      : "http://localhost:3000/api/uploads/profile-pictures/"
                      }${user?.profile_picture}` : profile} onError={(e) => { (e.target as HTMLImageElement).src = profile }} alt="" className="profile-sm" />
                  </a>
                  <span className="star-range">
                    <input
                      type="range"
                      name="star"
                      id="star"
                      min={1}
                      max={5}
                      value={newComment.stars}
                      onChange={handleStarChange}
                    />
                    <span className="ms-2">{newComment.stars}/5</span>
                  </span>
                </div>
                <div className="col-md">
                  <select
                    name="comment_category"
                    id="comment_category"
                    className="form-select car-comment-select"
                    value={newComment.category}
                    onChange={handleCategoryChange}
                  >
                    <option value="comfort">{t("comfort", "CarDetail")}</option>
                    <option value="performance">{t("performance", "CarDetail")}</option>
                    <option value="fuel_efficiency">{t("fuel_efficiency", "CarDetail")}</option>
                    <option value="safety">{t("safety", "CarDetail")}</option>
                    <option value="value_for_money">{t("value_for_money", "CarDetail")}</option>
                  </select>
                </div>
              </div>
            </div>

            <textarea
              name="comment"
              id="comment"
              className="w-100 form-control"
              rows={3}
              placeholder={t("writeReview", "CarDetail")}
              value={newComment.message}
              onChange={handleCommentChange}
              disabled={!isLoggedIn}
            ></textarea>

            <button
              className="btn btn-primary mt-2 py-2 w-25"
              disabled={!isLoggedIn || loading2}
            >
              {loading2 ? t("sending", "CarDetail") : t("send", "CarDetail")}
            </button>
          </form>

          <div className="comment-section mt-4">
            {comments.length > 0 ? (
              comments.map((comment) => (
                <div key={comment.comment_id} className="comment-box bg-light mb-3">
                  <div className="comment-content">
                    <img src={
                      comment.profile_picture
                        ? `${import.meta.env.PROD
                          ? "/api/uploads/profile-pictures/"
                          : "http://localhost:3000/api/uploads/profile-pictures/"
                        }${comment.profile_picture}`
                        : profile
                    } alt="" onError={(e) => { (e.target as HTMLImageElement).src = profile }} className='profile' />
                    <div className="comment-text">
                      <h5>
                        <span><b>{comment.user_name}</b></span><br />
                        {t(comment.rating_category, "CarDetail")}: {comment.comment_star}/5
                      </h5>
                      <p>{comment.comment_message}</p>
                      <small className="text-muted">
                        {new Date(comment.comment_date).toLocaleDateString()}
                      </small>
                    </div>
                  </div>
                </div>
              ))
            ) : (
              <div className="text-center mt-4">
                <p>{t("noReviews", "CarDetail")}</p>
              </div>
            )}
          </div>
        </div>
      </main >
    </>
  );
}

export default CarData;
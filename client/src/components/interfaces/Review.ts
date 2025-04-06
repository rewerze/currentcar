export interface Review {
  review_id: number;
  reviewer_user_id: number;
  reviewee_user_id: number;
  review_message: string;
  review_rating: number;
  review_date: Date;
  user_name: string;
}

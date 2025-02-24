type UserRole = "admin" | "user";

export interface User {
  user_id: number;
  user_email: string;
  user_name: string;
  password: string;
  born_at: Date;
  created_at: Date;
  updated_at: Date;
  user_active: boolean;
  u_phone_number: string;
  area_code: number;
  user_role: UserRole;
  driver_license_number: string;
  driver_license_expiry: Date;
  profile_picture: string;
}

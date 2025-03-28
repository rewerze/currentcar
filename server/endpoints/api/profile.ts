import { Request, Response } from "express";
import db from "../../db/connection";
import validator from "validator";
import jwt from "jsonwebtoken";
import { User } from "../../interfaces/User";
import multer from "multer";
import path from "path";
import fs from "fs";

interface AuthenticatedRequest extends Request {
  user?: {
    user_id: number;
  };
}

interface ProfileUpdateData {
  name?: string;
  email?: string;
  born_at?: Date;
  u_phone_number?: string;
  driver_license_number?: string;
  driver_license_expiry?: Date;
  user_iban?: string;
  profile_picture?: string;
}

export const editProfile = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const userId = req.user?.user_id;
  const {
    name,
    email,
    born_at,
    u_phone_number,
    driver_license_number,
    driver_license_expiry,
    user_iban,
    profile_picture,
  }: ProfileUpdateData = req.body;

  if (!userId) {
    res.status(401).json({ error: "Unauthorized" });
    return;
  }

  if (email && !validator.isEmail(email)) {
    res.status(400).json({ error: "Invalid email format" });
    return;
  }

  if (name && name.length > 100) {
    res.status(400).json({ error: "Name is too long" });
    return;
  }

  if (u_phone_number && !/^\+?[1-9]\d{1,14}$/.test(u_phone_number)) {
    res.status(400).json({ error: "Invalid phone number format" });
    return;
  }

  if (driver_license_number && driver_license_number.length > 50) {
    res.status(400).json({ error: "Driver's license number is too long" });
    return;
  }

  if (user_iban && !validator.isIBAN(user_iban)) {
    res.status(400).json({ error: "Invalid IBAN format" });
    return;
  }

  try {
    const updateFields: string[] = [];
    const updateValues: any[] = [];

    if (name) {
      updateFields.push("user_name = ?");
      updateValues.push(name);
    }

    if (email) {
      const existingUser = await db.query(
        "SELECT * FROM user WHERE user_email = ? AND user_id != ?",
        [email, userId]
      );

      if (existingUser.length > 0) {
        res.status(409).json({ error: "Email is already in use" });
        return;
      }

      updateFields.push("user_email = ?");
      updateValues.push(email);
    }

    if (profile_picture) {
      updateFields.push("profile_picture = ?");
      updateValues.push(profile_picture);
    }

    if (born_at) {
      updateFields.push("born_at = ?");
      updateValues.push(born_at);
    }

    if (u_phone_number) {
      updateFields.push("u_phone_number = ?");
      updateValues.push(u_phone_number);
    }

    if (driver_license_number) {
      updateFields.push("driver_license_number = ?");
      updateValues.push(driver_license_number);
    }

    if (driver_license_expiry) {
      updateFields.push("driver_license_expiry = ?");
      updateValues.push(driver_license_expiry);
    }

    if (user_iban) {
      updateFields.push("user_iban = ?");
      updateValues.push(user_iban);
    }

    if (updateFields.length === 0) {
      res.status(400).json({ error: "No update fields provided" });
      return;
    }

    updateValues.push(userId);

    const updateQuery = `
      UPDATE user 
      SET ${updateFields.join(", ")} 
      WHERE user_id = ?
    `;

    await db.query(updateQuery, updateValues);

    const [updatedUser] = await db.query<User>(
      `SELECT 
        user_id, 
        user_name, 
        user_email, 
        born_at, 
        u_phone_number, 
        driver_license_number, 
        driver_license_expiry, 
        user_iban, 
        profile_picture 
      FROM user 
      WHERE user_id = ?`,
      [userId]
    );

    const token = jwt.sign(
      updatedUser,
      process.env.SECRET_KEY || "fallback_secret_key",
      { expiresIn: "24h" }
    );

    res.cookie("auth_token", token, {
      domain: process.env.NODE_ENV === "production" ? "beniary.com" : "",
      httpOnly: true,
      secure: process.env.NODE_ENV === "production",
      maxAge: 24 * 60 * 60 * 1000,
      sameSite: "lax",
    });

    res.json({
      message: "Profile updated successfully",
      user: updatedUser,
    });
  } catch (error) {
    console.error("Profile update error:", error);
    res.status(500).json({ error: "Failed to update profile" });
  }
};

const storage = multer.diskStorage({
  destination: (req: AuthenticatedRequest, file, cb) => {
    const uploadPath = path.join(__dirname, "../uploads/profile-pictures");

    if (!fs.existsSync(uploadPath)) {
      fs.mkdirSync(uploadPath, { recursive: true });
    }

    cb(null, uploadPath);
  },
  filename: (req: AuthenticatedRequest, file, cb) => {
    const uniqueSuffix = Date.now() + "-" + Math.round(Math.random() * 1e9);
    cb(
      null,
      `profile-${req.user?.user_id}-${uniqueSuffix}${path.extname(
        file.originalname
      )}`
    );
  },
});

const fileFilter = (
  req: Request,
  file: Express.Multer.File,
  cb: multer.FileFilterCallback
) => {
  const allowedTypes = ["image/jpeg", "image/png", "image/webp"];

  if (allowedTypes.includes(file.mimetype)) {
    cb(null, true);
  } else {
    cb(new Error("Invalid file type. Only JPEG, PNG, and WEBP are allowed."));
  }
};

const upload = multer({
  storage: storage,
  fileFilter: fileFilter,
  limits: { fileSize: 5 * 1024 * 1024 },
});
export const uploadProfilePicture = async (
  req: AuthenticatedRequest,
  res: Response
) => {
  upload.single("profile_picture")(req, res, async (err) => {
    if (err instanceof multer.MulterError) {
      return res.status(400).json({ error: "File upload error" });
    } else if (err) {
      return res.status(400).json({ error: err.message });
    }
    if (!req.file) {
      return res.status(400).json({ error: "No file uploaded" });
    }
    if (!req.user?.user_id) {
      return res.status(401).json({ error: "Unauthorized" });
    }
    try {
      const profilePicturePath = req.file.filename;
      await db.query("UPDATE user SET profile_picture = ? WHERE user_id = ?", [
        profilePicturePath,
        req.user.user_id,
      ]);
      res.json({
        message: "Profile picture uploaded successfully",
        profilePicture: profilePicturePath,
      });
    } catch (error) {
      console.error("Profile picture upload error:", error);
      res.status(500).json({ error: "Failed to upload profile picture" });
    }
  });
};

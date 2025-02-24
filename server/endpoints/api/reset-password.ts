import { Request, Response } from "express";
import bcrypt from "bcrypt";
import db from "../../db/connection";
import { User } from "../../interfaces/User";

interface AuthenticatedRequest extends Request {
  user?: any;
}

export const resetPasswordHandler = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const { oldPassword, newPassword, passwordAgain } = req.body;

  // ELLENŐRZÉS

  // KI VAN E TÖLTVE
  if (!oldPassword || !newPassword) {
    res
      .status(400)
      .json({ error: "A régi és az új jelszót is kötelező megadni!" });
    return;
  }

  // UGYAN AZ E A JELSZÓ 1
  if (oldPassword == newPassword) {
    res
      .status(400)
      .json({ error: "A régi jelszavad nem egyezhet meg az újjal!" });
    return;
  }

  if (newPassword !== passwordAgain) {
    res.status(400).json({ error: "A két jelszó nem egyezik!" });
    return;
  }

  try {
    const userEmail = req.user?.email;

    if (!userEmail) {
      res.status(401).json({ error: "Sikertelen verifikáció!" });
      return;
    }

    const userRows = await db.query<User>(
      "SELECT * FROM user WHERE user_email = ?",
      [userEmail]
    );

    if (userRows.length === 0) {
      res.status(404).json({ error: "Felhasználó nem létezik!" });
      return;
    }

    const user = userRows[0];
    const isMatch = await bcrypt.compare(oldPassword, user.password);

    if (!isMatch) {
      res.status(400).json({ error: "A régi jelszó hibás!" });
      return;
    }

    const hashedNewPassword = await bcrypt.hash(newPassword, 10);

    const now = new Date().toISOString().slice(0, 19).replace("T", " ");

    await db.pool.execute(
      "UPDATE user SET password = ?, updated_at = ? WHERE user_email = ?",
      [hashedNewPassword, now, userEmail]
    );

    res.status(200).json({ message: "Sikeres jelszó módosítás" });
  } catch (error) {
    console.error("Error resetting password:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};

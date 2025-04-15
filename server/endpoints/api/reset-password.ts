import { Request, Response } from "express";
import bcrypt from "bcrypt";
import db from "../../db/connection";
import { AuthenticatedRequest, User } from "../../interfaces/User";

const PASSWORD_REGEX = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

function isValidPassword(password: string): boolean {
  return PASSWORD_REGEX.test(password);
}

export const resetPasswordHandler = async (
  req: Request,
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

  if(!isValidPassword(newPassword)) {
    res.status(400).json({ error: "A jelszónak legalább 8 karakter hosszúnak kell lennie, és tartalmaznia kell legalább egy nagybetűt, egy kisbetűt, egy számot és egy speciális karaktert." });
    return;
  } 

  try {
    const userEmail = (req as AuthenticatedRequest).user?.user_email;

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

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
    const { oldPassword, newPassword } = req.body;

    if (!oldPassword || !newPassword) {
        res.status(400).json({ error: "A régi és az új jelszót is kötelező megadni!" });
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

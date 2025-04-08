using System;
using System.Collections.Generic;
using System.Data;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace CarRentalAdmin
{
    internal class AuthService
    {
        private static string _currentToken = null;

        public static string CurrentToken
        {
            get { return _currentToken; }
            set { _currentToken = value; }
        }

        // Autentikáció email, password
        public static bool AuthenticateUser(string email, string password, out int userId, out string role)
        {
            userId = 0;
            role = string.Empty;

            try
            {
                string query = "SELECT user_id, password, user_role FROM user WHERE user_email = @email AND user_active = 1";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@email", email }
                };

                DataTable result = DatabaseOptimizer.ExecuteParameterizedQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    string hashedPassword = result.Rows[0]["password"].ToString();

                    // jelszó verifikáció, BCrypt
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                    if (isPasswordValid)
                    {
                        userId = Convert.ToInt32(result.Rows[0]["user_id"]);
                        role = result.Rows[0]["user_role"].ToString();

                        // JWT token generálás
                        CurrentToken = JwtSecurity.GenerateToken(userId, email, role);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Admin?
        public static bool IsAdmin()
        {
            if (string.IsNullOrEmpty(CurrentToken))
                return false;

            string role = JwtSecurity.GetUserRoleFromToken(CurrentToken);
            return role.Equals("admin", StringComparison.OrdinalIgnoreCase);
        }

        // id "lekérdezése token-nel"
        public static int GetCurrentUserId()
        {
            if (string.IsNullOrEmpty(CurrentToken))
                return 0;

            return JwtSecurity.GetUserIdFromToken(CurrentToken);
        }

        // jelszó generálás, új felhasználó
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Logout
        public static void Logout()
        {
            CurrentToken = null;
        }
    }
}
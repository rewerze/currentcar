using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CarRentalAdmin
{
    internal class JwtSecurity
    {
        private static readonly string SecretKey = "6E35226029EC5403";

        // JWT tokent generálása a hitelesített felhasználó számára
        public static string GenerateToken(int userId, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // az eredeti kulcsot "újra" hash-eljük
            // Ez biztosítja, hogy megfelelő hosszúságú kulcsunk legyen a HMAC-SHA256 számára
            byte[] keyBytes;
            using (var sha = SHA256.Create())
            {
                keyBytes = sha.ComputeHash(Encoding.ASCII.GetBytes(SecretKey));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", userId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(8), //8 órán keresztül érvényes
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //JWT tokent validálás, és ha valid, akkor sikeresen "be lehet lépépni"
        public static ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                // ugyan az az "újra hash-elés" mint a GenerateToken-ben
                byte[] keyBytes;
                using (var sha = SHA256.Create())
                {
                    keyBytes = sha.ComputeHash(Encoding.ASCII.GetBytes(SecretKey));
                }

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        // id "lekérdezése token-nel"
        public static int GetUserIdFromToken(string token)
        {
            var principal = ValidateToken(token);
            if (principal == null) return 0;

            var claim = principal.FindFirst("id");
            if (claim == null) return 0;

            return int.Parse(claim.Value);
        }

        // role "megszerzése token alapján"
        public static string GetUserRoleFromToken(string token)
        {
            var principal = ValidateToken(token);
            if (principal == null) return string.Empty;

            var claim = principal.FindFirst(ClaimTypes.Role);
            if (claim == null) return string.Empty;

            return claim.Value;
        }
    }
}
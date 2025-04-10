using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types;

namespace CarRentalAdmin
{
    public static class AppResources
    {
        //public static int HU = 0;
        //public static int EN = 1;
        // Common
        public static string ApplicationTitle = "Autókölcsönző Admin Panel";
        public static string Yes = "Igen";
        public static string No = "Nem";
        public static string OK = "OK";
        public static string Cancel = "Mégse";
        public static string Save = "Mentés";
        public static string Add = "Hozzáadás";
        public static string Edit = "Szerkesztés";
        public static string Delete = "Törlés";
        public static string Search = "Keresés";
        public static string All = "Összes";
        public static string Active = "Aktív";
        public static string Inactive = "Inaktív";
        public static string User = "Felhasználó";
        public static string RemoveImg = "Kép törlése";

        // Error
        public static string ErrorTitle = "Hiba";
        public static string ValidationError = "Érvényesítési hiba";
        public static string DatabaseError = "Adatbázis hiba";
        public static string SelectionRequired = "Kiválasztás szükséges";
        public static string NoDataFound = "Nincs találat";
        public static string OperationFailed = "A művelet sikertelen";

        // Success
        public static string SuccessTitle = "Siker";
        public static string OperationSuccess = "A művelet sikeres";

        // Login
        public static string LoginTitle = "CurRentCar - Bejelentkezés";
        public static string Email = "Email";
        public static string Password = "Jelszó";
        public static string Login = "Bejelentkezés";
        public static string LoginError = "Érvénytelen email/jelszó vagy elégtelen jogosultság.";
        public static string EnterEmailPassword = "Kérjük, adja meg az email címet és jelszót.";

        // Main
        public static string Dashboard = "Irányítópult";
        public static string Users = "Felhasználók";
        public static string Cars = "Autók";
        public static string Orders = "Rendelések";
        public static string Reports = "Jelentések";
        public static string Reviews = "Értékelések";
        public static string Comments = "Hozzászólások";
        public static string Notifications = "Értesítések";
        public static string Logout = "Kijelentkezés";
        public static string LogoutConfirm = "Biztosan ki szeretne jelentkezni?";
        public static string WelcomeMessage = "Üdvözöljük az Autókölcsönző Admin Panel-ben";
        public static string RegisteredUsers = "Regisztrált felhasználók";
        public static string AvailableCars = "Elérhető autók";
        public static string ActiveOrders = "Aktív rendelések";

        // User management
        public static string UserManagement = "Felhasználó kezelés";
        public static string AddUser = "Felhasználó hozzáadása";
        public static string EditUser = "Felhasználó szerkesztése";
        public static string DeleteUser = "Felhasználó törlése";
        public static string ConfirmDeleteUser = "Biztosan törölni szeretné ezt a felhasználót? Ezt a műveletet nem lehet visszavonni.";
        public static string UserDeleteSuccess = "A felhasználó sikeresen törölve.";
        public static string SelectUser = "Kérjük, válasszon ki egy felhasználót.";

        // User edit forms
        public static string UserDetails = "Felhasználó adatai";
        public static string Name = "Név";
        public static string Phone = "Telefon";
        public static string AreaCode = "Körzetszám";
        public static string DateOfBirth = "Születési dátum";
        public static string Role = "Szerepkör";
        public static string LicenseNumber = "Vezetői engedély száma";
        public static string LicenseExpiry = "Vezetői engedély lejárata";
        public static string ProfilePicture = "Profilkép";
        public static string Browse = "Tallózás...";
        public static string UserAddSuccess = "Felhasználó sikeresen hozzáadva.";
        public static string UserUpdateSuccess = "Felhasználó sikeresen frissítve.";
        public static string PasswordRequired = "Új felhasználóhoz jelszó megadása kötelező.";
        public static string PasswordKeepCurrent = "Jelszó (hagyja üresen a jelenlegi megtartásához)";
        public static string IBAN = "IBAN szám";

        // Car management
        public static string CarManagement = "Autó kezelés";
        public static string AddCar = "Autó hozzáadása";
        public static string EditCar = "Autó szerkesztése";
        public static string DeleteCar = "Autó törlése";
        public static string CarDetails = "Autó adatai";
        public static string Brand = "Márka";
        public static string Model = "Modell";
        public static string Year = "Évjárat";
        public static string Type = "Típus";
        public static string Condition = "Állapot";
        public static string HourlyRate = "Óradíj";
        public static string DailyRate = "Napidíj";
        public static string RegNumber = "Rendszám";
        public static string Seats = "Ülések";
        public static string Doors = "Ajtók";
        public static string[] Mileage = {"Kilóméteróra állás", "Mileage"};
        public static string FuelType = "Üzemanyag típusa";
        public static string Transmission = "Sebességváltó";
        public static string Description = "Leírás";
        public static string Insurance = "Biztosítás";
        public static string Images = "Képek";
        public static string AddImage = "Kép hozzáadása";
        public static string CarAddSuccess = "Autó sikeresen hozzáadva.";
        public static string CarUpdateSuccess = "Autó sikeresen frissítve.";
        public static string ConfirmDeleteCar = "Biztosan törölni szeretné ezt az autót? Ezt a műveletet nem lehet visszavonni.";
        public static string CarDeleteSuccess = "Az autó sikeresen törölve.";
        public static string SelectCar = "Kérjük, válasszon ki egy autót.";
        public static string BasePrice = "Alap díj";
        public static string Location = "Helyadat";

        // Car extras management
        public static string CarExtrasManagement = "Autó extrák kezelése";
        public static string AddExtras = "Extra hozzáadása";
        public static string EditExtras = "Extra szerkesztése";
        public static string DeleteExtras = "Extra törlése";
        public static string ExtraName = "Extra neve";
        public static string ExtraPrice = "Extra ára";
        public static string ExtraAddSuccess = "Extra sikeresen hozzáadva.";
        public static string ExtraUpdateSuccess = "Extra sikeresen frissítve.";
        public static string ConfirmDeleteExtra = "Biztosan törölni szeretné ezt az extrát?";
        public static string ExtraDeleteSuccess = "Az extra sikeresen törölve.";

        // Order management
        public static string OrderManagement = "Rendelés kezelés";
        public static string AddOrder = "Rendelés hozzáadása";
        public static string EditOrder = "Rendelés szerkesztése";
        public static string CancelOrder = "Rendelés törlése";
        public static string OrderDetails = "Rendelés részletei";
        public static string Customer = "Ügyfél";
        public static string Car = "Autó";
        public static string StartDate = "Kezdő dátum";
        public static string EndDate = "Befejező dátum";
        public static string PickupLocation = "Felvétel helye";
        public static string DropoffLocation = "Leadás helye";
        public static string Status = "Állapot";
        public static string PaymentStatus = "Fizetési állapot";
        public static string DiscountCode = "Kedvezménykód";
        public static string ExtendedRental = "Hosszabbított bérlés";
        public static string PaymentAmount = "Fizetés összege";
        public static string TaxAmount = "Adó összege";
        public static string PaymentMethod = "Fizetési mód";
        public static string InvoiceAddress = "Számlázási cím";
        public static string OrderAddSuccess = "Rendelés sikeresen hozzáadva.";
        public static string OrderUpdateSuccess = "Rendelés sikeresen frissítve.";
        public static string ConfirmCancelOrder = "Biztosan törölni szeretné ezt a rendelést?";
        public static string ConfirmCancel = "Rendelés törlése";
        public static string OrderCancelSuccess = "A rendelés sikeresen törölve.";
        public static string SelectOrder = "Kérjük, válasszon ki egy rendelést.";
        public static string SelectOrderCancel = "Kérjük, válasszon ki egy rendelést a megszaításához.";
        public static string OrderID = "Rendelés ID";
        public static string PaymentDate = "Fizetés ideje";
        public static string DateEroor = "A befejező dátumnak későbbinek kell lennie a kezdő dátumnál.";
        public static string ReqFields = "Kérjük, töltse ki az összes kötelező mezőt.";
        public static string LocationError = "Nem sikerült meghatározni a helyet.";

        // Reports
        public static string ReportType = "Jelentés típusa";
        public static string GenerateReport = "Jelentés generálása";
        public static string ExportToCsv = "Exportálás CSV-be";
        public static string RevenueReport = "Bevétel jelentés";
        public static string CarUtilizationReport = "Autó kihasználtság jelentés";
        public static string CustomerActivityReport = "Ügyfél aktivitás jelentés";
        public static string CarTypePopularityReport = "Autó típus népszerűségi jelentés";
        public static string PaymentMethodStatistics = "Fizetési mód statisztikák";

        // Reviews management
        public static string ReviewManagement = "Értékelés kezelés";
        public static string Reviewer = "Értékelő";
        public static string Reviewee = "Értékelt";
        public static string ReviewMessage = "Értékelés üzenete";
        public static string Rating = "Értékelés";
        public static string ReviewDate = "Értékelés dátuma";
        public static string AddReview = "Értékelés hozzáadása";
        public static string EditReview = "Értékelés szerkesztése";
        public static string DeleteReview = "Értékelés törlése";
        public static string ReviewDetails = "Értékelés részletei";
        public static string ReviewAddSuccess = "Értékelés sikeresen hozzáadva.";
        public static string ReviewUpdateSuccess = "Értékelés sikeresen frissítve.";
        public static string ConfirmDeleteReview = "Biztosan törölni szeretné ezt az értékelést?";
        public static string ReviewDeleteSuccess = "Az értékelés sikeresen törölve.";
        public static string SelectReview = "Kérjük, válasszon ki egy értékelést.";

        // Comments management
        public static string CommentManagement = "Hozzászólás kezelés";
        public static string CommentMessage = "Hozzászólás üzenete";
        public static string CommentStar = "Csillag értékelés";
        public static string CommentDate = "Hozzászólás dátuma";
        public static string RatingCategory = "Értékelési kategória";
        public static string Flagged = "Megjelölt";
        public static string AddComment = "Hozzászólás hozzáadása";
        public static string EditComment = "Hozzászólás szerkesztése";
        public static string DeleteComment = "Hozzászólás törlése";
        public static string FlagComment = "Hozzászólás megjelölése";
        public static string CommentDetails = "Hozzászólás részletei";
        public static string CommentAddSuccess = "Hozzászólás sikeresen hozzáadva.";
        public static string CommentUpdateSuccess = "Hozzászólás sikeresen frissítve.";
        public static string ConfirmDeleteComment = "Biztosan törölni szeretné ezt a hozzászólást?";
        public static string CommentDeleteSuccess = "A hozzászólás sikeresen törölve.";
        public static string SelectComment = "Kérjük, válasszon ki egy hozzászólást.";

        // Notification management
        public static string NotificationManagement = "Értesítés kezelés";
        public static string Message = "Üzenet";
        public static string CreatedAt = "Létrehozva";
        public static string Read = "Olvasott";
        public static string Unread = "Olvasatlan";
        public static string AddNotification = "Értesítés hozzáadása";
        public static string EditNotification = "Értesítés szerkesztése";
        public static string DeleteNotification = "Értesítés törlése";
        public static string MarkAsRead = "Megjelölés olvasottként";
        public static string MarkAsUnread = "Megjelölés olvasatlanként";
        public static string NotificationDetails = "Értesítés részletei";
        public static string NotificationAddSuccess = "Értesítés sikeresen hozzáadva.";
        public static string NotificationUpdateSuccess = "Értesítés sikeresen frissítve.";
        public static string ConfirmDeleteNotification = "Biztosan törölni szeretné ezt az értesítést?";
        public static string NotificationDeleteSuccess = "Az értesítés sikeresen törölve.";
        public static string SelectNotification = "Kérjük, válasszon ki egy értesítést.";
        public static string PasswordKeepCurrentHungarian = "Jelszó (hagyja üresen a jelenlegi megtartásához)";
        public static string SearchByDate = "Keresés dátum szerint";
        public static string ProfileData = "Profil adatok";
        public static string LicenseData = "Jogosítvány adatok";
        public static string ContactData = "Kapcsolat adatok";
        public static string PersonalData = "Személyes adatok";
        public static string UserNotFound = "Felhasználó nem található";
        public static string ErrorLoadingUserData = "Hiba a felhasználói adatok betöltésekor";
        public static string ErrorLoadingImage = "Hiba a kép betöltésekor";
        public static string SelectUserToEdit = "Kérjük, válasszon ki egy felhasználót a szerkesztéshez";
        public static string SelectCarToEdit = "Kérjük, válasszon ki egy autót a szerkesztéshez";
        public static string ConfirmUserDeletion = "Biztos, hogy törölni szeretné ezt a felhasználót? Ez a művelet nem vonható vissza.";
        public static string UserDeleted = "A felhasználó sikeresen törölve.";
        public static string FailedToDeleteUser = "Nem sikerült törölni a felhasználót.";
        public static string ErrorDeletingUser = "Hiba a felhasználó törlésekor";

        //Condition EN/HU
        public static string[] AllCondition = { "Összes állapot", "új", "kiváló", "jó", "megfelelő", "gyenge"};
        public static string[] AllConditionEn = { "All Conditions", "new", "excellent", "good", "fair", "poor" };

        // EN/HU try
        public static string[] AllType = { "Összes típus", "sedan", "SUV", "ferdehátú", "kabrió", "kupé", "kombi", "pickup", "minibusz" };
        public static string[] AllTypeEn = { "All Types", "sedan", "suv", "hatchback", "convertible", "coupe", "wagon", "pickup", "minivan" };

        public static string[] OrderStatushu = { "Összes", "függőben", "megerősítve", "teljesítve", "lemondva", "meghosszabbítva" };
        public static string[] OrderStatusen = { "All", "pending", "confirmed", "completed", "cancelled", "extended" };

        public static string[] PaymentStatushu = { "függőben", "fizetve", "sikertelen", "visszatérítve", "részben fizetve" };
        public static string[] PaymentStatusen = { "pending", "paid", "failed", "refunded", "partially_paid" };

        public static string[] PaymentMethodhu = { "bankkártya", "PayPal", "banki átutalás", "készpénz", "Bitcoin" };
        public static string[] PaymentMethoden = { "credit_card", "paypal", "bank_transfer", "cash", "bitcoin" };
        public static string[] Notificationen = { "read", "unread" };

        public static string[] RatingCategoryhu = { "Összes", "kényelem", "teljesítmény", "üzemanyag-hatékonyság", "biztonság", "ár-érték arány" };
        public static string[] RatingCategoryen = { "All", "comfort", "performance", "fuel_efficiency", "safety", "value_for_money" };

        public static string[] Transmissionhu = { "automata", "manuális", "félautomata", "CVT" };
        public static string[] Transmissionen = { "automatic", "manual", "semi-automatic", "CVT" };

        public static string[] Fuelhu = { "benzin", "dízel", "elektromos", "hibrid", "gáz" };
        public static string[] Fuelen = { "petrol", "diesel", "electric", "hybrid", "gas" };
        // Message box helper
        public static string ShowMessage(string message, string title, bool isError = false)
        {
            System.Windows.Forms.MessageBox.Show(
                message,
                title,
                System.Windows.Forms.MessageBoxButtons.OK,
                isError ? System.Windows.Forms.MessageBoxIcon.Error : System.Windows.Forms.MessageBoxIcon.Information);

            return message;
        }

        public static bool ShowConfirmation(string message, string title)
        {
            return System.Windows.Forms.MessageBox.Show(
                message,
                title,
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
        }
    }
}
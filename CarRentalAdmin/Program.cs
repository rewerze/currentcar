using System;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                TestDatabaseConnection();
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az alkalmazás inicializálása (létrehozása) során: " + ex.Message,
                    "Inditási HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void TestDatabaseConnection()
        {
            try
            {
                // adatbázis kapcsolat teszt
                string query = "SELECT 1";
                DatabaseOptimizer.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Az adatbázis-csatlakozás hibás. Kérjük, ellenőrizze az adatbázis beállításait.\n\n" + ex.Message);
            }
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    internal class DatabaseOptimizer
    {
        // Adatbázis kapcsolat
        const string server = "Server=localhost;Port=3306;Database=currentcar;Uid=root;Pwd=";

        //Lekérdezés végrehajtása (SELECT) → DataTable formában visszaadja
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (Database db = new Database(query)) // Használja a Database.cs osztályt
                {
                    dataTable.Load(db.Dr); // Beolvassa a lekérdezés eredményét
                    db.closeCon();         // Bezárja a kapcsolatot
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database query error: " + ex.Message);
            }

            return dataTable;
        }

        //INSERT, UPDATE vagy DELETE parancs végrehajtása → visszaadja az érintett sorok számát
        public static int ExecuteNonQuery(string query)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        result = command.ExecuteNonQuery(); // Végrehajtás
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database command error: " + ex.Message);
            }

            return result;
        }

        //Egyetlen értéket ad vissza (pl.: COUNT(*) vagy SUM())
        public static object ExecuteScalar(string query)
        {
            object result = null;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        result = command.ExecuteScalar(); // Egy érték visszaadása
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database scalar query error: " + ex.Message);
            }

            return result;
        }

        //Paraméterezett SELECT lekérdezés (SQL injection ellen véd)
        public static DataTable ExecuteParameterizedQuery(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Paraméterek hozzáadása
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database parameterized query error: " + ex.Message);
            }

            return dataTable;
        }

        //Paraméterezett INSERT/UPDATE/DELETE (SQL injection ellen véd)
        public static int ExecuteParameterizedNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        result = command.ExecuteNonQuery(); // Végrehajtás
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database parameterized command error: " + ex.Message);
            }

            return result;
        }
    }
}

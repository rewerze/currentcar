using MySql.Data.MySqlClient;
using System;

internal class Database : IDisposable
{
    // Az adatbázis elérhetőségi adatai (szerver, adatbázis neve, felhasználó, jelszó)
    const string server = "Server=localhost;Port=3306;Database=currentcar;Uid=root;Pwd=";

    MySqlConnection connect;
    MySqlCommand command;
    MySqlDataReader dr;
    private bool disposed = false;

    // Konstruktor: elindítja a kapcsolatot, lefuttat egy SQL lekérdezést, és eltárolja az eredményt
    public Database(string sql)
    {
        connect = new MySqlConnection(server);
        connect.Open();
        command = new MySqlCommand(sql, connect);
        Dr = command.ExecuteReader();
    }

    // Olvasható adat (pl.: SELECT után)
    public MySqlDataReader Dr { get => dr; set => dr = value; }

    // Kapcsolat bezárása (ha még nyitva van)
    public void closeCon()
    {
        if (connect != null && connect.State != System.Data.ConnectionState.Closed)
        {
            connect.Close();
        }
    }

    // IDisposable implementálása: automatikusan bezár mindent ha kilépünk
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Erőforrások felszabadítása (Reader, Command, Connection)
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
                if (command != null)
                {
                    command.Dispose();
                }
                if (connect != null)
                {
                    connect.Close();
                    connect.Dispose();
                }
            }
            disposed = true;
        }
    }

    // Ha nem hívjuk meg a Dispose-t, akkor a destruktor ezt megteszi
    ~Database()
    {
        Dispose(false);
    }
}

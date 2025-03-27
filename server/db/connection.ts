import mysql, { Pool, PoolConnection } from "mysql2/promise";

const pool = mysql.createPool({
  host: "localhost",
  user: "root",
  database: "currentcar",
  password: "",
});

export interface IDBConnection {
  query<T = unknown>(sql: string, options?: unknown): Promise<T[]>;
}

class DB implements IDBConnection {
  private static instance: DB;
  public pool: mysql.Pool;

  constructor() {
    this.pool = mysql.createPool({
      host: "localhost",
      user: "root",
      database: "currentcar",
      password: "Titkos11",
    });
  }

  static getInstance(): DB {
    if (!DB.instance) {
      DB.instance = new DB();
    }
    return DB.instance;
  }

  async query<T = unknown>(sql: string, options: any[] = []): Promise<T[]> {
    const [rows] = await this.pool.execute<mysql.RowDataPacket[]>(sql, options);
    return rows as T[];
  }

  async close() {
    await this.pool.end();
  }
}

const db = DB.getInstance();
export default db;

// pool.getConnection()
//     .then(async (connection: PoolConnection) => {
//         console.log("Successfully connected to MySQL!");
//         connection.release();
//     })
//     .catch((error: Error) => {
//         console.log("Error connecting to MySQL: ", error);
//     })

// export default pool;

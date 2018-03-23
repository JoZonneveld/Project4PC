using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mono.Data.Sqlite;


namespace XamarinApp
{
    public class DB : IDisposable
    {
        private SqliteConnection conn;
        private IDbCommand dbcmd;
        public DB()
        {

            // create a new database connection:
            const string connectionString = "URI=file:test.db";
            conn = new SqliteConnection(connectionString);
            conn.Open();

            dbcmd = conn.CreateCommand();
        }

        public void CreateTable()
        {
            SqliteCommand sqlite_cmd = conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            // Now lets execute the SQL ;-)
            sqlite_cmd.ExecuteNonQuery();
        }

        public void insert()
        {
            SqliteCommand sqlite_cmd = conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'tesst1221')";

            // Now lets execute the SQL ;-)
            sqlite_cmd.ExecuteNonQuery();
        }

        public void get()
        {
            SqliteCommand sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM test";

            SqliteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                // System.Console.WriteLine("DEBUG Output: '" + sqlite_datareader["text"] + "'");

                object idReader = sqlite_datareader.GetValue(0);
                string textReader = sqlite_datareader.GetString(1);

                Console.WriteLine(idReader + " '" + textReader + "' " + "\n");
            }

        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
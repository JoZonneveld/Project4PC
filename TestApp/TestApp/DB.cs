using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;


namespace TestApp
{
    public class DB : IDisposable
    {
        private SQLiteConnection conn;
        public DB()
        {
            // create a new database connection:
            this.conn =
                new SQLiteConnection("Data Source=database.sqlite;Version=3;");
            conn.Open();
        }

        public void CreateTable()
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            // Now lets execute the SQL ;-)
            sqlite_cmd.ExecuteNonQuery();
        }

        public void insert()
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'tesst1221')";

            // Now lets execute the SQL ;-)
            sqlite_cmd.ExecuteNonQuery();
        }

        public void get()
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM test";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

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
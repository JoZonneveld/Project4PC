using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace DatabaseTest.Database
{
    public class DB
    {
        private string dbPath;
        private SQLiteConnection DbConn;

        public DB()
        {
            //sqlite databasepath
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

            // sqlite connection
            DbConn = new SQLiteConnection(dbPath);
        }

        public SQLiteConnection Conn()
        {
            return DbConn;
        }

        public void Query(string query)
        {
            DbConn.Execute(query);
        }

        public void CreateTable<T>()
        {
            try
            {
                DbConn.CreateTable(typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert<T>(T Object)
        {
            try
            {
                DbConn.Insert(Object);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TableQuery<T> Get<T>() where T : new()
        {
            try
            {
                return DbConn.Table<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
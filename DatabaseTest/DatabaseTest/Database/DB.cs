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
        private SQLiteConnection db;

        public DB()
        {
            //sqlite databasepath
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

            // sqlite connection
            db = new SQLiteConnection(dbPath);
        }

        public SQLiteConnection Conn()
        {
            return db;
        }

        public void CreateTable<T>()
        {
            try
            {
                db.CreateTable(typeof(T));
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
                db.Insert(Object);
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
                return db.Table<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
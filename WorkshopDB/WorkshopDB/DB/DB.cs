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

namespace WorkshopDB.DB
{
    class DB
    {
        private SQLiteConnection DbConn;
        public DB()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

            DbConn = new SQLiteConnection(dbPath);
        }

        public void createTable<T>()
        {
            DbConn.CreateTable(typeof(T));
        }

        public void Insert<T>(T Object)
        {
            DbConn.Insert(Object);
        }

        public IEnumerable<T> Select<T>(string query) where T : new()
        {
            return DbConn.DeferredQuery<T>(query);
        }

        public IEnumerable<T> Select<T>(string query, string filter) where T : new()
        {
            return DbConn.DeferredQuery<T>(query, filter);
        }

        public IEnumerable<T> Select<T>(string query, string[] filters) where T : new()
        {
            return DbConn.DeferredQuery<T>(query, filters);
        }

        public void Execute(string query)
        {
            DbConn.Execute(query);
        }

        public void Execute(string query, string filter)
        {
            DbConn.Execute(query, filter);
        }

        public void Execute(string query, string[] filters)
        {
            DbConn.Execute(query, filters);
        }
    }
}
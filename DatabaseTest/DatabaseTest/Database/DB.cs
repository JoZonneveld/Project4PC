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
        private SQLiteConnection DbConn;

        #region Connection
        public DB()
        {
            //sqlite databasepath
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

            // sqlite connection
            DbConn = new SQLiteConnection(dbPath);
        }

        public SQLiteConnection Conn()
        {
            return DbConn;
        }

        #endregion

        #region Select 

        public IEnumerable<T> SelectFrom<T>(string query) where T : new() // without WHERE filter
        {
            return DbConn.DeferredQuery<T>(query);
        }

        public IEnumerable<T> SelectFrom<T>(string query, string filter) where T : new() // with WHERE filter
        {
            return DbConn.DeferredQuery<T>(query, filter);
        }

        #endregion

        #region Delete

        public void DeleteFrom(string query) // without WHERE filter
        {
            DbConn.Execute(query);
        }

        public void DeleteFrom(string query, string filter) // with WHERE filter
        {
            DbConn.Execute(query, filter);
        }

        #endregion

        #region Create

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

        #endregion

        #region Insert

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

        #endregion
    }
}
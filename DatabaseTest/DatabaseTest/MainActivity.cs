using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Widget;
using Android.OS;
using Database;
using SQLite;

namespace DatabaseTest
{
    [Activity(Label = "DatabaseTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<string> Items;
        private ListView ListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

            // sqlite connection
            var db = new SQLiteConnection(dbPath);

            db.CreateTable<Person>();

            
            //create Person
            Person person = new Person(1, "Joost");

            db.Insert(person);

            var Table = db.Table<Person>();
            Items = new List<string>();
            foreach (var item in Table)
            {
                Person nPerson = new Person(item.Id, item.Name);

                Items.Add(nPerson.Name);
            }

            ListView = FindViewById<ListView>(Resource.Id.myListView);
            

            ArrayAdapter<string> Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);

            ListView.Adapter = Adapter;
        }
    }
}


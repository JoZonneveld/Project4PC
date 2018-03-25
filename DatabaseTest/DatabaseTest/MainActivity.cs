using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Widget;
using Android.OS;
using Database;
using DatabaseTest.Database;
using SQLite;

namespace DatabaseTest
{
    [Activity(Label = "DatabaseTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<string> Items;
        private ListView ListView;
        private Button NewButton, UpdateButton;
        private EditText Input;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            

            //DB connection
            DB db = new DB();
            db.CreateTable<Person>();


            // calls db createtable function Requires a Object like Person
            //db.CreateTable<Person>();

            //create Person to insert into the db
            //Person person = new Person(1, "Joost");

            // Calls db Insert into table function requires an object to send with it
            //db.Insert(person);

            // Calls db Query and gets all data from a table in the db
            //var Table = db.Get<Person>();

            //Items = new List<string>();
            //foreach (var item in Table)
            //{
            //    Person nPerson = new Person(item.Id, item.Name);

            //    Items.Add(nPerson.Name); 
            //}

            //create items (buttons, list text...)
            NewButton = FindViewById<Button>(Resource.Id.NewObject);
            UpdateButton = FindViewById<Button>(Resource.Id.UpdateGet);
            Input = FindViewById<EditText>(Resource.Id.NewPerson);
            ListView = FindViewById<ListView>(Resource.Id.myListView);

            Items = new List<string>();

            ArrayAdapter<string> Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);

            ListView.Adapter = Adapter;

            NewButton.Click += delegate
            {
                //db.Conn().Execute("DELETE FROM person"); //executes a delete function on db
                if (Input.Text != "")
                {
                    Person test = new Person(1, Input.Text);
                    db.Insert(test);
                }
            };

            UpdateButton.Click += delegate
            {
                var temp = db.Get<Person>();
                Items.Clear();
                foreach (var row in temp)
                {
                    Items.Add(row.Name);
                }
                Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);
                ListView.Adapter = Adapter;

            };

            
        }
    }
}


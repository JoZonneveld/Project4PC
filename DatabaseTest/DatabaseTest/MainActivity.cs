using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Database;
using DatabaseTest.Database;
using DatabaseTest.Items;
using SQLite;

namespace DatabaseTest
{
    [Activity(Label = "DatabaseTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<string> Items;
        private ListView ListView;
        private Button NewButton, UpdateButton, CleanButton;
        private EditText Input;
        private ArrayAdapter<string> Adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            #region DB Conn

            DB db = new DB(); // create db conn
            db.CreateTable<Person>(); // Create test table (If not exists)

            #endregion

            //--------------------------------------------------------------------------------------------------------------------------

            #region Buttons, Lists, Texts

            // Initializing
            NewButton = FindViewById<Button>(Resource.Id.NewObject); // Button to create an Object in the db
            UpdateButton = FindViewById<Button>(Resource.Id.UpdateGet); // Button to Update the List
            CleanButton = FindViewById<Button>(Resource.Id.Clean); // Button to clear the db
            Input = FindViewById<EditText>(Resource.Id.NewPerson); // Input field to enter a name
            ListView = FindViewById<ListView>(Resource.Id.myListView); // List view for db results
            Items = new List<string>(); // List for the items in the db
            List<ButtonAction> Buttons = new List<ButtonAction>(); // List for buttons with Action

            #endregion

            //--------------------------------------------------------------------------------------------------------------------------

            #region Buttons

            Buttons.Add(new ButtonAction(NewButton, () =>
            {
                if (Input.Text != "")
                {
                    Person test = new Person(1, Input.Text);
                    db.Insert(test);
                }
            }));

            Buttons.Add(new ButtonAction(UpdateButton, () =>
            {
                IEnumerable<Person> Query;
                if (Input.Text != "")
                {
                    Query = db.SelectFrom<Person>("SELECT * FROM Person WHERE Name =?", Input.Text);
                }
                else
                {
                    Query = db.SelectFrom<Person>("SELECT * FROM Person");
                }

                Items.Clear();
                foreach (var row in Query.ToList())
                {
                    Items.Add(row.Name);
                }
                Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);
                ListView.Adapter = Adapter;
            }));

            Buttons.Add(new ButtonAction(CleanButton, () =>
            {
                if (Input.Text != "")
                {
                    db.DeleteFrom("DELETE FROM Person WHERE Name =?", Input.Text);
                }
                else
                {
                    db.DeleteFrom("DELETE FROM Person");
                }

            }));

            #endregion

            // Update all buttons with the click listener
            foreach (var button in Buttons)
            {
                button.Activate();
            }
        }
    }
}


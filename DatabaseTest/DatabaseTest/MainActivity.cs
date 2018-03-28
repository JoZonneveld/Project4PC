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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            

            //DB connection
            DB db = new DB();
            db.CreateTable<Person>();


            //create items (buttons, list text...)
            NewButton = FindViewById<Button>(Resource.Id.NewObject);
            UpdateButton = FindViewById<Button>(Resource.Id.UpdateGet);
            CleanButton = FindViewById<Button>(Resource.Id.Clean);
            Input = FindViewById<EditText>(Resource.Id.NewPerson);
            ListView = FindViewById<ListView>(Resource.Id.myListView);

            Items = new List<string>();

            ArrayAdapter<string> Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);

            ListView.Adapter = Adapter;

            List<ButtonAction> Buttons =  new List<ButtonAction>();
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
                var Query = db.SelectFrom<Person>("SELECT * FROM Person WHERE Name = ? ", Input.Text);
                
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
                db.DeleteFrom("DELETE FROM Person WHERE Name =?", Input.Text);
            }));

            foreach (var button in Buttons)
            {
                button.Activate();
            }
        }
    }
}


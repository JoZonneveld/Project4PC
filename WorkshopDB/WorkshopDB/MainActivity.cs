using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using WorkshopDB.DB;

namespace WorkshopDB
{

    //github.com/JoZonneveld/Project4PC
    

    [Activity(Label = "WorkshopDB", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button NewButton, UpdateButton, DeleteButton;
        private ListView View;
        private EditText Input;
        private List<string> res = new List<string>();
        private ArrayAdapter<string> adapter;
        DB.DB db = new DB.DB();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            db.createTable<Person>();

            NewButton = FindViewById<Button>(Resource.Id.newButton);
            UpdateButton = FindViewById<Button>(Resource.Id.UpdateButton);
            DeleteButton = FindViewById<Button>(Resource.Id.DeleteButton);

            List<buttonAction> Buttons = new List<buttonAction>();

            Buttons.Add(new buttonAction(NewButton, (() =>
            {
                if (Input.Text != "")
                {
                    db.Insert(new Person(4, Input.Text));
                }
            })));

            Buttons.Add(new buttonAction(UpdateButton, (() =>
            {
                string query = "";

                IEnumerable<Person> Lijst;

                if (Input.Text != "")
                {
                    Lijst = db.Select<Person>("SELECT * FROM Person WHERE Name =?", new []{Input.Text});
                }
                else
                {
                    Lijst = db.Select<Person>("SELECT * FROM Person");
                }

                res.Clear();
                foreach (var Item in Lijst.ToList())
                {
                    res.Add(Item.ToString());
                }

                adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, res);
                View.Adapter = adapter;
            })));

            Buttons.Add(new buttonAction(DeleteButton, (() =>
            {
                if (Input.Text != "")
                {
                    db.Execute("DELETE FROM Person WHERE Name =?", Input.Text);
                }
                else
                {
                    db.Execute("DELETE FROM Person");
                }
            })));

            View = FindViewById<ListView>(Resource.Id.ListView);

            Input = FindViewById<EditText>(Resource.Id.Input);


            foreach (var button in Buttons)
            {
                button.execute();
            }
        }
    }
}
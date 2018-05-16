using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace Screens
{
    [Activity(Label = "Screens", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button Next;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Next = FindViewById<Button>(Resource.Id.Next);

            Next.Click += delegate { StartActivity(typeof(Activity2)); };
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.menu1, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Screen2:
                    //do something
                    StartActivity(typeof(Activity2));
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


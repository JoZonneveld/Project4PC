using Android.App;
using Android.Widget;
using Android.OS;

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
    }
}


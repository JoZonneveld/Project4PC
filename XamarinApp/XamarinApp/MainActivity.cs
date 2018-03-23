using System.Reflection.Emit;
using Android.App;
using Android.Bluetooth;
using Android.Locations;
using Android.Widget;
using Android.OS;
using Android.Renderscripts;
using Android.Views;

namespace XamarinApp
{
    [Activity(Label = "XamarinApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}


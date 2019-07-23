using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;

namespace TestXamarin.Droid
{
    [Activity(Label = "TestXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            //Demande d'autorisation
            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) == Permission.Granted)
            {

            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadContacts }, 1);
                Toast.MakeText(this, "Veuillez Acceptez la Lecture de Repertoire", ToastLength.Long);
            }

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {

            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, 1); 
            }

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessLocationExtraCommands) == Permission.Granted)
            {

            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessLocationExtraCommands }, 1);
            }
            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == Permission.Granted)
            {

            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation }, 1);
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);
            
     
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

    }


}
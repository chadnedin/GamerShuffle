using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace GamerShuffle
{
    [Activity(Label = "searchActivity")]
    public class searchActivity : Activity
    {


        //Thank you Abinodh for assistance with building personal api links, 
        //to help streamline my webrequest and app's design intent. 
        
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.searchScreen);
            // Create your application here

            var txtView = FindViewById<TextView>(Resource.Id.textView1);
            var btnps4 = FindViewById<Button>(Resource.Id.btnPs4);
            var btnxbox1 = FindViewById<Button>(Resource.Id.btnXbox1);
            var btnnintendoSwitch = FindViewById<Button>(Resource.Id.btnNintendoSwitch);
            //var spinnertxt = FindViewById<Spinner>(Resource.Id.spinner);

            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            txtView.SetTypeface(tf, TypefaceStyle.Normal);
            btnps4.SetTypeface(tf, TypefaceStyle.Bold);
            btnxbox1.SetTypeface(tf, TypefaceStyle.Bold);
            btnnintendoSwitch.SetTypeface(tf, TypefaceStyle.Bold);
            Console.Out.WriteLine("Made it passed the declare");

            

            btnps4.Click += ps4_Click;
            btnxbox1.Click += xbox1_Click;
            btnnintendoSwitch.Click += nintendoSwitch_Click;
           
        }

        private void ps4_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Getting your Ps4 Game list", ToastLength.Short).Show();
            StartActivity(typeof(GameListActivity));
        }
        private void xbox1_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Getting your Xbox One Game list", ToastLength.Short).Show();
            StartActivity(typeof(xbox1Activity));
        }

        private void nintendoSwitch_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Getting your Nintendo Switch Game list", ToastLength.Short).Show();
            StartActivity(typeof(nintendoSwitchActivity));
        }


        
    }
}
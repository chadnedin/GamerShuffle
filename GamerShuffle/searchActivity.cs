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
      

        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    PART1 = string.Format(PART1, (sender as Button).Text);
        //    var intent = new Intent(this, typeof(GameListActivity));
        //    intent.PutExtra("URL", PART1);
        //}

        
        protected override void OnCreate(Bundle bundle)
        {
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

            //spinnertxt.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            //Console.Out.WriteLine("got herreee 1212");
            //var adapter = ArrayAdapter.CreateFromResource(
            //        this, Resource.Array.platforms_array, Android.Resource.Layout.SimpleSpinnerItem);
            //Console.Out.WriteLine("got to this point 1212123");
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //spinnertxt.Adapter = adapter;

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


        //private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    Spinner spinnerVal = (Spinner)sender;
        //    Console.Out.WriteLine("GOT TO THE TOASTY MSG");
        //    string toast = string.Format("The selected platform is {0}", spinnerVal.GetItemAtPosition(e.Position));
        //    Toast.MakeText(this, toast, ToastLength.Long).Show();
        //    switch (e.Position)
        //    {
        //        case 0:

        //            Console.Out.WriteLine("Platform Selection");
        //            break;
        //        case 1:
        //            platformValue = "48";
        //            Console.Out.WriteLine("playstation");
        //            break;
        //        case 2:
        //            platformValue = "48";
        //            Console.Out.WriteLine("xbox");
        //            break;

        //        case 3:
        //            platformValue = "48";
        //            Console.Out.WriteLine("nintendo");
        //            break;
        //    }

        //    var GameListActivity = new Intent(this, typeof(GameListActivity));
        //    GameListActivity.PutExtra("platformValue", "Data from searchActivity");
        //    StartActivity(GameListActivity);

        //}


        //protected void searchClick(object sender, EventArgs e)
        //{
        //    Games game = new Games();
        //    platformValue = game.platform;
        //    GameService.passThePlatform(platformValue);
        //    Intent gameDetailIntent = new Intent(this, typeof(GameListActivity));
        //    string gameJson = JsonConvert.SerializeObject(game);
        //    gameDetailIntent.PutExtra("game", gameJson);
        //    StartActivity(gameDetailIntent);
        //    StartActivity(typeof(GameListActivity));


        //}
    }
}
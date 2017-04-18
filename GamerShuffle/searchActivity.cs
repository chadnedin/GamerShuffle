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

namespace GamerShuffle
{
    [Activity(Label = "searchActivity")]
    public class searchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.searchScreen);
            // Create your application here

            var txtView = FindViewById<TextView>(Resource.Id.textView1);
            var btnText = FindViewById<Button>(Resource.Id.btnEnter);
            var spinnertxt = FindViewById<Spinner>(Resource.Id.spinner);
            var spinnertxt2 = FindViewById<Spinner>(Resource.Id.spinner2);
            var spinnertxt3 = FindViewById<Spinner>(Resource.Id.spinner3);
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            txtView.SetTypeface(tf, TypefaceStyle.Normal);
            btnText.SetTypeface(tf, TypefaceStyle.Bold);
 //           spinnertxt.SetTypeface(tf, TypefaceStyle.Normal);



 //           //Searching api
 //           btnText.Click += async (sender, e) =>
 //           {
 //               Task<HttpResponse<MyClass>> response = Unirest.get("https://igdbcom-internet-game-database-v1.p.mashape.com/genres/?fields=*&limit=40")
 //.header("X-Mashape-Key", "SKeRyjqczNmshxjnmBCyjgTcCNx9p1DQpALjsnREie6fUXs6y4")
 //.asJson();
 //           }

                //genre spinner
                Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.genres_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            // raiting spinner
            Spinner spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);

            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner3_ItemSelected);
            var adapter3 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.raitings_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner3.Adapter = adapter3;

            // platform spinner
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);

            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner2_ItemSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.platforms_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;

        }

        //raiting spinner select
        private void spinner3_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner3 = (Spinner)sender;

            string toast = string.Format("The selected raiting is {0}", spinner3.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        //platform spinner select
        private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner2 = (Spinner)sender;

            string toast = string.Format("The selected platform is {0}", spinner2.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        //genre spinner select
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The selected genre is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Json;
using System;
using System.Collections.Generic;

namespace GamerShuffle
{
    [Activity(Label = "GamerShuffle", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        ////private ListView gameListView;
        ////private List<GameService> gameListData;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            var txtView = FindViewById<TextView>(Resource.Id.textView1);
            var btnText = FindViewById<Button>(Resource.Id.btnEnter);
            //gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            txtView.SetTypeface(tf, TypefaceStyle.Normal);
            btnText.SetTypeface(tf, TypefaceStyle.Bold);

            btnText.Click += delegate

            {
                StartActivity(typeof(searchActivity));
               
            };
            
        }

        //public async void DownloadGamesListAsync()
        //{
        //    GameService service = new GameService();
        //    if (!service.isConnected(this))
        //    {
        //        Toast toast = Toast.MakeText(this, "Not conntected to internet. Please check your device network settings.", ToastLength.Short);
        //        toast.Show();
        //    }
        //    else
        //    {
        //        progressBar.Visibility = ViewStates.Visible;
        //        gameListData = await service.GetPOIListAsync();
        //        progressBar.Visibility = ViewStates.Gone;

        //        gameListAdapter = new GameListViewAdapter(this, gameListData);
        //        gameListView.Adapter = gameListAdapter;
        //    }
        //}
    }
}


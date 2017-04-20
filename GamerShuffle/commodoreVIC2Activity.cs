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
using System.Net;
using Newtonsoft.Json;

namespace GamerShuffle
{
    [Activity(Label = "commodor64Activity")]
    public class commodoreVIC2Activity : Activity
    {

        private ListView gameListView;
        private List<string> gameList;
        public const string API = "https://chadnedin.github.io/GamerShuffle/gamesCommodoreVIC2.json";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.GameList);
            RootObject4 r = JsonConvert.DeserializeObject<RootObject4>(json);
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");

            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            gameList = new List<string>();


            for (int i = 0; i < 10; i++)
            {
                gameList.Add("Name: " + r.gamesCommodoreVIC2[i].name + "\n\nGenre: " + r.gamesCommodoreVIC2[i].genres + "\n\nPlatform: " + r.gamesCommodoreVIC2[i].platform + "\n\nSummary: " + r.gamesCommodoreVIC2[i].summary + "\n\n\n");
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, gameList);
            gameListView.Adapter = adapter;
            gameListView.ItemClick += Listnames_ItemClick;
        }

        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
        }

    }

}

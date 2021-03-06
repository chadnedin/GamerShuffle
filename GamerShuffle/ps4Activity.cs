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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using Android.Graphics;

namespace GamerShuffle
{
    [Activity(Label = "GameListActivity")]
    public class GameListActivity : Activity
    {
        private ListView gameListView;
        private List<string> gameList;
        public const string API = "https://chadnedin.github.io/GamerShuffle/gamesPs4.json";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.GameList);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            
            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            gameList = new List<string>();
            

            for (int i = 0; i < 9; i++)
            {
                gameList.Add("Name: " + r.gamesPs4[i].name + "\n\nGenre: " + r.gamesPs4[i].genres + "\n\nPlatform: " + r.gamesPs4[i].platform + "\n\nSummary: " + r.gamesPs4[i].summary+"\n\n\n");
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
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
using System.Net;
using Newtonsoft.Json;

namespace GamerShuffle
{
    [Activity(Label = "xbox1Activity")]
    public class xbox1Activity : Activity
    {
        private ListView gameListView;
        private List<string> gameList;
        public const string API = "https://chadnedin.github.io/GamerShuffle/gamesXboxOne.json";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.GameList);
            RootObject3 r = JsonConvert.DeserializeObject<RootObject3>(json);


            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            gameList = new List<string>();
            

            for (int i = 0; i < 10; i++)
            {
                gameList.Add("Name: " + r.gamesXboxOne[i].name + "\n\nGenre: " + r.gamesXboxOne[i].genres + "\n\nPlatform: " + r.gamesXboxOne[i].platform + "\n\nSummary: " + r.gamesXboxOne[i].summary + "\n\n\n");
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
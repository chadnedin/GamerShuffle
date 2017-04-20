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
    [Activity(Label = "nintendoSwitchActivity")]
    public class nintendoSwitchActivity : Activity
    {

        private ListView gameListView;
        private List<string> gameList;
        public const string API = "https://chadnedin.github.io/GamerShuffle/gamesNintendoSwitch.json";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.GameList);
            RootObject2 r = JsonConvert.DeserializeObject<RootObject2>(json);
            

            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            gameList = new List<string>();
            

            for (int i = 0; i < 10; i++)
            {
                gameList.Add("Name: " + r.gamesNintendoSwitch[i].name + "\n\nGenre: " + r.gamesNintendoSwitch[i].genres + "\n\nPlatform: " + r.gamesNintendoSwitch[i].platform + "\n\nSummary: " + r.gamesNintendoSwitch[i].summary + "\n\n\n");
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

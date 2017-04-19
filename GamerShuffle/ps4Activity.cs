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
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.GameList);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            
            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            gameList = new List<string>();
            //gameList.Add("Name: " + r.gamesPs4[1].name);
            //gameList.Add("Item 1 \n somestuff");
            //gameList.Add("Item 2 \n somestuff");

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
































//        private ListView gameListView;
//        private List<string> gameList;
//        public const string API = "https://abinodh.github.io/Shopinator/jsonfile.json";

//        //string json = "{\"products\": [{\"id\": \"1\",\"name\": \"Staples FSC-Certified Copy Paper\"},{\"id\": \"2\",\"name\": \"Polypropylene Strap Kit with Metal Buckles\"},{\"id\": \"3\",\"name\": \"aafaf\"}]}";
//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            var json = new WebClient().DownloadString(API);
//            SetContentView(Resource.Layout.GameList);
//            RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
//            gameListView = FindViewById<ListView>(Resource.Id.gameTextView);
//            gameList = new List<string>();
//            gameList.Add("Item 0 \n somestuff");
//            gameList.Add("Item \n somestuff1");
//            gameList.Add("Item \n somestuff2");
//            gameList.Add("Item \n somestuff3");
//            gameList.Add("Item \n somestuff4");

//            //for (int i = 0; i < 6; i++)
//            //{
//            //    gameList.Add("Name: " + r.gamesPs4[i].name);
//            //}
//            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, gameList);
//            gameListView.Adapter = adapter;
//            gameListView.ItemClick += Listnames_ItemClick;
//        }

//        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
//        {
//            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
//        }
//        //+ "\n\nPlatform" + r.gamesPs4[i].platform + "\n\nGenres:" + r.gamesPs4[1].genres + "\n\nID: " + r.gamesPs4[i].id + "\n\nSummary: " + r.gamesPs4[i].summary + "\n\n\n"

//    }
//}
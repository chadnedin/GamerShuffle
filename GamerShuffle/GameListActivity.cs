using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GamerShuffle
{
    [Activity(Label = "GameListActivity")]
    public class GameListActivity : Activity
    {

        private ListView gameListView;
        private ProgressBar progressBar;
        private List<Games> gameListData;
        private GameListViewAdapter gameListAdapter;
        int scrollPosition;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameList);
            gameListView = FindViewById<ListView>(Resource.Id.gameListView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            DownloadGameListAsync();
            gameListView.ItemClick += GameClicked;
            string platformValue = Intent.GetStringExtra("platformValue") ?? "Data not available";
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            scrollPosition = savedInstanceState.GetInt("scroll_position");
        }

        public async void DownloadGameListAsync()
        {
            GameService service = new GameService();
            if (!service.isConnected(this))
            {
                Toast toast = Toast.MakeText(this, "Not connected to internet.", ToastLength.Short);
                toast.Show();
            }
            else
            {
                progressBar.Visibility = ViewStates.Visible;
                gameListData = await service.GetGameListAsync();
                progressBar.Visibility = ViewStates.Gone;

                gameListAdapter = new GameListViewAdapter(this, gameListData);
                gameListView.Adapter = gameListAdapter;
                gameListView.Post(() =>
                {
                    gameListView.SetSelection(scrollPosition);
                });
            }

        }

        protected void GameClicked(object sender, ListView.ItemClickEventArgs e)
        {
            //Fetching the object at user clicked position
            Games game = gameListData[(int)e.Id];
            Console.Out.WriteLine("Game Clicked: Name is {0}", game.name);
            Intent gameDetailIntent = new Intent(this,typeof(GameDetailActivity));
            string gameJson = JsonConvert.SerializeObject(game);
            gameDetailIntent.PutExtra("game", gameJson);
        }


    }
}
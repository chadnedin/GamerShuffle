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
using Newtonsoft.Json;

namespace GamerShuffle
{
    [Activity(Label = "GameDetailActivity")]
    public class GameDetailActivity : Activity
    {
        private Games _game;

        private TextView _gameTextView;
        private TextView _genresTextView;
        private TextView _platformTextView;
        private TextView _summaryTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameDetail);
            _gameTextView = FindViewById<TextView>(Resource.Id.gameTextView);
            _genresTextView = FindViewById<TextView>(Resource.Id.genresTextView);
            _platformTextView = FindViewById<TextView>(Resource.Id.platformTextView);
            _summaryTextView = FindViewById<TextView>(Resource.Id.summaryTextView);
            if (Intent.HasExtra ("game"))
            {
                string gameJson = Intent.GetStringExtra("game");
                _game = JsonConvert.DeserializeObject<Games>(gameJson);
            } else
            {
                _game = new Games();
            }
            UpdateUI();
        }

        protected void UpdateUI()
        {
            _gameTextView.Text = _game.name;
            _genresTextView.Text = _game.genres_name;
            _platformTextView.Text = _game.platform;
            _summaryTextView.Text = _game.summary;
        }
    }
}
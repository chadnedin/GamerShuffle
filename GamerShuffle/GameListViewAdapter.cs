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

namespace GamerShuffle
{
    public class GameListViewAdapter : BaseAdapter<Games>
    {
        private readonly Activity context;
        private List<Games> gameListData;
        public GameListViewAdapter(Activity _context, List<Games> _gameListData)
        : base()
        {
            this.context = _context;
            this.gameListData = _gameListData;
        }
        public override int Count
        {
            get
            {
                return gameListData.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.GameListItem, null, false);
            }
            Games game = this[position];
            view.FindViewById<TextView>(Resource.Id.nameTextView).Text = game.name;
            if (String.IsNullOrEmpty(game.genres_name))
            {
                view.FindViewById<TextView>(Resource.Id.genresTextView).Visibility = ViewStates.Gone;

            }
            else
            {
                view.FindViewById<TextView>(Resource.Id.genresTextView).Text = game.genres_name;
            }
           
            return view;
        }

        public override Games this[int index]
        {
            get { return gameListData[index]; }
        }

    }
}
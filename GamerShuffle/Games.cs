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
   public class Games
    {

        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public string games { get; set; }
        public string genres { get; set; }

        public string platforms { get; set; }
        public string original_release_date { get; set; }

        public string original_game_rating { get; set; }

        public string description { get; set; }

    }
}
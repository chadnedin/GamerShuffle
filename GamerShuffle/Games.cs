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
        public string Image { get; set; }

        public int genres_id { get; set; }
        public string games { get; set; }
        public string genres_name { get; set; }

        public string platform_name { get; set; }

        public string platform { get; set; }
        public string release_dates { get; set; }

        public double? popularity { get; set; }

        public string summary { get; set; }

    }
}
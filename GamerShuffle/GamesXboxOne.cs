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
  public  class GamesXboxOne
    {
      
            public int id { get; set; }
            public string name { get; set; }
            public string summary { get; set; }
            public string genres { get; set; }
            public string platform { get; set; }
        }

        public class RootObject3
        {
            public List<GamesXboxOne> gamesXboxOne { get; set; }
        }
    }

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Json;
using System;
using System.Collections.Generic;
using Android.Views;

namespace GamerShuffle
{
    [Activity(Label = "GamerShuffle", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            var txtView = FindViewById<TextView>(Resource.Id.textView1);
            var btnText = FindViewById<Button>(Resource.Id.btnEnter);
         
            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            txtView.SetTypeface(tf, TypefaceStyle.Normal);
            btnText.SetTypeface(tf, TypefaceStyle.Bold);

            btnText.Click += delegate

            {
                StartActivity(typeof(searchActivity));
               
            };
            
        }

      
    }
}


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
using Android.Graphics;

namespace GamerShuffle
{
    [Activity(Label = "retroActivity")]
    public class retroActivity : Activity
    {
        //Thank you Abinodh for assistance with building personal api links, 
        //to help streamline my webrequest and app's design intent. 

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.retroSearch);
            // Create your application here

            var txtView = FindViewById<TextView>(Resource.Id.textView1);
            //var btnatari = FindViewById<Button>(Resource.Id.btnAtari);
            ////59
            //var btnsnes = FindViewById<Button>(Resource.Id.btnSNES);
            //19
            var btncommodorevic2 = FindViewById<Button>(Resource.Id.btnCommodoreVIC2);
            //71
           

            Typeface tf = Typeface.CreateFromAsset(Assets, "VT323-Regular.ttf");
            txtView.SetTypeface(tf, TypefaceStyle.Normal);
            //btnatari.SetTypeface(tf, TypefaceStyle.Bold);
            //btnsnes.SetTypeface(tf, TypefaceStyle.Bold);
            btncommodorevic2.SetTypeface(tf, TypefaceStyle.Bold);
            Console.Out.WriteLine("Made it passed the declare");



            //btnatari.Click += atari_Click;
            //btnsnes.Click += snes_Click;
            btncommodorevic2.Click += commodoreVIC2_Click;

        }
        //private void atari_Click(object sender, EventArgs e)
        //{
        //    Toast.MakeText(this, "Getting your Atari Game list", ToastLength.Short).Show();
        //    StartActivity(typeof(GameListActivity));
        //}
        //private void snes_Click(object sender, EventArgs e)
        //{
        //    Toast.MakeText(this, "Getting your SNES Game list", ToastLength.Short).Show();
        //    StartActivity(typeof(xbox1Activity));
        //}

        private void commodoreVIC2_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Getting your Commodore-VIC2 Game list", ToastLength.Short).Show();
            StartActivity(typeof(commodoreVIC2Activity));
        }
    }
}
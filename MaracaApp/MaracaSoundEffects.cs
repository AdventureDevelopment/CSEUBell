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
using Android.Media;

namespace MaracaApp
{
    public class MaracaSoundEffects
    {
        private readonly Context _context;

        public MaracaSoundEffects(Context context)
        {
            _context = context;
        }

        public int SelectedSoundEffect { get; set; }

        public void PlaySoundEffect()
        {
            var mediaPlayer = MediaPlayer.Create(_context, SelectedSoundEffect);
            mediaPlayer.Completion += (object sender, EventArgs e) =>
            {
                mediaPlayer.Release();
                mediaPlayer.Dispose();
            };

            mediaPlayer.Start();
        }
    }
}
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
using Android.Hardware;
using System.Diagnostics;

namespace MaracaApp
{
    public class MaracaMotionManager
    {
        private readonly double _degreeOfChange = (Math.PI / 3);
        private static readonly object _syncLock = new object();
        private readonly long _soundInterval;
        private readonly Stopwatch _lastActive;

        public MaracaMotionManager()
        {
            _lastActive = new Stopwatch();
            _soundInterval = 250;
        }

        public MaracaSoundEffects SoundEffects { get; set; }

        public void DetectMotion(SensorEvent e)
        {
            lock (_syncLock)
            {
                if (!_lastActive.IsRunning)
                {
                    _lastActive.Start();
                }

                if (_lastActive.ElapsedMilliseconds >= _soundInterval)
                {
                    var checkValue = e.Values[0] > e.Values[2] ? e.Values[0] : e.Values[2];

                    IntensityResolve(checkValue);

                    _lastActive.Restart();
                }
            }
        }

        public void IntensityResolve(float radChange)
        {
            if (Math.Abs(radChange) > _degreeOfChange)
            {
                SoundEffects.PlaySoundEffect();
            }
        }
    }
}
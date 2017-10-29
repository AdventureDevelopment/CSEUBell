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

namespace MaracaApp
{
    public class GyroScopeChange : ISensorEventListener
    {
        public IntPtr Handle => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            throw new NotImplementedException();
        }
    }
}
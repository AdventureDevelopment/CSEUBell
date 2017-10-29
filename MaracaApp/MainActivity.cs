using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Runtime;
using Android.Content.PM;
using System;

namespace MaracaApp
{
    [Activity(Label = "CSEU Bell", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity, ISensorEventListener
    {
        private SensorManager _sensorManager;
        private MaracaMotionManager _maracaMotionManager;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
            _maracaMotionManager.DetectMotion(e);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _maracaMotionManager = new MaracaMotionManager
            {
                SoundEffects = new MaracaSoundEffects(this)
                {
                    SelectedSoundEffect = Resource.Raw.tap
                }
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            _sensorManager.RegisterListener(this,
                _sensorManager.GetDefaultSensor(SensorType.Gyroscope),
                SensorDelay.Fastest
                );
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(this);
        }
    }
}



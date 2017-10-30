using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Runtime;
using Android.Content.PM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaracaApp
{
    [Activity(Label = "CSEU Bell", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity, ISensorEventListener
    {
        private SensorManager _sensorManager;
        private MaracaMotionManager _maracaMotionManager;
        private MaracaSoundEffects _maracaSound;
        private List<BellSound> _bellSounds;

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

            _bellSounds = CreateBellSounds();

            _maracaSound = new MaracaSoundEffects(this)
            {
                SelectedSoundEffect = _bellSounds.First().ResourceId
            };

            _maracaMotionManager = new MaracaMotionManager
            {
                SoundEffects = _maracaSound
            };

            
            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            ArrayAdapter<BellSound> adapter = new ArrayAdapter<BellSound>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, _bellSounds);
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
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

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            var spinner = (Spinner)sender;

            _maracaSound.SelectedSoundEffect = _bellSounds[e.Position].ResourceId;
        }

        private List<BellSound> CreateBellSounds()
        {
            return new List<BellSound>
            {
                new BellSound
                {
                    DisplayName = "Tap",
                    ResourceId = Resource.Raw.tap
                },
                new BellSound
                {
                    DisplayName = "Base Kick",
                    ResourceId = Resource.Raw.baseKick
                },
                new BellSound
                {
                    DisplayName = "Cartoon Laugh",
                    ResourceId = Resource.Raw.CartoonLaugh
                },
                new BellSound
                {
                    DisplayName = "Cat",
                    ResourceId = Resource.Raw.cat
                },
                new BellSound
                {
                    DisplayName = "Cheer",
                    ResourceId = Resource.Raw.Cheer
                },
                new BellSound
                {
                    DisplayName = "Clown Horn",
                    ResourceId = Resource.Raw.clownHorn
                },
                new BellSound
                {
                    DisplayName = "Dog",
                    ResourceId = Resource.Raw.Dog
                },
                new BellSound
                {
                    DisplayName = "Incorrect",
                    ResourceId = Resource.Raw.incorrect
                }
            };
        }
    }
}



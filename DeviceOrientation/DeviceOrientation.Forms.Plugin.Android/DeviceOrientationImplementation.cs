using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Runtime;
using Android.App;

using DeviceOrientation.Forms.Plugin.Droid;
using Android.Hardware;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]
namespace DeviceOrientation.Forms.Plugin.Droid
{
    /// <summary>
    /// DeviceOrientation Implementation
    /// </summary>
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        private static OrientationEventListener _orientationListener;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() 
        { 
            _orientationListener = new OrientationListener(Application.Context, SensorDelay.Normal);
        }

        #region IDeviceOrientation implementation

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <returns>The orientation.</returns>
        public DeviceOrientations GetOrientation()
        {
            IWindowManager windowManager = Application.Context .GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;

        }

        #endregion
    }
}

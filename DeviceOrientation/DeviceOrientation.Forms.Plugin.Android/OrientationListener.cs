using System;
using Android.Views;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.Abstractions;
using Android.Hardware;
using Android.Content;

namespace DeviceOrientation.Forms.Plugin.Droid
{
    /// <summary>
    /// Orientation listener.
    /// </summary>
    public class OrientationListener:OrientationEventListener
    {
        #region implemented abstract members of OrientationEventListener

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceOrientation.Forms.Plugin.Droid.OrientationListener"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="rate">Rate.</param>
        public OrientationListener(Context context, SensorDelay rate) : base(context,rate)
        {

        }

        /// <Docs>The new orientation of the device.</Docs>
        /// <summary>
        /// Raises the orientation changed event.
        /// </summary>
        /// <param name="orientation">Orientation.</param>
        public override void OnOrientationChanged(int orientation)
        {
            bool isLandscape = (orientation > 60 && orientation < 120) || (orientation > 240 && orientation < 300);                      
            var msg = new DeviceOrientationChangeMessage()
            {
                Orientation = isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait
            };
            MessagingCenter.Send<DeviceOrientationChangeMessage>(msg, DeviceOrientationChangeMessage.MessageId);
           
        }

        #endregion


    }
}


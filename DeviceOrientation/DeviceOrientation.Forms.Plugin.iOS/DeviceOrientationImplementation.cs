using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.iOS;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]
namespace DeviceOrientation.Forms.Plugin.iOS
{
    /// <summary>
    /// DeviceOrientation Implementation
    /// </summary>
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() 
        { 
            var notificationCenter = NSNotificationCenter.DefaultCenter;
            notificationCenter.AddObserver(UIApplication.DidChangeStatusBarOrientationNotification, DeviceOrientationDidChange);

            UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications ();

        }

        /// <summary>
        /// Devices the orientation did change.
        /// </summary>
        /// <param name="notification">Notification.</param>
        public static void DeviceOrientationDidChange (NSNotification notification)
        {
            var orientation = UIDevice.CurrentDevice.Orientation;
            bool isPortrait = orientation == UIDeviceOrientation.Portrait 
                || orientation == UIDeviceOrientation.PortraitUpsideDown;
            SendOrientationMessage(isPortrait);
        }

        static void SendOrientationMessage(bool isPortrait)
        {
            var msg = new DeviceOrientationChangeMessage()
                {
                    Orientation = isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape
                };
            MessagingCenter.Send<DeviceOrientationChangeMessage>(msg, DeviceOrientationChangeMessage.MessageId);
        }

        #region IDeviceOrientation implementation

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <returns>The orientation.</returns>
        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait 
                || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientations.Portrait: DeviceOrientations.Landscape;
        }

        #endregion
    }
}

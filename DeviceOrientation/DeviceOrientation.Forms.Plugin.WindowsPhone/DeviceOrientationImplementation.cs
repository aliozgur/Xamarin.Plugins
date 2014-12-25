using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.WindowsPhone;
using Windows.Devices.Sensors;
using System.Windows;
using Microsoft.Phone.Controls;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]
namespace DeviceOrientation.Forms.Plugin.WindowsPhone
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
        }

        /// <summary>
        /// Send orientation change message through MessagingCenter
        /// </summary>
        /// <param name="e">Orientation changed event args</param>
        public static void NotifyOrientationChange(OrientationChangedEventArgs e)
        {
            bool isLandscape = (e.Orientation & PageOrientation.Landscape) == PageOrientation.Landscape;
            var msg = new DeviceOrientationChangeMessage()
            {
                Orientation = isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait
            };
            MessagingCenter.Send<DeviceOrientationChangeMessage>(msg, DeviceOrientationChangeMessage.MessageId);
        }

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <returns>The orientation.</returns>
        public DeviceOrientations GetOrientation()
        {
            var rootFrame = (System.Windows.Application.Current.RootVisual as PhoneApplicationFrame);
            if (rootFrame == null)
                return DeviceOrientations.Undefined;

            PageOrientation currentOrientation = (System.Windows.Application.Current.RootVisual as PhoneApplicationFrame).Orientation;
            bool isLandscape = (currentOrientation & PageOrientation.Landscape) == PageOrientation.Landscape;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
           
           
        }
    }
}

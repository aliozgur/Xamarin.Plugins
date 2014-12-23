using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.iOS;

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
        public static void Init() { }
    }
}

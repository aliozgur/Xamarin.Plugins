using System;

namespace DeviceOrientation.Forms.Plugin.Abstractions
{
    /// <summary>
    /// DeviceOrientation Interface
    /// </summary>
    public interface IDeviceOrientation
    {
        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <returns>The orientation.</returns>
        DeviceOrientations GetOrientation();
    }
}

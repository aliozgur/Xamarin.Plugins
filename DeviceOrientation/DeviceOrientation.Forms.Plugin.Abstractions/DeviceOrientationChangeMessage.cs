using System;

namespace DeviceOrientation.Forms.Plugin.Abstractions
{
    /// <summary>
    /// Device orientation change message.
    /// </summary>
    public class DeviceOrientationChangeMessage
    {
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public DeviceOrientations Orientation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        public static string MessageId
        {
            get
            { 
                return "DeviceOrientation.Forms.Plugin.OrientationChangeMessage";
            }
        }
    }
}


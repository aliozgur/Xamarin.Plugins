using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DeviceOrientationDemo.WinPhone.Resources;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.WindowsPhone;

namespace DeviceOrientationDemo.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Forms.Init();
            DeviceOrientationImplementation.Init();
            Content = DeviceOrientationDemo.App.GetMainPage().ConvertPageToUIElement(this);
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            base.OnOrientationChanged(e);
            DeviceOrientationImplementation.NotifyOrientationChange(e);
        }
    }
}
using System;
using Xamarin.Forms;

namespace DeviceOrientationDemo
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new MainPage());
        }
    }
}


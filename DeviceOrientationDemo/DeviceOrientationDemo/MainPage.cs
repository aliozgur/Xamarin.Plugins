using System;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.Abstractions;

namespace DeviceOrientationDemo
{
    public class MainPage:ContentPage
    {
        IDeviceOrientation _deviceOrientationSvc;
        private Label _label;

        public MainPage()
        {
            _deviceOrientationSvc = DependencyService.Get<IDeviceOrientation>();
            PrepareControls();
        }

        private void PrepareControls()
        {
           
            _label = new Label
            {
                
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            _label.Text = String.Format("Hello, Forms! My initial orientation is {0}",_deviceOrientationSvc.GetOrientation());

            Content = _label;
           
         

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
                {
                    HandleOrientationChange(message);
                });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);
            base.OnDisappearing();
        }

        private void HandleOrientationChange(DeviceOrientationChangeMessage mesage)
        {
            _label.Text = String.Format("Orientation changed to {0}", mesage.Orientation.ToString());
        }
    }
}


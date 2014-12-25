using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeviceOrientationDemo
{
    public class ChildPage : ContentPage
    {
         IDeviceOrientation _deviceOrientationSvc;
        private Label _label;

        public ChildPage()
        {
            Title = "Child";
            _deviceOrientationSvc = DependencyService.Get<IDeviceOrientation>();
            PrepareControls();
        }

        private void PrepareControls()
        {

            var stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5)
            };

            _label = new Label
            {
                
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            stackLayout.Children.Add(_label);    
            Content = stackLayout;           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _label.Text = String.Format("I'm a child page! My initial orientation is {0}", _deviceOrientationSvc.GetOrientation());
            
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
            _label.Text = String.Format("I'm a child page! Orientation changed to {0}", mesage.Orientation.ToString());
        }
    }
}

## Demo of Device Orientation Plugin for Xamarin.Forms

Simple way to get device orientation or be notified of orientation changes in your Xamarin.Forms projects

#### Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.DeviceOrientation/
* Install into your PCL project and Client projects.

In your iOS, Android, and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
DeviceOrientationImplementation.Init();
```

You must do this AFTER you call Xamarin.Forms.Init();

#### Usage

You can get instance of IDeviceOrientation using DependencyService

``` 
var svc = DependencyService.Get<IDeviceOrientationService>();
var orientation = svc.GetOrientation();
```

Or, you can subscribe to orientation change message (OnApperaring override of a Page would be a good place to subscribe)
``` 
MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
                {
                    //TODO: HandleOrientationChange(message);
                });
```

Do not forget to unsubscribe from OrientationChangeMessage messages (OnDisappearing override of a Page would be a good place to unsubscribe)

``` 
MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);
```

#### Contributors
* [aliozgur](https://github.com/aliozgur)

Thanks!

#### License
Licensed under main repo license

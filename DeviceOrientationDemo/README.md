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

#### Known Issues

* I was not able to build and package the Android library with Visual Studio because my Xamarin.Android evaluation expired.May be James Montemango could help me with this
* Due to the first problem even the code runs on a production Android app the plugin version was not included in the Android project of the demo solution

#### Contributors
* [aliozgur](https://github.com/aliozgur)

Thanks!

#### License
Licensed under main repo license

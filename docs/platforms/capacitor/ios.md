# iOS

Before you continue, please make sure you have installed and initialized [Capacitor](../0intro) in Bionic and that [Apple's XCode](../0intro/#ios) is installed.

## Initialize Capacitor iOS

This step is only required once and it will generate the necessary assets under ```platform/capacitor/ios``` directory.

```text
> bionic platform capacitor ios init
...
🚀  Capacitor iOS is ready to go! - try: bionic platform capacitor ios open
```

## Build and deploy Capacitor iOS

This step prepares Blazor assets for Capacitor iOS deployment.

```text
> bionic platform capacitor ios build
☕  Building iOS Capacitor...
✔ Copying web assets from www to ios/App/public in 44.06ms
✔ Copying native bridge in 6.15ms
✔ Copying capacitor.config.json in 1.50ms
✔ copy in 62.72ms
🚀  Capacitor successfully built. Try: bionic platform capacitor ios open
```

This step opens XCode with the project ready to go:

```text
> bionic platform capacitor ios open
☕  Opening iOS Capacitor project...
✔ Opening the Xcode workspace... in 3.01s
```

Select iOS target and run the App in Emulator or Device:

![XCode Run App](/images/xcode-run.png)


And if everything went well, the app should be loaded in the provided device or emulator.

![XCode Emulator](/images/xcode-emulator.png)

Please remember that Capacitor is still in Beta and you may encounter some minor issues.
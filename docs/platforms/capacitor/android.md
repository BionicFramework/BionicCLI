# Android

Before you continue, please make sure you have installed and initialized [Capacitor](../0intro) in Bionic and that [Android Studio](../0intro/#android-studio) is installed.

## Initialize Capacitor Android

This step is only required once and it will generate the necessary assets under ```platform/capacitor/android``` directory.

```text
> bionic platform capacitor android init
...
🚀  Capacitor Android is ready to go! - try: bionic platform capacitor android open
```

## Build and deploy Capacitor Android

This step prepares Blazor assets for Capacitor Android deployment.

```text
> bionic platform capacitor android build
☕  Building Android Capacitor...
✔ Copying web assets from www to android/app/src/main/assets/public in 42.83ms
✔ Copying native bridge in 6.31ms
✔ Copying capacitor.config.json in 1.55ms
✔ copy in 58.91ms
🚀  Capacitor successfully built. Try: bionic platform capacitor android open
```

This step opens Android Studio with the project ready to go:

```text
> bionic platform capacitor android open
☕  Opening Android Capacitor project...
[info] Opening Android project at ./platforms/capacitor/android
```

Run the App in Emulator:

![Android Studio Run App](/images/android-studio-run.png)

Select Virtual Device. Make sure it has a recent Android API since WebAssembly is only available in recent APIs:

![Android Studio Virtual Device](/images/android-studio-vdevice.png)

And if everything went well, the app should be loaded in the provided device or emulator.

![Android Studio Emulator](/images/android-studio-emulator.png)

Please remember that Capacitor is still in Beta and you may encounter some minor issues.
# Device

!!! success "iOS, Android, Electron, PWA"

The Device API exposes internal information about the device, such as the model and operating system version, along with user information such as unique ids.

## Methods

[DeviceBridge.GetInfo()](#getinfo)

## Example

```c#
    DeviceInfo DeviceData;
    private async Task Device() {
        try {
            DeviceData = await DeviceBridge.GetInfo();
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### GetInfo

Return information about the underlying device/os/platform

> static Task&lt;[DeviceInfo](#deviceinfo)&gt; GetInfo()

## Models

#### DeviceInfo

```c#
    public class DeviceInfo {
        public string model; // The device model. For example, "iPhone"
        public string platform; // The device platform (lowercase). For example, "ios", "android", or "web"
        public string uuid; // The UUID of the device as available to the app. This identifier may change on modern mobile platforms that only allow per-app install UUIDs.
        public string appVersion; // The current bundle version of the app
        public string osVersion; // The version of the device OS
        public string manufacturer; // The manufacturer of the device
        public bool isVirtual; // Whether the app is running in a simulator/emulator
        public long memUsed; // Approximate memory used by the current app, in bytes. Divide by 1048576 to get the number of MBs used.
        public long diskFree; // Approximate memory used by the current app, in bytes. Divide by 1048576 to get the number of MBs used.
        public long diskTotal; // Approximate memory used by the current app, in bytes. Divide by 1048576 to get the number of MBs used.
        public long batteryLevel; // A percentage (0 to 1) indicating how much the battery is charged
        public bool isCharging; // Whether the device is charging
    }
```
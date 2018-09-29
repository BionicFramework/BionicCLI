# Geolocation

!!! success "iOS, Android, Electron, PWA"

The Geolocation API provides simple methods for getting and tracking the current position of the device using GPS, along with altitude, heading, and speed information if available.

## Methods

[GeolocationBridge.GetCurrentPosition()](#getcurrentposition)

[GeolocationBridge.WatchPosition()](#watchposition)

[GeolocationBridge.ClearWatch()](#clearwatch)

## Example

```c#
    GeolocationPosition CurrentPosition;
    private async Task GeolocationCurrentPosition() {
        try {
            CurrentPosition = await GeolocationBridge.GetCurrentPosition();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private string WatcherID;
    private async Task GeolocationWatch() {
        if (WatcherID == null) {
            try {
                var opts = new GeolocationOptions {
                    enableHighAccuracy = false,
                    requireAltitude = false
                };

                WatcherID = await GeolocationBridge.WatchPosition(opts, async (newPosition) => {
                    CurrentPosition = newPosition;
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await GeolocationBridge.ClearWatch(WatcherID);
                WatcherID = null;
                CurrentPosition = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }
```

## API

### GetCurrentPosition

Get the current GPS location of the device

> static Task&lt;[GeolocationPosition](#geolocationposition)&gt; GetCurrentPosition([GeolocationOptions](#geolocationoptions) options = null)

### WatchPosition

Set up a watch for location changes. Note that watching for location changes can consume a large amount of energy. Be smart about listening only when you need to.

> static async Task&lt;string&gt; WatchPosition([GeolocationOptions](#geolocationoptions) options, Action&lt;[GeolocationPosition](#geolocationposition)&gt; callback)

### ClearWatch

Clear a given watch

> static Task ClearWatch(string watcherId)

## Models

#### GeolocationOptions

```c#
    public class GeolocationOptions {
        public bool enableHighAccuracy;
        public long maximumAge;
        public bool requireAltitude;
        public long timeout;
    }
```

#### GeolocationPosition

```c#
    public class GeolocationPosition {
        public GeolocationCoord coords;
    }
```

#### GeolocationCoord

```c#
    public class GeolocationCoord {
        public long latitude;
        public long longitude;
        public long accuracy;
        public long altitude;
        public long speed;
        public long heading;
    }
```

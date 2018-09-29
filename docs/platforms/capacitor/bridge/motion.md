# Motion

!!! success "iOS, Android, Electron, PWA"

The Motion API tracks accelerometer and device orientation (compass heading, etc.)

## Methods

[MotionBridge.AddAccelListener()](#addaccellistener)

[MotionBridge.AddOrientationListener()](#addorientationlistener)

[MotionBridge.RemoveListener()](#removelistener)

## Example

```c#
    private MotionEventResult CurrentAccel;
    private string MotionAccelWatcherID;
    private async Task MotionAccel() {
        if (MotionAccelWatcherID == null) {
            MotionAccelWatcherID = "my-motion-accel-listener";
            try {
                await MotionBridge.AddAccelListener(MotionAccelWatcherID, async (result) => {
                    CurrentAccel = result;

                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await MotionBridge.RemoveListener(MotionAccelWatcherID);
                MotionAccelWatcherID = null;
                CurrentAccel = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }

    private MotionOrientationEventResult CurrentOrientation;
    private string MotionOrientationWatcherID;
    private async Task MotionOrientation() {
        if (MotionOrientationWatcherID == null) {
            MotionOrientationWatcherID = "my-motion-orientation-listener";
            try {
                await MotionBridge.AddOrientationListener(MotionOrientationWatcherID, async (result) => {
                    CurrentOrientation = result;
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await MotionBridge.RemoveListener(MotionAccelWatcherID);
                MotionOrientationWatcherID = null;
                CurrentOrientation = null;
            }
            catch (Exception e) {
                // Hasndle error
            }
        }
    }

```

## API

### AddAccelListener

Listen for accelerometer data

> static async Task AddAccelListener(string id, Action&lt;MotionEventResult&gt; callback)

### AddOrientationListener

Listen for device orientation change (compass heading, etc.)

> static async Task AddOrientationListener(string id, Action&lt;MotionOrientationEventResult&gt; callback)

### RemoveListener

Remove listener with given id

> static Task RemoveListener(string id)

## Models

#### MotionEventResult

```c#
    public class MotionEventResult {
        public MotionCoords acceleration;
        public MotionCoords accelerationIncludingGravity;
        public MotionOrientationEventResult rotationRate;
        public long interval;
    }
```

#### MotionCoords

```c#
    public class MotionCoords {
        public long x, y, z;
    }
```

#### MotionOrientationEventResult

```c#
    public class MotionOrientationEventResult {
        public long alpha, beta, gamma;
    }
```
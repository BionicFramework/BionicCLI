# Haptics

!!! success "iOS, Android"

The Haptics API provides physical feedback to the user through touch or vibration.

## Methods

[HapticsBridge.Vibrate()](#vibrate)

[HapticsBridge.Impact()](#impact)

[HapticsBridge.SelectionStart()](#selectionstart)

[HapticsBridge.SelectionChanged()](#selectionchanged)

[HapticsBridge.SelectionEnd()](#selectionend)

## Example

```c#
    private static async void HapticsVibrate() {
        try {
            await HapticsBridge.Vibrate();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void HapticsImpact(HapticsImpactStyle style) {
        try {
            await HapticsBridge.Impact(style);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void HapticsSelectionStart() {
        try {
            await HapticsBridge.SelectionStart();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void HapticsSelectionChanged() {
        try {
            await HapticsBridge.SelectionChanged();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void HapticsSelectionEnd() {
        try {
            await HapticsBridge.SelectionEnd();
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### Vibrate

Vibrate the device

> static Task Vibrate()

### Impact

Trigger a haptics "impact" feedback

> static Task Impact([HapticsImpactStyle](#hapticsimpactstyle) style)

### SelectionStart

Trigger a selection started haptic hint

> static Task SelectionStart()

### SelectionChanged

Trigger a selection changed haptic hint. If a selection was started already, this will cause the device to provide haptic feedback (on iOS at least)

> static Task SelectionChanged()

### SelectionEnd

If selectionStart() was called, selectionEnd() ends the selection. For example, call this when a user has lifted their finger from a control

> static Task SelectionEnd()

## Models

#### HapticsImpactStyle

```c#
    public enum HapticsImpactStyle {
        Heavy,
        Medium,
        Light
    }
```
# Keyboard



!!! success "iOS, Android"

The Background Task API makes it easy to run background tasks. Currently, this plugin supports running a task when the app is backgrounded, and soon will support periodic background fetch operations.

## Methods

[KeyboardBridge.RegisterEventListeners()](#registereventlisteners)

[KeyboardBridge.Show()](#show)

[KeyboardBridge.Hide()](#hide)

[KeyboardBridge.SetAccessoryBarVisible()](#setaccessorybarvisible)

[KeyboardBridge.AddEventListener()](#addeventlistener)

[KeyboardBridge.RemoveEventListener()](#removeeventlistener)

## Example

```c#
    private static async Task KeyboardShow() {
        try {
            await KeyboardBridge.Show();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task KeyboardSetAccessoryBarVisible() {
        try {
            await KeyboardBridge.SetAccessoryBarVisible(true);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task KeyboardSetAccessoryBarHidden() {
        try {
            await KeyboardBridge.SetAccessoryBarVisible(false);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task KeyboardHide() {
        try {
            await KeyboardBridge.Hide();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task KeyboardEvents() {
        try {
            await KeyboardBridge.RegisterEventListeners();

            KeyboardBridge.AddEventListener(KeyboardEvent.KeyboardWillShow, (e) =>
                Console.WriteLine($"Received KeyboardWillShow event: {e}"));
            KeyboardBridge.AddEventListener(KeyboardEvent.KeyboardDidShow, (e) =>
                Console.WriteLine($"Received KeyboardDidShow event: {e}"));
            KeyboardBridge.AddEventListener(KeyboardEvent.KeyboardWillHide, (e) =>
                Console.WriteLine($"Received KeyboardWillHide event: {e}"));
            KeyboardBridge.AddEventListener(KeyboardEvent.KeyboardDidHide, (e) =>
                Console.WriteLine($"Received KeyboardDidHide event: {e}"));
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### RegisterEventListeners

Initializes event listeners to allow for updates. Use [AddEventListener](#addeventlistener) to add listener function for specific event.

> static Task&lt;object&gt; RegisterEventListeners()

### Show

Show the keyboard. This method is alpha and may have issues

> static Task&lt;object&gt; Show()

### Hide

Hide the keyboard.

> static Task&lt;object&gt; Hide()

### SetAccessoryBarVisible

Set whether the accessory bar should be visible on the keyboard. We recommend disabling the accessory bar for short forms (login, signup, etc.) to provide a cleaner UI

> static Task&lt;object&gt; SetAccessoryBarVisible(bool isVisible)

### AddEventListener

Subscribe to keyboard events.

> static void AddEventListener([KeyboardEvent](#keyboardevent) eventType, Action&lt;string&gt; callback)

### RemoveEventListener

Unsubscribe to keyboard events.

> static void RemoveEventListener([KeyboardEvent](#keyboardevent) eventType, Action&lt;string&gt; callback) {

## Models

#### KeyboardEvent

```c#
    public enum KeyboardEvent {
        KeyboardWillShow,
        KeyboardDidShow,
        KeyboardWillHide,
        KeyboardDidHide
    }
```
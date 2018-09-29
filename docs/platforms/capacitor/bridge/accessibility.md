# Accessibility
!!! success "iOS, Android"

The Accessibility API makes it easy to know when a user has a screen reader enabled, as well as programmatically speaking labels through the connected screen reader.

## Methods

[AccessibilityBridge.IsScreenReaderEnabled()](#isscreenreaderenabled)

[AccessibilityBridge.Speak()](#speak)

[AccessibilityBridge.AddListener()](#addlistener)

[AccessibilityBridge.RemoveListener()](#removelistener)

## Example

```c#
    private static async void AccessibilityIsScreenReaderEnabled() {
        try {
            var result = await AccessibilityBridge.IsScreenReaderEnabled();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void AccessibilitySpeak() {
        try {
            var options = new AccessibilitySpeakOptions {
                value = "Hello! How are you?",
                language = "en"
            };
            await AccessibilityBridge.Speak(options);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private string AccessibilityWatcherID;
    private async Task AccessibilityListener() {
        if (AccessibilityWatcherID == null) {
            AccessibilityWatcherID = "accessibility-listener";
            try {
                await AccessibilityBridge.AddListener(AccessibilityWatcherID, async (result) => {
                    Console.WriteLine($"Received accessibility screen reader state change event {result}");
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await AccessibilityBridge.RemoveListener(AccessibilityWatcherID);
                AccessibilityWatcherID = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }
```

## API

### IsScreenReaderEnabled

Check if screen reader is enabled.

> static Task&lt;bool&gt; IsScreenReaderEnabled()

Returns true if screen reader is enabled. False otherwise.

### Speak

Speaks a provided string.

> static Task Speak([AccessibilitySpeakOptions](#accessibilityspeakoptions) options)

### AddListener

Listen for screen reader state changes.

> static async Task AddListener(string id, Action&lt;bool&gt; callback)

id: A unique string to be used as ID
callback: A lambda function to be called everytime the screen reader state changes

### RemoveListener

Remove listener with provided ID.

> static Task RemoveListener(string id)

## Models

#### AccessibilitySpeakOptions

```c#
    public class AccessibilitySpeakOptions {
        public string value;    // The string to speak
        public string language; // The language to speak as its [ISO 639-1 Code](https://www.loc.gov/standards/iso639-2/php/code_list.php) (ex: "en")
    }
```
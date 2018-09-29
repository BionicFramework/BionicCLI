# Browser

!!! success "iOS, Android, Electron, PWA"

The Browser API makes it easy to open an in-app browser session to show external web content, handle authentication flows, and more.

On iOS this uses SFSafariViewController and is compliant with leading oAuth service in-app-browser requirements.

## Methods

[BrowserBridge.Close()](#close)

[BrowserBridge.Open()](#open)

[BrowserBridge.Prefetch()](#prefetch)

[BrowserBridge.ListenToBrowserFinished()](#listentobrowserfinished)

[BrowserBridge.ListenToBrowserPageLoaded()](#listentobrowserpageloaded)

## Example

```c#
    private static void BrowserOpen(string ps, string url = "https://blazor.net") {
        try {
            var options = new BrowserOpenOptions {
                url = url,
                presentationStyle = ps,
                windowName = "Bionic Browser",
                toolbarColor = "red"
            };
            BrowserBridge.Open(options);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static void BrowserPrefetch() {
        try {
            var options = new BrowserPrefetchOptions {
                urls = new[] {
                    "https://marcelooliveira.github.io/"
                }
            };
            BrowserBridge.Prefetch(options);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static bool IsListeningToBrowserFinished;
    private static async void BrowserFinished() {
        try {
            if (IsListeningToBrowserFinished) {
                // Unregister ...
            }
            else {
                await BrowserBridge.ListenToBrowserFinished("test-browser-finished", (id, info) =>
                    Console.WriteLine($"Received BrowserFinished event for {id}: {info}"));
                IsListeningToBrowserFinished = true;
            }
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static bool IsListeningToBrowserPageLoaded;
    private static async void BrowserPageLoaded() {
        try {
            if (IsListeningToBrowserPageLoaded) {
                // Unregister ...
            }
            else {
                await BrowserBridge.ListenToBrowserPageLoaded("test-browser-pageloaded", (id, info) =>
                    Console.WriteLine($"Received BrowserPageLoaded event for {id}: {info}"));
                IsListeningToBrowserPageLoaded = true;
            }
        }
        catch (Exception e) {
            // Handle error
        }
    }

```

## API

### Close

Close an open browser. Only works on iOS, otherwise is a no-op

> static Task Close()

#### Open

Open a page with the given URL

> static Task Open(BrowserOpenOptions options)

#### Prefetch

Hint to the browser that the given URLs will be accessed to improve initial loading times. Only functional on Android, is a no-op on iOS

> static Task Prefetch(BrowserPrefetchOptions options)

#### ListenToBrowserFinished

Listen to browser finished events

> static async Task ListenToBrowserFinished(string id, Action&lt;string, string&gt; callback)

#### ListenToBrowserPageLoaded

Listen to browser page loaded events

> static async Task ListenToBrowserPageLoaded(string id, Action&lt;string, string&gt; callback)

## Models

#### BrowserOpenOptions

```c#
    public class BrowserOpenOptions {
        public string url; // The URL to open the browser to
        public string windowName; // Web only: Optional target for browser open. Follows the `target` property for window.open. Defaults to _blank
        public string toolbarColor; // A hex color to set the toolbar color to.
        public string presentationStyle; // iOS only: The presentation style of the browser. Defaults to fullscreen.
    }
```

#### BrowserPrefetchOptions

```c#
    public class BrowserPrefetchOptions {
        public string[] urls; // List of url to prefetch
    }
```

# App

!!! success "iOS, Android, Electron, PWA"

The App API handles high level App state and events.

For example, this API emits events when the app enters and leaves the foreground, handles deeplinks, opens other apps, and manages persisted plugin state.

## Methods

[AppBridge.CanOpenUrl()](#canopenurl)

[AppBridge.ExitApp()](#exitapp)

[AppBridge.GetLaunchUrl()](#getlaunchurl)

[AppBridge.OpenUrl()](#openurl)

[AppBridge.AddAppStateChangeListener()](#addappstatechangelistener)

[AppBridge.AddAppUrlOpenListener()](#addappurlopenlistener)

[AppBridge.AddAppRestoredResultListener()](#addapprestoredresultlistener)

[AppBridge.AddAppBackButtonListener()](#addappbackbuttonlistener)

[AppBridge.RemoveListener()](#removelistener)



## Example

```c#
    private string AppStateChangeWatcherID;
    private async Task AppStateChange() {
        if (AppStateChangeWatcherID == null) {
            AppStateChangeWatcherID = "app-state-change-listener";
            try {
                await AppBridge.AddAppStateChangeListener(AppStateChangeWatcherID, async (result) => {
                    Console.WriteLine($"Received new state change event {result.isActive}");
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await AppBridge.RemoveListener(AppStateChangeWatcherID);
                AppStateChangeWatcherID = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }

    private string AppUrlOpenWatcherID;
    private async Task AppUrlOpen() {
        if (AppUrlOpenWatcherID == null) {
            AppUrlOpenWatcherID = "app-url-open-listener";
            try {
                await AppBridge.AddAppUrlOpenListener(AppUrlOpenWatcherID, async (result) => {
                    Console.WriteLine($"Received new url open event {result.url}");
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await AppBridge.RemoveListener(AppUrlOpenWatcherID);
                AppUrlOpenWatcherID = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }

    private string AppRestoredResultWatcherID;
    private async Task AppRestoredResult() {
        if (AppRestoredResultWatcherID == null) {
            AppRestoredResultWatcherID = "app-restored-result-listener";
            try {
                await AppBridge.AddAppRestoredResultListener(AppRestoredResultWatcherID, async (result) => {
                    Console.WriteLine($"Received new restored result event {result.methodName}");
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await AppBridge.RemoveListener(AppRestoredResultWatcherID);
                AppRestoredResultWatcherID = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }

    private string AppBackButtonWatcherID;
    private async Task AppBackButton() {
        if (AppBackButtonWatcherID == null) {
            AppBackButtonWatcherID = "app-back-button-listener";
            try {
                await AppBridge.AddAppBackButtonListener(AppBackButtonWatcherID, async (result) => {
                    Console.WriteLine($"Received new back button event {result.url}");
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await AppBridge.RemoveListener(AppBackButtonWatcherID);
                AppBackButtonWatcherID = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }

    private static async void AppExit() {
        try {
            await AppBridge.ExitApp();
        }
        catch (Exception e) {
                // Handle error
        }
    }

    private static async void AppCanOpenUrl() {
        try {
            var result = await AppBridge.CanOpenUrl("bionic.bridge.capacitor");
            Console.WriteLine($"Can Open Url: {result}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void AppOpenUrl() {
        try {
            var result = await AppBridge.OpenUrl("bionic.bridge.capacitor://");
            Console.WriteLine($"Open Url: {result}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void AppGetLaunchUrl() {
        try {
            var result = await AppBridge.GetLaunchUrl();
            Console.WriteLine($"Get Launch Url: {result}");
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### CanOpenUrl

Check if passed url can be opened.

> static Task&lt;bool&gt; CanOpenUrl(string url)

### ExitApp

Close and exit application.

> static Task ExitApp()

### GetLaunchUrl

Get launch url.

> static Task&lt;string&gt; GetLaunchUrl()

Returns the app launch url.

### OpenUrl

Open the provided app page.

> static Task&lt;bool&gt; OpenUrl(string url)

### AddAppStateChangeListener

Listen for changes in the App's active state (whether the app is in the foreground or background)

> static async Task AddAppStateChangeListener(string id, Action&lt;[AppState](#appstate)&gt; callback)

id: A unique string to be used as ID
callback: A lambda function to be called everytime there are updates

### AddAppUrlOpenListener

Listen for url open events for the app. This handles both custom URL scheme links as well as URLs your app handles (Universal Links on iOS and App Links on Android)

> static async Task AddAppUrlOpenListener(string id, Action&lt;[AppUrlOpen](#appurlopen)&gt; callback)

id: A unique string to be used as ID
callback: A lambda function to be called everytime there are updates

### AddAppRestoredResultListener

If the app was launched with previously persisted plugin call data, such as on Android when an activity returns to an app that was closed, this call will return any data the app was launched with, converted into the form of a result from a plugin call.

> static async Task AddAppRestoredResultListener(string id, Action&lt;[AppRestoredResult](#apprestoredresult)&gt; callback) {

id: A unique string to be used as ID
callback: A lambda function to be called everytime there are updates

### AddAppBackButtonListener

Listen for the hardware back button event (Android only). If you want to close the app, call `App.exitApp()`

> static async Task AddAppBackButtonListener(string id, Action&lt;[AppUrlOpen](#appurlopen)&gt; callback) {

id: A unique string to be used as ID
callback: A lambda function to be called everytime there are updates

### RemoveListener

Remove listener with provided ID.

> static Task RemoveListener(string id) {

## Models

#### AppState

```c#
    public class AppState {
        public bool isActive; // Is app active (in foreground)
    }
```

#### AppUrlOpen

```c#
    public class AppUrlOpen {
        public string url; // The URL the app was opened with
        public object iosSourceApplication; // [The URL the app was opened with
        public bool iosOpenInPlace; // Whether the app should open the passed document in-place or must copy it first.
    }
```

#### AppRestoredResult

```c#
    public class AppRestoredResult {
        public string pluginId; // The pluginId this result corresponds to. For example, `Camera`.
        public string methodName; // The methodName this result corresponds to. For example, `getPhoto`
        public string data; // The result data passed from the plugin. This would be the result you'd expect from normally calling the plugin method. For example, `CameraPhoto`
    }
```
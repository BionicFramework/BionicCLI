# Share

!!! success "iOS, Android, PWA"

The Share API provides methods for sharing content in any sharing-enabled apps the user may have installed.

The Share API works on iOS, Android, and the Web (using the new [Web Share API](https://developers.google.com/web/updates/2016/09/navigator-share)), though web support is currently spotty.

## Methods

[ShareBridge.share()](#share)

## Example

```c#
    private static async void Share() {
        try {
            var options = new ShareOptions {
                title = "Blazor Framework",
                url = "https://blazor.net",
                text = "Did you try Blazor yet?",
                dialogTitle = "Share the Blazor 💙"
            };
            await ShareBridge.Share(options);
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### Share

Show a Share modal for sharing content in your app with other apps

> static Task&lt;object&gt; Share([ShareOptions](#shareoptions) shareOptions)

## Models

#### ShareOptions

```c#
    public class ShareOptions {
        public string title; // Set a title for any message. This will be the subject if sharing to email
        public string text; // Set some text to share
        public string url; // Set a URL to share
        public string dialogTitle; // Set a title for the share modal. Android only
    }
```
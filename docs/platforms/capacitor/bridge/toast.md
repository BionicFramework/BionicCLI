# Toast

!!! success "iOS, Android, Electron, PWA"

The Toast API provides a notification pop up for displaying important information to a user. Just like real toast!

## Methods

[ToastBridge.ShowWithShortDuration()](#showwithshortduration)

[ToastBridge.ShowWithLongDuration()](#showwithlongduration)

## Example

```c#
    // Open a toast that sticks for a shorter period
    ToastBridge.ShowWithShortDuration("A 🍷 to...");

    // Open a toast that sticks for a longer period
    ToastBridge.ShowWithLongDuration("🔥 Blazor 🔥");
```

## API

### ShowWithShortDuration

Display a toastr for a short period of time.

> static Task&lt;string&gt; ShowWithShortDuration(string message)

### ShowWithLongDuration

Display a toastr for a longer period of time.

> static Task&lt;string&gt; ShowWithLongDuration(string message)

# Clipboard

!!! success "iOS, Android, Electron, PWA"

The Clipboard API enables copy and pasting to/from the clipboard. On iOS this API also allows copying images and URLs.

## Methods

[ClipboardBridge.Read()](#read)

[ClipboardBridge.Write()](#write)

## Example

```c#
    private static async void ClipboardWrite() {
        try {
            var data = new ClipboardWrite {
                str = "Clipboard Data String"
            };
            await ClipboardBridge.Write(data);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void ClipboardRead() {
        try {
            var obj = await ClipboardBridge.Read(ClipboardReadType.String);
            Console.WriteLine($"Data from Clipboard: {obj.value}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

```

## API

### Read

Read a value from the clipboard (the "paste" action)

> static Task&lt;[ClipboardReadResult](#clipboardreadresult)&gt; Read([ClipboardReadType](#clipboardreadtype) clipboardReadType)

### Write

Write a value to the clipboard (the "copy" action)

> static Task Write([ClipboardWrite](#clipboardwrite) clipboardWrite)


## Models

#### ClipboardReadType

```c#
    public enum ClipboardReadType {
        String,
        Url,
        Image
    }
```

#### ClipboardReadResult

```c#
    public class ClipboardReadResult {
        public string value; // Clipboard data
    }
```

#### ClipboardWrite

```c#
    public class ClipboardWrite {
        public string str; // String to write to clipboard
        public string image; // Image to write to clipboard
        public string url; // URL to write to clipboard
        public string label;
    }
```
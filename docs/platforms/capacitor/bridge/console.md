# Console

!!! success "iOS, Android, Electron, PWA"

The Console API automatically sends console.log calls to the native log system on each respective platform. This enables, for example, console.log calls to be rendered in the Xcode and Android Studio log windows.

## Methods

[ConsoleBridge.Log()](#log)

## Example

```c#
    ConsoleBridge.Log("A log from 🔥 Blazor 🔥");
```

## API

### Log

Log string to device console.

> static Task Log(string message)

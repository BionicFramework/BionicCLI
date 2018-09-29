# Background Tasks

!!! success "iOS, Android"

The Background Task API makes it easy to run background tasks. Currently, this plugin supports running a task when the app is backgrounded, and soon will support periodic background fetch operations.

## Methods

[BackgroundTaskBridge.BeforeExit()](#beforeexit)

[BackgroundTaskBridge.Finish()](#finish)

## Example

```c#
    private static async void BackgroundTask() {
        string id = null;
        try {
            id = await BackgroundTaskBridge.BeforeExit(async () => {
                Console.WriteLine($"Cleaning house before exiting...");
                await BackgroundTaskBridge.Finish(id);
            });
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### BeforeExit

When the app is backgrounded, this method allows you to run a short-lived background task that will ensure that you can finish any work your app needs to do (such as finishing an upload or network request). This is especially important on iOS as any operations would normally be suspended without initiating a background task.

This method should finish in less than 3 minutes or your app risks being terminated by the OS.

When you are finished, this callback _must_ call `BackgroundTaskBridge.Finish(id)` where `taskId` is the value returned from `BackgroundTask.beforeExit()`.

> static async Task&lt;string&gt; BeforeExit(Action callback)

callback: The task to run when the app is backgrounded but before it is terminated

### Finish

Notify the OS that the given task is finished and the OS can continue backgrounding the app.

> static async Task Finish(string id)

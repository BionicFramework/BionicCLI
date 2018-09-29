# Network

!!! success "iOS, Android, Electron, PWA"

The Network API provides events for monitoring network status changes, along with querying the current state of the network.

## Methods

[NetworkBridge.GetStatus()](#getstatus)

[NetworkBridge.AddListener()](#addlistener)

[NetworkBridge.RemoveListener()](#removelistener)

## Example

```c#
    private NetworkStatus CurrentNetworkStatus;
    private async Task NetworkCurrentStatus() {
        try {
            CurrentNetworkStatus = await NetworkBridge.GetStatus();
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private string NetworkWatcherID;
    private async Task NetworkListener() {
        if (NetworkWatcherID == null) {
            NetworkWatcherID = "my-network-listener";
            try {
                await NetworkBridge.AddListener(NetworkWatcherID, async (status) => {
                    CurrentNetworkStatus = status;
                });
            }
            catch (Exception e) {
                // Handle error
            }
        }
        else {
            try {
                await NetworkBridge.RemoveListener(NetworkWatcherID);
                NetworkWatcherID = null;
                CurrentNetworkStatus = null;
            }
            catch (Exception e) {
                // Handle error
            }
        }
    }
```

## API

### GetStatus

Get network status

> static Task&lt;[NetworkStatus](#networkstatus)&gt; GetStatus()

### AddListener

Add network status listener

> static async Task AddListener(string id, Action&lt;[NetworkStatus](#networkstatus)&gt; callback)

### RemoveListener

Remove network status listener

> static Task RemoveListener(string id)

## Models

#### NetworkStatus

```c#
    public class NetworkStatus {
        public bool connected;
        public string connectionType;
    }
```

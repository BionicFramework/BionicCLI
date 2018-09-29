# Storage

!!! success "iOS, Android, Electron, PWA"

The Storage API provides a key-value store for simple data.

Mobile OS's may periodically clear data set in ```window.localStorage```, so this API should be used instead of ```window.localStorage```. This API will fall back to using ```localStorage``` when running as a Progressive Web App.

Note: this API is not meant for high-performance data storage applications. Take a look at using SQLite, Realm or a separate data engine if your application will store a lot of items, have high read/write load, or require complex querying.

## Working with JSON

Storage works on Strings only. However, storing JSON blobs is easy: just ```JSON.stringify``` the object before calling ```set```, then ```JSON.parse``` the value returned from ```get```. See the example below for more details.

This method can also be used to store non-string values, such as numbers and booleans.

## Methods

[StorageBridge.Clear()](#clear)

[StorageBridge.Get()](#get)

[StorageBridge.Set()](#set)

[StorageBridge.Keys()](#keys)

[StorageBridge.Remove()](#remove)

## Example

```c#
    // Store some data
    var data = new DataClass {
       data = "Some Data For Testing"
    };
    StorageBridge.Set("data", data);
    StorageBridge.Set("string", "a string");
    StorageBridge.Set("object", new { type = "object", model = "anonymous", arr = new [] { "an", "array" } });
    StorageBridge.Set("number", 123);

    // Read data
    var d = await StorageBridge.Get<DataClass>("data");
    Console.WriteLine($"data: {d}.data={d.data}");
    var s = await StorageBridge.Get<string>("string");
    Console.WriteLine($"string: {s}");
    var o = await StorageBridge.Get<object>("object");
    Console.WriteLine($"object: {o}");
    var n = await StorageBridge.Get<long>("number");
    Console.WriteLine($"number: {n}");

    // Remove entry from storage
    StorageBridge.Remove("object");

    // Retrieve available keys    
    var keys = await StorageBridge.Keys();
    keys.ToList().ForEach(Console.WriteLine);

    // Clear all data
    StorageBridge.Clear();
```

## API

### Clear

Clear stored keys and values.

> static Task Clear()

### Get

Get the value with the given key.

> static Task&lt;T&gt; Get&lt;T&gt;(string key)

### Set

Set the value for the given key

> static Task Set&lt;T&gt;(string key, T value)

### Keys

Return the list of known keys

> static Task&lt;string[]&gt; Keys()

### Remove

Remove the value for this key (if any)

> static Task Remove(string key)

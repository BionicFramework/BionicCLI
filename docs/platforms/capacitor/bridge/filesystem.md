# Filesystem

!!! success "iOS, Android, Electron, PWA"

The Filsystem API provides a NodeJS-like API for working with files on the device.

## Methods

[FilesystemBridge.AppendFile()](#appendfile)

[FilesystemBridge.DeleteFile()](#deletefile)

[FilesystemBridge.GetUri()](#geturi)

[FilesystemBridge.Mkdir()](#mkdir)

[FilesystemBridge.ReadFile()](#readfile)

[FilesystemBridge.ReadDir()](#readdir)

[FilesystemBridge.Rmdir()](#rmdir)

[FilesystemBridge.Stat()](#stat)

[FilesystemBridge.WriteFile()](#writefile)

## Example

```c#
    private static async void FilesystemWriteFile() {
        try {
            var options = new FileWriteOptions {
                path =  "text.txt",
                data = "File write test",
                directory = FilesystemDirectory.Documents,
                encoding = FilesystemEncoding.UTF8
            };
            var obj = await FilesystemBridge.WriteFile(options);
            Console.WriteLine(obj);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemReadFile() {
        try {
            var options = new FileReadOptions {
                path =  "text.txt",
                directory = FilesystemDirectory.Documents,
                encoding = FilesystemEncoding.UTF8
            };
            var obj = await FilesystemBridge.ReadFile(options);
            Console.WriteLine($"Data from file: {obj.data}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemAppendFile() {
        try {
            var options = new FileAppendOptions {
                path =  "text.txt",
                data = "File Append test",
                directory = FilesystemDirectory.Documents,
                encoding = FilesystemEncoding.UTF8
            };
            var obj = await FilesystemBridge.AppendFile(options);
            Console.WriteLine(obj);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemDeleteFile() {
        try {
            var options = new FileDeleteOptions {
                path =  "text.txt",
                directory = FilesystemDirectory.Documents,
            };
            var obj = await FilesystemBridge.DeleteFile(options);
            Console.WriteLine(obj);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemMkdir() {
        try {
            var options = new MkdirOptions {
                path =  "foo/baa/doo",
                directory = FilesystemDirectory.Documents,
                createIntermediateDirectories = true
            };
            var obj = await FilesystemBridge.Mkdir(options);
            Console.WriteLine(obj);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemStat() {
        try {
            var options = new StatOptions {
                path =  "foo/baa/doo",
                directory = FilesystemDirectory.Documents
            };
            var obj = await FilesystemBridge.Stat(options);
            Console.WriteLine($"{obj.type} : {obj.ctime} : {obj.mtime} : {obj.size} : {obj.uri}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemRmdir() {
        try {
            var options = new RmdirOptions {
                path =  "foo/baa/doo",
                directory = FilesystemDirectory.Documents
            };
            var obj = await FilesystemBridge.Rmdir(options);
            Console.WriteLine(obj);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemReaddir() {
        try {
            var options = new ReaddirOptions {
                path =  "",
                directory = FilesystemDirectory.Documents
            };
            var obj = await FilesystemBridge.ReadDir(options);
            foreach (var file in obj.files) {
                Console.WriteLine(file);
            }
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async void FilesystemGetUri() {
        try {
            var options = new GetUriOptions {
                path =  "text.txt",
                directory = FilesystemDirectory.Documents
            };
            var obj = await FilesystemBridge.GetUri(options);
            Console.WriteLine(obj.uri);
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### AppendFile

> static Task&lt;[FileAppendResult](#fileappendresult)&gt; AppendFile([FileAppendOptions](#fileappendoptions) options)

### DeleteFile

> static Task&lt;[FileDeleteResult](#filedeleteresult)&gt; DeleteFile([FileDeleteOptions](#filedeleteoptions) options)

### GetUri

> static Task&lt;[GetUriResult](#geturiresult)&gt; GetUri([GetUriOptions](#geturioptions) options) =>

### Mkdir

> static Task&lt;[MkdirResult](#mkdirresult)&gt; Mkdir([MkdirOptions](#mkdiroptions) options) =>

### ReadFile

> static Task&lt;[FileReadResult](#filereadresult)&gt; ReadFile([FileReadOptions](#filereadoptions) options) =>

### ReadDir

> static Task&lt;[ReaddirResult](#readdirresult)&gt; ReadDir([ReaddirOptions](#readdiroptions) options) =>

### Rmdir

> static Task&lt;[RmdirResult](#rmdirresult)&gt; Rmdir([RmdirOptions](#rmdiroptions) options) =>

### Stat

> static Task&lt;[StatResult](#statresult)&gt; Stat([StatOptions](#statoptions) options) =>

### WriteFile

> static Task&lt;[FileWriteResult](#filewriteresult)&gt; WriteFile([FileWriteOptions](#filewriteoptions) options) =>

## Models

#### FileAppendOptions

```c#
    public class FileAppendOptions: FileWriteOptions {}
```

#### FileWriteOptions

```c#
    public class FileWriteOptions: FileReadOptions {
        public string data; // The data to write
    }
```

#### FileReadOptions

```c#
    public class FileReadOptions: FileDeleteOptions {
        public FilesystemEncoding encoding; // The encoding to write the file in (defautls to utf8)
    }
```

#### GetUriOptions

```c#
    public class GetUriOptions: FileDeleteOptions { }
```

#### ReaddirOptions

```c#
    public class ReaddirOptions: FileDeleteOptions { }
```

#### RmdirOptions

```c#
    public class RmdirOptions: FileDeleteOptions { }
```

#### StatOptions

```c#
    public class StatOptions: FileDeleteOptions { }
```

#### FileDeleteOptions

```c#
    public class FileDeleteOptions {
        public string path; // the filename to delete/read/write
        public FilesystemDirectory directory; // The FilesystemDirectory to store the file in
    }
```

#### MkdirOptions

```c#
    public class MkdirOptions : FileDeleteOptions {
        public bool createIntermediateDirectories; // Whether to create any missing parent directories as well
    }
```

#### GetUriResult

```c#
    public class GetUriResult {
        public string uri;
    }
```

#### FileAppendResult

```c#
    public class FileAppendResult { }
```

#### FileDeleteResult

```c#
    public class FileDeleteResult { }
```

#### MkdirResult

```c#
    public class MkdirResult { }
```

#### FileWriteResult

```c#
    public class FileWriteResult { }
```

#### FileReadResult

```c#
    public class FileReadResult {
        public string data; // The data read from the file
    }
```

#### ReaddirResult

```c#
    public class ReaddirResult {
        public string[] files; // Files or directories in directory
    }
```

#### RmdirResult

```c#
    public class RmdirResult { }
```

#### StatResult

```c#
    public class StatResult {
        public string type; // type (directory / file)
        public long size; // size of file
        public long ctime; // creation time
        public long mtime; // modified time
        public string uri; // path
    }
```

#### FilesystemDirectory

```c#
    public enum FilesystemDirectory {
        Application,
        Documents,
        Data,
        Cache,
        External,
        ExternalStorage
    }
```

#### FilesystemEncoding

```c#
    public enum FilesystemEncoding {
        UTF8,
        ASCII,
        UTF16,
    }
```
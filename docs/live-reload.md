# Bionic Monitor

Bionic Monitor provides live reloading capability to both Standalone and Hosted Blazor projects.


## Install Bionic Monitor

```text
> dotnet tool install -g BionicMonitor
```


## How it works

By default, Bionic Monitor looks for changes in ```wwwroot``` and ```bin/Debug/netstandard2.0/dist``` and automatically
reload the page when a change is detected. For this to happen, Bionic Monitor has to inject
[SignalR](https://github.com/SignalR/SignalR) and respective handling functions. If your project already includes 
SignalR JS Client library then you can set Bionic Monitor to skip its injection (see _--signalRProvided_).

If you run Bionic Monitor without any further arguments in the client or standalone project:

```text
> biomon
```

Notice that ```wwwroot/index.html``` will be injected with the two JS source entries mentioned earlier.
This is alright for a first test but suboptimal for development since source code should not be modified.
Because of this, Bionic Monitor can be instructed to work from a replica of wwwroot.
This can be done by specifying one of the following options:

_--bionic_ : Uses ```.bionic/wwwroot``` as destination root directory

_--destinationRootDir_ : Set a user specified destination root directory

Check ```biomon --help``` for more details and options. 


## Standalone project setup

Add the following to you .csproj file (client side):

```xml
    <ItemGroup>
        <WwwRootFiles Include="wwwroot/**/*.*" />
    </ItemGroup>

    <Target Name="CopyAssets" AfterTargets="Build">
        <Message  Importance="high" Text="Copying...."/>
        <Copy SourceFiles="@(WwwRootFiles)" DestinationFiles=".bionic/wwwroot/%(RecursiveDir)/%(Filename)%(Extension)" SkipUnchangedFiles="false" />
    </Target>
``` 

The above target will synchronize your destination root directory with the latest content changes in wwwroot directory.
Notice that above example is using ```.bionic/wwwroot``` as its destination root directory. Replace it with your
destination root directory.

Finally, if you have kept ```.bionic/wwwroot``` then start Bionic Monitor using:

```text
> biomon --bionic
```

or, if you are using another destination root directory:

```text
> biomon --destinationRootDirectory "my/other/directory"
``` 

Once Bionic Monitor is running, the page will be automatically reloaded every-time you build your app.


## Hosted project setup

Hosted uses the same setup as Standalone and opens CORS on the Hosted Server.
On the _.Client_ project start Bionic Monitor on specific ports different than the one being used by the _.Server_:

```text
> biomon --bionic --port 3434 --securePort 3535
``` 

Add the following to _.Server_ Startup.cs file:

```c#
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            // Add the following line before AddMvc
            services.AddCors(options =>
                options.AddPolicy("AllowDevClient", builder =>
                builder.WithOrigins("http://localhost:3434")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials())
            );
            services.AddMvc();
            ...
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            // Add the following line before UseMvc
            app.UseCors("AllowDevClient");
            app.UseMvc(routes =>
            ...
        }
```

Build and start Hosted server.


## Building your app

The specified AfterBuild target will be executed by default whenever the project is built using:

- ```dotnet build``` on the command line
- Microsoft Visual Studio build command (⌘K on VS Mac)
- Build hammer (🔨) if using JetBrains Rider
- Automatic builds using DotNet Watcher (see next)

!!! tip
    You will have to enable [AfterBuild](https://www.jetbrains.com/help/rider/Build_Process.html) in Rider.


### Setting DotNet Watcher to auto build your app

Add the following watcher configuration to .csproj file (client side).
If you use Bionic, you do not require this step as it is automatically added for you when you start your project
with Bionic.

```xml
  <ItemGroup>
    <Watch Include="**/*.cshtml;**/*.html;**/*.css" Exclude="rootbeer/**/*.*" Visible="false" />
  </ItemGroup>
```

or, if in a Bionic app:

```xml
  <ItemGroup>
    <Watch Include="**/*.cshtml;**/*.html;**/*.scss" Visible="false" />
  </ItemGroup>
```

Remove ```**/*.scss``` if you are not using SASS/SCSS to build your styles.

In addition, update the following two entries in the same file:

```xml
        <RunCommand>echo</RunCommand>
        <RunArguments>Reloading...</RunArguments>
```

Save and execute using:

```dotnet watch run```

On another terminal start Bionic Monitor with your preferences and now every-time a code change is detected, the
project will be automatically built and reloaded.


## Bionic Monitor configuration

You can configure Bionic Monitor through the command line options as displayed bellow.

```text
○ → biomon --help
🤖 Bionic Monitor - Live Reload for Blazor & Bionic projects

Usage: BionicMonitor [options] [command]

Options:
  --bionic              Use Bionic root directory .bionic/wwwroot (will not mess with files in wwwroot)
  --signalRProvided     Enable if app already provides SignalR lib
  --hostOrIp            Listening interface - defaults to localhost
  --port                Serving port number - defaults to 5000
  --securePort          Serving secure port number - defaults to 5001
  --destinationRootDir  Destination root directory - defaults to wwwroot or .bionic/wwwroot with --bionic option enabled
  --sourceRootDir       Source root directory - defaults to wwwroot
  -?|-h|--help          Show help information

Commands:
  docs                  Open Bionic Monitor documentation page in browser
  uninstall             Initiate Bionic self-destruct sequence
  update                Update Bionic Monitor to its latest incarnation
  version               Print Bionic Monitor version number

Run 'BionicMonitor [command] --help' for more information about a command.
```

Another option is to make use of Bionic Monitor configuration file. Bionic Monitor looks first for ```./biomon.json```
and then for ```.bionic/biomon.json```. Here's a sample config file with default values:  

```json
{
  "useBionic": false,
  "isSignalRProvided": false,
  "hostOrIp": "localhost",
  "port": "5000",
  "securePort": "5001",
  "destinationRootDir": "wwwroot",
  "sourceRootDir": "wwwroot"
}
```

Note that if using default values, then you can remove default entries from json file:

```json
{
  "useBionic": true
}
```

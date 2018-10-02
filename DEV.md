# Development Notes

## Debug Build

```bash
dotnet build
```

## Building release from the command line:

```bash
dotnet build -c Release /p:SourceLinkCreate=true /p:VersionSuffix= /p:OfficialBuild=true
```

## Creating packages from command line:

```bash
dotnet pack -c Release /p:SourceLinkCreate=true /p:VersionSuffix= /p:OfficialBuild=true
```

## Install or upgrade local Bionic version using latest package:

```bash
dotnet tool update -g Bionic --add-source ./nupkg
```

 ## Running the CLI

 ### Using the latest DLL

 ```bash
 dotnet ./bin/Debug/netcoreapp2.1/Bionic.dll -v
 dotnet ./bin/Release/netcoreapp2.1/Bionic.dll -v
 ```

 ### Using the CLI

 ```bash
 bionic -v
 ```

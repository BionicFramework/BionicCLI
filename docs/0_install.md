# Install Bionic

## Before you install

A few things are required to be installed before bionic can be used. If you already have them installed, just skip ahead.

### .Net Core SDK

Because Bionic builds on the top of the amazing Blazor project, the first thing you need to do is to install [.Net Core SDK](https://blazor.net/docs/get-started.html#setup).

!!! tip
    If you are not using Visual Studio, [installing .Net Core SDK](https://www.microsoft.com/net/download) will suffice.

Check if dotnet is installed:

```text
> dotnet --version
2.1.402
```

Blazor requires version 2.1.300 or above.

### SASS/SCSS compiler

Bionic uses SASS/SCSS for styling and requires an SCSS compiler. Please [install SASS](https://sass-lang.com/install) compiler.

Check if SCSS is installed:

```text
> sass --version
1.13.1
```

or, depending on which version you have installed:

```text
> sass --version
Ruby Sass 3.5.6
```


## Installing Bionic

Bionic releases are available through [NuGet](https://www.nuget.org/packages/Bionic).

To install it execute:
```text
> dotnet tool install --global Bionic
You can invoke the tool using the following command: bionic
Tool 'bionic' (version '1.0.17') was successfully installed.
```

And check if it was installed by executing:
```text
> bionic -v
🤖 Bionic v1.0.17
```

## Updating Bionic

To update execute:
```text
> bionic update
Tool 'bionic' was reinstalled with the latest stable version (version '1.0.17').
```

## Removing Bionic

To remove execute:
```text
> bionic uninstall
Tool 'bionic' (version '1.0.17') was successfully uninstalled.
```

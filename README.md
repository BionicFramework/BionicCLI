<div style="text-align:center"><img src="https://raw.githubusercontent.com/bmsantos/bionic/master/docs/images/logo-full.png" alt="bionic" height="150"/></div>

Build web apps [Blazor](https://blazor.net) fast that run at [WASM speed](https://hackernoon.com/screamin-speed-with-webassembly-b30fac90cd92)!

<div style="text-align:center">
    <a href="https://bmsantos.github.io/bionic/platforms/capacitor/ios"><img src="https://raw.githubusercontent.com/bmsantos/bionic/master/docs/images/apple-logo.png" alt="iOS" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <a href="https://bmsantos.github.io/bionic/platforms/electron"><img src="https://raw.githubusercontent.com/bmsantos/bionic/master/docs/images/electron-logo.png" alt="Electron" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <a href="https://bmsantos.github.io/bionic/platforms/capacitor/android"><img src="https://raw.githubusercontent.com/bmsantos/bionic/master/docs/images/android-logo.png" alt="Android" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <img src="https://raw.githubusercontent.com/bmsantos/bionic/master/docs/images/pwa-logo.png" alt="PWA" height="40px"/>
</div>


# Bionic: An Ionic CLI clone for Blazor projects


[![YouTube Video](https://img.youtube.com/vi/NONCv-i4Q34/0.jpg)](https://youtu.be/NONCv-i4Q34)

[Documentation](http://bmsantos.github.com/bionic) is now available.

## Quick Start

Before we start, make sure that the following tools are available in your system:

- ### SASS is installed and available in your terminal path

You can install sass from [here](https://sass-lang.com/install).
Ensure availability by executing scss command:
```bash
scss --version
Ruby Sass 3.5.6
```

- ### NodeJS is installed and available in your terminal path

You can install node from [here](https://nodejs.org/).
Ensure availability by executing node command:
```bash
node --version
v9.5.0
```

```bash
npm --version
5.6.0
```

The following steps are only required to be executed once:

1. Create a [Blazor App](https://blazor.net/docs/get-started.html)
2. Install Bionic from [NuGet](https://www.nuget.org/packages/Bionic): ```dotnet tool install --global Bionic```
3. Prepare Blazor project for Bionic: ```bionic start```

The next steps are part of your day-to-day development:

4. Run project: ```bionic serve```
5. In a secondary terminal, cd into your project root directory
6. Create a new component: ```bionic generate component CounterComponent```
7. Edit component and reuse it anywhere you want...

## Sample Bionic commands

### Version
```bash
bionic version
```

### Updating Bionic

```bash
bionic update
```

### Uninstalling Bionic

```bash
bionic uninstall
```

### Using Electron platform plugin

[Watch introduction video here](https://www.youtube.com/watch?v=2aGTsSe7-MU&t=5s)

You'll need the following tools installed:
- Recent version of [NodeJS](https://nodejs.org/en/) installed

```bash
bionic platform add electron
bionic platform electron init
bionic platform electron build
bionic platform electron serve
```

### Using Capacitor platform plugin

[Watch introduction video here](https://www.youtube.com/watch?v=67A1ZVlyUfA)

You'll need the following tools installed:
- Recent version of [NodeJS](https://nodejs.org/en/) installed
- [Android Studio](https://developer.android.com/studio/)

```bash
bionic platform add capacitor
bionic platform capacitor init
bionic platform capacitor android init
bionic platform capacitor android build
bionic platform capacitor android open
```

### Creating Blazor pages

```bash
bionic generate page MyPage
```

### Creating Blazor components

```bash
bionic generate component MyComponent
```

### Creating Blazor services

```bash
bionic generate service MyService
```

### Using Bionic Blast scripts

Blast scripts are easy to use and organize.
They are most useful to easily set build sequences.

In your Blazor project Client or Standalone directory, use your favorite text editor or IDE to create or edit ```.bionic/bionic.blast```
Add the following content and save it:

```text
:electron
>electron-init
>electron-build

:electron-init
bionic platform add electron
bionic platform electron init

:electron-build
bionic platform electron build
bionic platform electron serve
```

Lines starting with:
```text
: - targets
> - sub-targets. Make sure that there are no spaces after it.
```
Any other type of line is a cli command.
 
# Blast scripts not executing?

There's a bug in [dotnet tools](https://github.com/dotnet/cli/issues/9321) that is preventing bionic tool from being found in the system path.
There are several solutions. If you are in OSX, just edit ```/etc/paths.d/dotnet-cli-tools``` to be ```$HOME/.dotnet/tools```.
Did not try in Linux, but you may have to do the same or just edit your shell init script accordingly.


Then have bionic blast it away: ```bionic blast electron```

# Introduction

[Capacitor](https://capacitor.ionicframework.com) is a modern "Native Progressive Web Apps" platform. Through it, Bionic apps can currently be deployed in iOS and Android (Capacitor Web and Capacitor Electron coming soon).

## Requirements

### NodeJS

Capacitor depends on NodeJS. Please [install](https://nodejs.org/en/download/) or ensure that you are using a current NodeJS version:

```text
> node --version
v9.5.0
```

### Android Studio

If you intend to target Android in this project, you will need to [download and install Android Studio](https://developer.android.com/studio).

### iOS

If you intend to target iOS (iPhone/iPad and whatever starts with i), you will need to have an Apple Mac and [download and install XCode](https://itunes.apple.com/us/app/xcode/id497799835?mt=12).

## Getting Started with Capacitor

First, we need to download and install Bionic's Capacitor Plugin. This step is only required once per project. From your project (or Blazor Client) directory do:

```text
> bionic platform add capacitor
🔍  Looking for capacitor platform plugin
☕  Found it! Adding capacitor plugin...
🚀  capacitor platform successfully added
```

This will create the necessary assets under ```platforms/capacitor```.

Next you need to initialize Capacitor. The process will ask for an App name and an App package ID. Please make sure the package ID follows the [Java package naming convention](https://docs.oracle.com/javase/tutorial/java/package/namingpkgs.html):

```text
> bionic platform capacitor init
...
? App name BionicApp
? App Package ID (must be a valid Java package) com.bionic.app
✔ Initializing Capacitor project in
...
```

## Capacitor Targets

Capacitor can deploy in 4 different targets:

- [Android](../android)
- Electron (not available through Bionic yet)
- [iOS](../ios)
- Web (not available through Bionic yet)

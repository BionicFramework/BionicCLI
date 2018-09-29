# Splash Screen

!!! success "iOS, Android"

The Splash Screen API provides methods for showing or hiding a Splash image.

## Methods

[SplashScreenBridge.Show()](#show)

[SplashScreenBridge.Hide()](#hide)

## Example

```c#
    // Show splash screen
    SplashScreenBridge.Show();

    // Hide splash screen
    SplashScreenBridge.Hide();
```

## API

### Show

Show the splash screen

> static Task Show([SplashScreenShowOptions](#splashscreenshowoptions) options = null)

### Hide

Hide the splash screen

> static Task Hide([SplashScreenHideOptions](#splashscreenhideoptions) options = null)

## Models

#### SplashScreenShowOptions

```c#
    public class SplashScreenShowOptions {
        public bool autoHide;
        public long fadeInDuration;
        public long fadeOutDuration;
        public long showDuration;
    }
```

#### SplashScreenHideOptions

```c#
    public class SplashScreenHideOptions {
        public long fadeOutDuration;
    }
```
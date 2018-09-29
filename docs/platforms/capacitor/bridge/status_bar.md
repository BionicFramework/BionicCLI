# Status Bar

!!! success "iOS, Android"

The StatusBar API Provides methods for configuring the style of the Status Bar, along with showing or hiding it.

## Methods

[StatusBarBridge.Show()](#show)

[StatusBarBridge.Hide()](#hide)

[StatusBarBridge.SetBackgroundColor()](#setbackgroundcolor)

[StatusBarBridge.SetStyle()](#setstyle)

## Example

```c#
    // Show Status Bar
    StatusBarBridge.Show();
    
    // Hide Status Bar
    StatusBarBridge.Hide();
    
    // Set Status Bar bg color
    StatusBarBridge.SetBackgroundColor("blue");

    // Set Status Bar style
    StatusBarBridge.SetStyle(StatusBarStyle.Light);
```

## API

### Show

Show status bar

> static Task Show()

### Hide

Hide status bar

> static Task Hide()

### SetBackgroundColor

Set status bar background color

> static Task SetBackgroundColor(string color)

### SetStyle

Set status bar text color style

> static Task SetStyle([StatusBarStyle](#statusbarstyle) style)

## Models

#### StatusBarStyle

```c#
    public enum StatusBarStyle {
        Dark,
        Light
    }
```
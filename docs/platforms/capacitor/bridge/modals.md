# Modals

!!! success "iOS, Android, Electron, PWA"

The Modals API provides methods for triggering native modal windows for alerts, confirmations, and input prompts, as well as Action Sheets.

## Methods

[ModalsBridge.Alert()](#alert)

[ModalsBridge.Confirm()](#confirm)

[ModalsBridge.Prompt()](#prompt)

[ModalsBridge.ShowActions()](#showactions)

## Example

```c#
    private static async Task ModalsAlert() {
        try {
            var options = new AlertOptions {
                title = "🤖 Bionic Alert",
                message = "Capacitor Bridge is now available.",
                buttonTitle = "Got it!"
            };
            await ModalsBridge.Alert(options);
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task ModalsConfirm() {
        try {
            var options = new ConfirmOptions {
                title = "🤖 Bionic Confirm",
                message = "Adding exoskeleton...",
                okButtonTitle = "💀 Proceed",
                cancelButtonTitle = "Stop"
            };
            var result = await ModalsBridge.Confirm(options);
            Console.WriteLine(result.value
                ? "💀 You chose to proceed"
                : "☠ Enjoy your weak limbs");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task ModalsPrompt() {
        try {
            var options = new PromptOptions {
                title = "🤖 Bionic Prompt",
                message = "Please insert your Bionic name",
                okButtonTitle = "Move on...",
                cancelButtonTitle = "Nope",
                inputPlaceholder = "01001001"
            };
            var result = await ModalsBridge.Prompt(options);
            Console.WriteLine(result.cancelled ? "I'm 💔" : $"We 💘 you - {result.value}");
        }
        catch (Exception e) {
            // Handle error
        }
    }

    private static async Task ModalsShowActions() {
        try {
            var options = new ActionSheetOptions {
                title = "🤖 Bionic Show Actions",
                message = "Choose your upgrade:",
                options = new ActionSheetOption[3] {
                    new ActionSheetOption {
                        title = "Titanium Exoskeleton",
                        style = ActionSheetOptionStyle.Default,
                        icon = "nuclear"
                    },
                    new ActionSheetOption {
                        title = "Cybernetic Eye",
                        style = ActionSheetOptionStyle.Destructive,
                        icon = "eye"
                    },
                    new ActionSheetOption {
                        title = "I'm good, thanks!",
                        style = ActionSheetOptionStyle.Cancel,
                    }
                }
            };
            var result = await ModalsBridge.ShowActions(options);
            var msg = "You're already perfect!";
            if (result.index != options.options.Length - 1) {
                msg = result.index == 0 ? "Enjoy your new 💪" : "Enjoy your new 👁";
            }
            Console.WriteLine(msg);
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### Alert

Show an alert modal

> static Task Alert(AlertOptions options)

### Confirm

Show a confirmation modal

> static Task&lt;[ConfirmResult](#confirmresult)&gt; Confirm([ConfirmOptions](#confirmoptions) options)

### Prompt

Show a prompt modal

> static Task&lt;[PromptResult](#promptresult)&gt; Prompt([PromptOptions](#promptoptions) options)

### ShowActions

Show an Action Sheet style modal with various options for the user to select.

> static Task&lt;[ActionSheetResult](#actionsheetresult)&gt; ShowActions([ActionSheetOptions](#actionsheetoptions) options)

## Models

#### AlertOptions

```c#
    public class AlertOptions {
        public string title;
        public string message;
        public string buttonTitle;
    }
```

#### ConfirmOptions

```c#
    public class ConfirmOptions {
        public string title;
        public string message;
        public string okButtonTitle;
        public string cancelButtonTitle;
    }
```

#### ConfirmResult

```c#
    public class ConfirmResult {
        public bool value;
    }
```

#### PromptOptions

```c#
    public class PromptOptions {
        public string title;
        public string message;
        public string okButtonTitle;
        public string cancelButtonTitle;
        public string inputPlaceholder;
    }
```

#### PromptResult

```c#
    public class PromptResult {
        public bool cancelled;
        public string value;
    }
```

#### ActionSheetOptions

```c#
    public class ActionSheetOptions {
        public string title;
        public string message;
        public ActionSheetOption[] options;
    }
```

#### ActionSheetOption

```c#
    public class ActionSheetOption {
        public string title;
        public string style;
        public string icon;
    }
```

#### ActionSheetResult

```c#
    public class ActionSheetResult {
        public long index;
    }
```

#### ActionSheetOptionStyle

```c#
    public static class ActionSheetOptionStyle {
        public static string Default = "DEFAULT";
        public static string Destructive = "DESTRUCTIVE";
        public static string Cancel = "CANCEL";
    }
```

# Camera

!!! success "iOS, Android, Electron, PWA"

The Camera API allows a user to pick a photo from their photo album or take a picture. On iOS, this uses UIImagePickerController, and on Android this API sends an intent which will be handled by the core Camera app by default.

## Methods

[CameraBridge.GetPhoto()](#getphoto)

## Example

```c#
    string ImageSrc;
    private async Task Camera() {
        var options = new CameraOptions {
            quality = 90,
            allowEditing = true,
            resultType = CameraResultType.Uri
        };
        try {
            var image = await CameraBridge.GetPhoto(options);
            ImageSrc = image.webPath;
        }
        catch (Exception e) {
            // Handle error
        }
    }
```

## API

### GetPhoto

Prompt the user to pick a photo from an album, or take a new photo with the camera.

> static Task&lt;CameraPhoto&gt; GetPhoto([CameraOptions](#cameraoptions) options)

## Models

#### CameraOptions

```c#
    public class CameraOptions {
        public int quality; // The quality of image to return as JPEG, from 0-100
        public bool allowEditing; // Whether to allow the user to crop or make small edits (platform specific)
        public CameraResultType resultType; // How the data should be returned. Currently, only 'base64' or 'uri' is supported
        public bool saveToGallery; // Whether to save the photo to the gallery/photostream
        public int width; // The width of the saved image
        public int height; // The height of the saved image
        public bool correctOrientation; // Whether to automatically rotate the image "up" to correct for orientation in portrait mode. Default: true
        public CameraSource source; // The source to get the photo from. By default this prompts the user to select either the photo album or take a photo. Default: CameraSource.Prompt
    }

    public enum CameraResultType {
        Uri,
        Base64
    }

    public enum CameraSource {
        Prompt,
        Camera,
        Photos,
    }
```


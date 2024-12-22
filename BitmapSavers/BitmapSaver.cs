using System.Drawing.Imaging;

namespace BitmapSavers;

public class BitmapSaver
{
    public string Save(ImageSaveSettings saveSettings)
    {
        var bitmap = saveSettings.Bitmap;
        var path = saveSettings.Path;
        var name = saveSettings.Name;
        var format = saveSettings.Format;

        if (bitmap == null) throw new ArgumentNullException(nameof(bitmap), "Bitmap cannot be null.");
        if (string.IsNullOrEmpty(path)) throw new ArgumentException("Path cannot be null or empty.", nameof(path));

        var imageFormat = GetImageFormat(format);
        var fullPath = Path.Combine(Path.GetFullPath(path), name, format.ToString());

        try
        {
            bitmap.Save(fullPath, imageFormat);
        }
        catch (Exception ex)
        {
            throw new IOException($"Error saving image to path: {fullPath}. Error: {ex.Message}", ex);
        }
    }

    private ImageFormat GetImageFormat(ImageSaveFormat imgSaveFormat)
    {
        return imgSaveFormat switch
        {
            ImageSaveFormat.Bmp => ImageFormat.Bmp,
            ImageSaveFormat.Emf => ImageFormat.Emf,
            ImageSaveFormat.Jpeg => ImageFormat.Jpeg,
            ImageSaveFormat.Png => ImageFormat.Png,
            ImageSaveFormat.Wmf => ImageFormat.Wmf,
            _ => throw new ArgumentException("The transmitted type is not supported");
        };
    }
}
using System.Drawing;

namespace TagCloud.Visualisers;

public interface IBitmapCreator
{
    public static abstract Bitmap GenerateImage(IEnumerable<TagCloudWord> cloudWords, ImageCreateSettings settings);
}
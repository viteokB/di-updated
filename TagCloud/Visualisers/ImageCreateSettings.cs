using System.Drawing;

namespace TagCloud.Visualisers;

public record ImageCreateSettings(
    Size ImageSize,
    Color BackgroundColor,
    FontFamily FontFamily,
    int FontMinSize,
    int FontMaxSize,
    Color WordColor);
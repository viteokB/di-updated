using FractalPainting.Infrastructure.Common;

namespace di.Infrastructure.Common;

public interface IImageSettingsProvider
{
    ImageSettings ImageSettings { get; }
}
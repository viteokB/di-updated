using di.Infrastructure.Common;

namespace FractalPainting.Infrastructure.Common;

public interface IImageSettingsProvider
{
    ImageSettings ImageSettings { get; }
}
using FractalPainting.Application.Fractals;

namespace FractalPainting.Infrastructure.Common;

public interface IDragonPainterFactory
{
    DragonPainter Create(DragonSettings settings);
}
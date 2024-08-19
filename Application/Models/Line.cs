namespace FractalPainting.Application.Models;

internal sealed record Line(Point Begin, Point End, Color Color) : Figure
{
    public override string Type => "Line";
}
namespace di.Application.Models;

public sealed record Rectangle(int Width, int Height, Point Begin, Color Color) : Figure
{
    public override string Type => "Rectangle";
}
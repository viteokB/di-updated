namespace di.Infrastructure.Common;

public class Palette
{
    public Application.Models.Color PrimaryColor { get; set; } = new(255, 255, 0); // 255 255 0
    public Application.Models.Color SecondaryColor { get; set; } = new(255, 0, 0); // 255 0 0
    public Application.Models.Color BackgroundColor { get; set; } = new(0, 0, 139); // 0 0 139
}
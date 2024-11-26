using System.Net;
using System.Text.Json;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;
using Microsoft.Extensions.DependencyInjection;

namespace FractalPainting.Application.Actions;

public class KochFractalAction : IApiAction, INeed<Palette>, INeed<IImageSettingsProvider>
{
    private readonly JsonSerializerOptions jsonSerializerOptions =
        new() { Converters = { new FigureJsonConverter() } };
    private Palette palette = null!;
    private IImageSettingsProvider imageSettingsProvider = null!;

    public void SetDependency(Palette dependency)
    {
        palette = dependency;
    }
    
    public void SetDependency(IImageSettingsProvider dependency)
    {
        imageSettingsProvider = dependency;
    }

    public string Endpoint => "/kochFractal";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var services = new ServiceCollection();
        services.AddSingleton(palette);
        services.AddSingleton(imageSettingsProvider);
        services.AddSingleton<KochPainter>();
        var sp = services.BuildServiceProvider();

        var painter = sp.GetRequiredService<KochPainter>();
        var figures = painter.Paint();
        JsonSerializer.Serialize(outputStream, figures, options: jsonSerializerOptions);
        return (int)HttpStatusCode.OK;
    }
}
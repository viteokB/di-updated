using System.Net;
using System.Text.Json;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class GetPaletteSettingsAction : IApiAction, INeed<Palette>
{
    private Palette palette = null!;

    public void SetDependency(Palette dependency)
    {
        palette = dependency;
    }

    public string Endpoint => "/palette";
        
    public string HttpMethod => "GET";
        
    public int Perform(Stream inputStream, Stream outputStream)
    {
        JsonSerializer.Serialize(outputStream, palette);
        return (int)HttpStatusCode.OK;
    }
}
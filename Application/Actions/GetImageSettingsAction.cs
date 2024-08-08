using System.Net;
using System.Text.Json;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Injection;

namespace di.Application.Actions;

public class GetImageSettingsAction : IApiAction, INeed<IImageSettingsProvider>
{
    private IImageSettingsProvider? imageSettingsProvider;

    public void SetDependency(IImageSettingsProvider dependency)
    {
        imageSettingsProvider = dependency;
    }

    public string Endpoint => "/settings";
        
    public string HttpMethod => "GET";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var settings = imageSettingsProvider?.ImageSettings;
        JsonSerializer.Serialize(outputStream, settings);
        return (int)HttpStatusCode.OK;
    }
}
using System.Net;
using System.Text.Json;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Injection;

namespace di.Application.Actions
{
    public class GetPaletteSettingsAction : IApiAction, INeed<Palette>
    {
        private Palette palette;

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
}
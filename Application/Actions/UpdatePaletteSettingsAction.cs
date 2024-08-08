using System.Net;
using System.Text.Json;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;

namespace di.Application.Actions
{
    public class UpdatePaletteSettingsAction : IApiAction, INeed<Palette>
    {
        private Palette palette;

        public void SetDependency(Palette dependency)
        {
            palette = dependency;
        }

        public string Endpoint => "/palette";

        public string HttpMethod => "PUT";

        public int Perform(Stream inputStream, Stream outputStream)
        {
            try
            {
                var updatedPalette = JsonSerializer.Deserialize<Palette>(inputStream);
                palette.BackgroundColor = updatedPalette?.BackgroundColor ?? palette.BackgroundColor;
                palette.PrimaryColor = updatedPalette?.PrimaryColor ?? palette.PrimaryColor;
                palette.SecondaryColor = updatedPalette?.SecondaryColor ?? palette.SecondaryColor;
            }
            catch (Exception _)
            {
                return (int)HttpStatusCode.InternalServerError;
            }

            return (int)HttpStatusCode.OK;
        }
    }
}
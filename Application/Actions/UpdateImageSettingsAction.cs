using System.Net;
using System.Text.Json;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Injection;

namespace di.Application.Actions
{
    public class UpdateImageSettingsAction : IApiAction, INeed<IImageSettingsProvider>
    {
        private IImageSettingsProvider imageSettingsProvider;

        public void SetDependency(IImageSettingsProvider dependency)
        {
            imageSettingsProvider = dependency;
        }

        public string Endpoint => "/settings";
        public string HttpMethod => "PUT";

        public int Perform(Stream inputStream, Stream outputStream)
        {
            try
            {
                var updatedSettings = JsonSerializer.Deserialize<ImageSettings>(inputStream);
                var settings = imageSettingsProvider.ImageSettings;
                settings.Height = updatedSettings?.Height ?? settings.Height;
                settings.Width = updatedSettings?.Width ?? settings.Width;
            }
            catch (Exception _)
            {
                return (int)HttpStatusCode.InternalServerError;
            }

            return (int)HttpStatusCode.OK;
        }
    }
}
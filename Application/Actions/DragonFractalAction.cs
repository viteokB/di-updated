using System.Net;
using System.Text.Json;
using di.Application.Fractals;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Injection;
using Microsoft.Extensions.DependencyInjection;

namespace di.Application.Actions
{
    public class DragonFractalAction : IApiAction, INeed<IImageSettingsProvider>
    {
        private readonly JsonSerializerOptions jsonSerializerOptions =
            new() { Converters = { new FigureJsonConverter() } };
        private IImageSettingsProvider imageSettingsProvider;
        
        public string Endpoint => "/dragonFractal";

        public string HttpMethod => "POST";

        public int Perform(Stream inputStream, Stream outputStream)
        {
            var dragonSettings = JsonSerializer.Deserialize<DragonSettings>(inputStream);
            var services = new ServiceCollection();
            services.AddSingleton(dragonSettings!);
            services.AddSingleton(imageSettingsProvider);
            services.AddSingleton<DragonPainter>();
            var sp = services.BuildServiceProvider();

            var painter = sp.GetRequiredService<DragonPainter>();
            var figures = painter.Paint();
            JsonSerializer.Serialize(outputStream, figures, options: jsonSerializerOptions);

            return (int)HttpStatusCode.OK;
        }

        public void SetDependency(IImageSettingsProvider dependency)
        {
            imageSettingsProvider = dependency;
        }
    }
}
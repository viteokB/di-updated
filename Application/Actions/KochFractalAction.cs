using System.Net;
using System.Text.Json;
using di.Application.Fractals;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Injection;
using Microsoft.Extensions.DependencyInjection;

namespace di.Application.Actions
{
    public class KochFractalAction : IApiAction, INeed<Palette>, INeed<IImageSettingsProvider>
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private Palette palette;
        private IImageSettingsProvider imageSettingsProvider;

        public KochFractalAction()
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new FigureJsonConverter() }
            };
        }

        public void SetDependency(Palette dependency)
        {
            palette = dependency;
        }

        public string Endpoint => "/kochFractal";
        
        public string HttpMethod => "GET";

        public int Perform(Stream inputStream, Stream outputStream)
        {
            var services = new ServiceCollection();
            services.AddSingleton(palette);
            services.AddSingleton(imageSettingsProvider);
            services.AddSingleton<KochPainter>();
            var sp = services.BuildServiceProvider();

            var painter = sp.GetRequiredService<KochPainter>();
            var figures = painter.Paint();
            JsonSerializer.Serialize(outputStream, figures, jsonSerializerOptions);
            return (int)HttpStatusCode.OK;
        }

        public void SetDependency(IImageSettingsProvider dependency)
        {
            imageSettingsProvider = dependency;
        }
    }
}
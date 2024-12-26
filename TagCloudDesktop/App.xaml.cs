using System.Configuration;
using System.Data;
using System.Windows;
using Autofac;
using Autofac.Core;
using BitmapSavers;
using TagCloud;
using TagCloud.Factory;
using TagCloud.Interfaces;
using TagCloud.Visualisers;
using TagCloudDesktop.DI;
using WordHandlers;
using WordHandlers.Handlers;
using WordReaders.Factory;

namespace TagCloudDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();

            //BitmapSaver
            builder.RegisterType<BitmapSaver>().AsSelf().SingleInstance();
            builder.RegisterType<ImageSaveSettings>();

            //TagCloud
            builder.RegisterType<SpiralPointGeneratorFactory>()
                .As<ISpiralPointGeneratorFactory>().SingleInstance();
            builder.RegisterType<TagCloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<TagCloudCreator>().AsSelf().SingleInstance();
            builder.RegisterType<ImageCreateSettings>().AsSelf();

            //WordHandlers
            builder.RegisterType<LowercaseWordHandler>().As<IWordHandler>();
            builder.RegisterType<BoringWordHandler>().As<IWordHandler>();

            //WordReaders
            builder.RegisterType<WordReaderFactory>().As<IWordReaderFactory>().SingleInstance();

            var container = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TagCloudModule());
            builder.RegisterModule(new WpfModule());
            var container = builder.Build();
        }
    }
}

using Autofac;
using CommandLine;
using System.IO;
using BitmapSavers;
using ConsoleClient.Services;
using TagCloud.Factory;
using TagCloud.Interfaces;
using TagCloud.Visualisers;
using TagCloud;
using TagCloud.RayMovers;
using TagCloud.SpiralPointGenerators;
using WordHandlers.Handlers;
using WordHandlers;
using WordReaders.Factory;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
            var settingsProvider = new SettingsProvider(options);
            var settings = settingsProvider.GetSettingsStorage();
            var builder = new ContainerBuilder();

            RegisterBitmapSaverClasses(builder);
            RegisterTagCloudClasses(builder);
            RegisterWordHandlersClasses(builder);
            RegisterWordReadersClasses(builder);
            RegisterFromInstance(builder, settings);
            RegisterConsoleClientServices(builder);

            var container = builder.Build();
            
            var tagCloudImageCreator = container.Resolve<TagCloudImageCreator>();
            tagCloudImageCreator.CreateCloudImage();
        }

        static void RegisterConsoleClientServices(ContainerBuilder builder)
        {
            builder.RegisterType<FileWordReader>().AsSelf().SingleInstance();
            builder.Register<FilteredWordsCounter>(context =>
            {
                var wordHandlers = context.Resolve<IEnumerable<IWordHandler>>();
                var list = new List<Func<IEnumerable<string>, IEnumerable<string>>>();
                foreach (var wordHandler in wordHandlers)
                {
                    list.Add(wordHandler.ApplyWordHandler);
                }
                return new FilteredWordsCounter(list);
            });
            builder.RegisterType<TagCloudImageCreator>().AsSelf().SingleInstance();
        }

        static void RegisterFromInstance(ContainerBuilder builder, SettingsStorage settings)
        {
            builder.RegisterInstance(settings.ImageSave);
            builder.RegisterInstance(settings.ImageCreate);
            builder.RegisterInstance(settings.ReaderSettings);

            var spiralFactory = new SpiralPointGeneratorFactory();

            builder.RegisterInstance(spiralFactory.CreateSpiralPointGenerator(settings.ImageCreate));
        }

        static void RegisterBitmapSaverClasses(ContainerBuilder builder)
        {
            //BitmapSaver
            builder.RegisterType<BitmapSaver>().AsSelf().SingleInstance();
        }

        static void RegisterTagCloudClasses(ContainerBuilder builder)
        {
            //TagCloud
            builder.RegisterType<SpiralPointGeneratorFactory>()
                .As<ISpiralPointGeneratorFactory>().SingleInstance();
            builder.RegisterType<TagCloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<TagCloudCreator>().AsSelf().SingleInstance();

            //SpiralPointGenerators в RegisterFromInstance
        }

        static void RegisterWordHandlersClasses(ContainerBuilder builder)
        {
            //WordHandlers
            builder.RegisterType<LowercaseWordHandler>().As<IWordHandler>();
            builder.RegisterType<BoringWordHandler>().As<IWordHandler>();
        }

        static void RegisterWordReadersClasses(ContainerBuilder builder)
        {
            //WordReaders
            builder.RegisterType<WordReaderFactory>().As<IWordReaderFactory>().SingleInstance();
        }
    }
}

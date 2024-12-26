using Autofac;
using BitmapSavers;
using CommandLine;
using ConsoleClient.Services;
using TagCloud;
using TagCloud.Factory;
using TagCloud.Interfaces;
using WordHandlers;
using WordHandlers.Handlers;
using WordHandlers.Interfaces;
using WordHandlers.WordCounters;
using WordReaders;
using WordReaders.Factory;
using WordReaders.Readers;

namespace ConsoleClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var result = Parser.Default.ParseArguments<CommandLineOptions>(args);
        var options = result.Value;

        result.WithParsed(options =>
        {
            options.DisplayOptions();
            var settingsProvider = new SettingsProvider(options);
            var settings = settingsProvider.GetSettingsStorage();
            var builder = new ContainerBuilder();

            RegisterBitmapSaverClasses(builder);
            RegisterTagCloudClasses(builder);
            RegisterWordHandlersClasses(builder);
            RegisterWordReadersClasses(builder);
            RegisterUsingSettings(builder, settings);
            RegisterConsoleClientServices(builder);

            var container = builder.Build();

            try
            {
                var tagCloudImageCreator = container.Resolve<TagCloudImageCreator>();
                tagCloudImageCreator.CreateCloudImage();
                Console.WriteLine("Облако тегов успешно создано.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при создании облака тегов: {ex.Message}");
            }
        })
        .WithNotParsed(errors =>
        {
            Console.WriteLine("Ошибка при парсинге аргументов:");
            foreach (var error in errors)
            {
                Console.WriteLine($"- {error}");
            }
        });
    }

    private static void RegisterConsoleClientServices(ContainerBuilder builder)
    {
        builder.RegisterType<TagCloudImageCreator>().AsSelf().SingleInstance();
    }

    private static void RegisterUsingSettings(ContainerBuilder builder, SettingsStorage settings)
    {
        builder.RegisterInstance(settings.ImageSave);
        builder.RegisterInstance(settings.ImageCreate);
        builder.RegisterInstance(settings.ReaderSettings);

        var spiralFactory = new SpiralPointGeneratorFactory();
        builder.RegisterInstance(spiralFactory.CreateSpiralPointGenerator(settings.ImageCreate));
    }

    private static void RegisterBitmapSaverClasses(ContainerBuilder builder)
    {
        //BitmapSaver
        builder.RegisterType<BitmapSaver>().AsSelf().SingleInstance();
    }

    private static void RegisterTagCloudClasses(ContainerBuilder builder)
    {
        builder.RegisterType<SpiralPointGeneratorFactory>()
            .As<ISpiralPointGeneratorFactory>().SingleInstance();
        builder.RegisterType<TagCloudLayouter>().As<ICloudLayouter>();
        builder.RegisterType<TagCloudBitmapCreator>().AsSelf().SingleInstance();

        //SpiralPointGenerators в RegisterUsingSettings
    }

    private static void RegisterWordHandlersClasses(ContainerBuilder builder)
    {
        builder.RegisterType<LowercaseWordHandler>().As<IWordHandler>();
        builder.RegisterType<BoringWordHandler>().As<IWordHandler>();

        builder.Register<FilteredWordsCounter>(context =>
        {
            var wordHandlers = context.Resolve<IEnumerable<IWordHandler>>();
            var list = new List<Func<IEnumerable<string>, IEnumerable<string>>>();
            foreach (var wordHandler in wordHandlers) list.Add(wordHandler.ApplyWordHandler);
            return new FilteredWordsCounter(list);
        }).As<IWordCounter>();
    }

    private static void RegisterWordReadersClasses(ContainerBuilder builder)
    {
        //WordReaders
        builder.RegisterType<WordReaderFactory>().As<IWordReaderFactory>().SingleInstance();
        builder.RegisterType<MultiFormatWordReader>().As<IWordReader>();
    }
}
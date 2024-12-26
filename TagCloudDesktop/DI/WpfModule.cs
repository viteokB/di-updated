using System.Reflection;
using Autofac;
using TagCloudDesktop.Services;
using Module = Autofac.Module;

namespace TagCloudDesktop.DI;

public class WpfModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register services
        builder.RegisterType<FileWordReader>().AsSelf();
        builder.RegisterType<FilteredWordsCounter>().AsSelf();
        builder.RegisterType<ImageSaver>().AsSelf();
        // Register viewmodels
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("ViewModel"))
            .AsSelf()
            .InstancePerDependency();
    }
}
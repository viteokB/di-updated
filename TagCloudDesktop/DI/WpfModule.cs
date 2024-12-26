using Autofac;
using TagCloudDesktop.ViewModels;
using System.Reflection;
using System.Linq;
using WordReaders;
using Module = Autofac.Module;
using TagCloudDesktop.Services;

namespace TagCloudDesktop.DI
{
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
}
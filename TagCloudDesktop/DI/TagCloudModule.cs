using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BitmapSavers;
using TagCloud;
using TagCloud.Factory;
using TagCloud.Interfaces;
using TagCloud.RayMovers;
using TagCloud.Visualisers;
using WordHandlers;
using WordHandlers.Handlers;
using WordReaders.Factory;

namespace TagCloudDesktop.DI
{
    public class TagCloudModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
        }
    }
}

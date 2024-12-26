using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmapSavers;
using ConsoleClient.Interfaces;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using TagCloud.SpiralPointGenerators.enums;
using TagCloud.Visualisers;
using WordReaders.Settings;

namespace ConsoleClient.Services
{
    public class SettingsProvider : ISettingsProvider
    {
        private CommandLineOptions options;

        public SettingsProvider(CommandLineOptions options)
        {
            this.options = options;
        }

        public SettingsStorage GetSettingsStorage()
        {
            return new SettingsStorage(
                new ImageCreateSettings(
                    new Size(options.ImageWidth, options.ImageHeight),
                    Color.FromName(options.BackgroundColor),
                    new FontFamily(options.FontFamily),
                    options.MinFontSize,
                    options.MaxFontSize,
                    Color.FromName(options.WordColor),
                    DefineSpiralPointGeneratorsType(options.spiralGeneratorString)
                ),
                new ImageSaveSettings(options.PathToSaveImage),
                new WordReaderSettings(options.PathToWordFile, Encoding.UTF8)
            );
        }

        public SpiralPointGeneratorsType DefineSpiralPointGeneratorsType(string str) => str switch
        {
            "c" => SpiralPointGeneratorsType.Circular,
            "t" => SpiralPointGeneratorsType.Triangular,
            "s" => SpiralPointGeneratorsType.Square,
            _ => SpiralPointGeneratorsType.Circular
        };
    }
}

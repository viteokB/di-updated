﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloud.Interfaces;
using TagCloud.RayMovers;
using TagCloud.SpiralPointGenerators;
using TagCloud.SpiralPointGenerators.enums;
using TagCloud.Visualisers;

namespace TagCloud.Factory
{
    public class SpiralPointGeneratorFactory : ISpiralPointGeneratorFactory
    {
        public ISpiralPointGenerator CreateSpiralPointGenerator(SpiralPointGeneratorsType generatorType,
            ImageCreateSettings imageSettings) => generatorType switch
        {
            SpiralPointGeneratorsType.Circular => new CircularSpiralPointCreator(
                new Point(imageSettings.ImageSize.Width / 2, imageSettings.ImageSize.Height / 2)),
            SpiralPointGeneratorsType.Triangular => new TriangularSpiralPointCreator(
                new Point(imageSettings.ImageSize.Width / 2, imageSettings.ImageSize.Height / 2)),
            SpiralPointGeneratorsType.Square => new SquareSpiralPointCreator(
                new Point(imageSettings.ImageSize.Width / 2, imageSettings.ImageSize.Height / 2)),
            _ => throw new ArgumentException("Such SpiralPointGenerator don't exist")
        };
    }
}

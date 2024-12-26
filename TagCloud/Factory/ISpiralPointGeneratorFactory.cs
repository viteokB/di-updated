using System;
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
    public interface ISpiralPointGeneratorFactory
    {
        ISpiralPointGenerator CreateSpiralPointGenerator(ImageCreateSettings imageSettings);
    }
}

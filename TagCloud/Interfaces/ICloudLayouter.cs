using System.Drawing;

namespace TagCloud.Interfaces
{
    public interface ICloudLayouter
    {
        public Rectangle PutNextRectangle(Size rectangleSize);

        public List<Rectangle> Rectangles { get; }
    }
}

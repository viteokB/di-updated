using System.Drawing;

namespace TagCloud.Interfaces
{
    public interface IRayMover
    {
        IEnumerable<Point> MoveRay();
    }
}

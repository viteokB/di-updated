using System.Drawing;

namespace TagCloud.Visualisers;

public class TagCloudWord(Rectangle box, string textWord, int fontSize)
{
    public readonly Rectangle Box = box;

    public readonly int FontSize = fontSize;

    public readonly string TextWord = textWord;
}
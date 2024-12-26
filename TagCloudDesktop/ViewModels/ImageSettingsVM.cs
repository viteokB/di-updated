using System.Drawing;
using TagCloudDesktop.ViewModels.Base;

namespace TagCloudDesktop.ViewModels;

public class ImageSettingsVM : ViewModel
{
    private int _fontMaxSize = 40;
    private int _fontMinSize = 20;
    private int _imageHeight = 400;
    private int _imageWidth = 800;
    private Color _selectedBackgroundColor = Color.White;
    private FontFamily _selectedFontFamily = new("Arial");
    private Color _selectedWordColor = Color.Black;

    public int ImageWidth
    {
        get => _imageWidth;
        set
        {
            _imageWidth = value;
            OnPropertyChanged();
        }
    }

    public int ImageHeight
    {
        get => _imageHeight;
        set
        {
            _imageHeight = value;
            OnPropertyChanged();
        }
    }

    public Color SelectedBackgroundColor
    {
        get => _selectedBackgroundColor;
        set
        {
            _selectedBackgroundColor = value;
            OnPropertyChanged();
        }
    }

    public FontFamily SelectedFontFamily
    {
        get => _selectedFontFamily;
        set
        {
            _selectedFontFamily = value;
            OnPropertyChanged();
        }
    }

    public int FontMinSize
    {
        get => _fontMinSize;
        set
        {
            _fontMinSize = value;
            OnPropertyChanged();
        }
    }

    public int FontMaxSize
    {
        get => _fontMaxSize;
        set
        {
            _fontMaxSize = value;
            OnPropertyChanged();
        }
    }

    public Color SelectedWordColor
    {
        get => _selectedWordColor;
        set
        {
            _selectedWordColor = value;
            OnPropertyChanged();
        }
    }

    public List<Color> AvailableColors { get; } = new()
    {
        Color.White,
        Color.Black,
        Color.Red,
        Color.Green,
        Color.Blue
    };

    public List<FontFamily> AvailableFontFamilies { get; } = FontFamily.Families.ToList();
}
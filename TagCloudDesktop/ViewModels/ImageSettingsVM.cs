using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloudDesktop.ViewModels.Base;

namespace TagCloudDesktop.ViewModels
{
    public class ImageSettingsVM : ViewModel
    {
        private int _imageWidth = 800;
        public int ImageWidth
        {
            get => _imageWidth;
            set
            {
                _imageWidth = value;
                OnPropertyChanged();
            }
        }
        private int _imageHeight = 400;
        public int ImageHeight
        {
            get => _imageHeight;
            set
            {
                _imageHeight = value;
                OnPropertyChanged();
            }
        }
        private Color _selectedBackgroundColor = Color.White;
        public Color SelectedBackgroundColor
        {
            get => _selectedBackgroundColor;
            set
            {
                _selectedBackgroundColor = value;
                OnPropertyChanged();
            }
        }
        private FontFamily _selectedFontFamily = new("Arial");
        public FontFamily SelectedFontFamily
        {
            get => _selectedFontFamily;
            set
            {
                _selectedFontFamily = value;
                OnPropertyChanged();
            }
        }
        private int _fontMinSize = 20;
        public int FontMinSize
        {
            get => _fontMinSize;
            set
            {
                _fontMinSize = value;
                OnPropertyChanged();
            }
        }
        private int _fontMaxSize = 40;
        public int FontMaxSize
        {
            get => _fontMaxSize;
            set
            {
                _fontMaxSize = value;
                OnPropertyChanged();
            }
        }
        private Color _selectedWordColor = Color.Black;
        public Color SelectedWordColor
        {
            get => _selectedWordColor;
            set
            {
                _selectedWordColor = value;
                OnPropertyChanged();
            }
        }
        public List<Color> AvailableColors { get; } = new List<Color>()
       {
          Color.White,
           Color.Black,
          Color.Red,
          Color.Green,
            Color.Blue
        };
        public List<FontFamily> AvailableFontFamilies { get; } = FontFamily.Families.ToList();
    }
}

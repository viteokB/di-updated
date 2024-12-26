using System.Windows.Media.Imaging;
using TagCloud.SpiralPointGenerators.enums;
using TagCloudDesktop.ViewModels.Base;

namespace TagCloudDesktop.ViewModels;

public class MainVM : ViewModel
{
    private BitmapSource _myImage;
    //private readonly IFileService _fileService;
    //private readonly IImageService _imageService;
    //private readonly FilteredWordsCounter _filteredWordsCounter;
    //private readonly IWordHandler _wordCounterHandler;
    //private readonly FileWordReader _fileWordReader;
    //private readonly IWordReaderFactory _wordReaderFactory;
    //private readonly ISpiralPointsGeneratorFactory _spiralPointsGeneratorFactory;
    //private readonly RelayCommand _openCommand;
    //private readonly RelayCommand _saveImageCommand;
    //private readonly RelayCommand _thresholdFilterCommand;
    //private readonly RelayCommand _blackWhiteFilterCommand;
    //private readonly RelayCommand _inversionFilterCommand;
    //private readonly RelayCommand _wordCountCommand;
    //private readonly RelayCommand _cancelCommand;
    //private readonly RelayCommand _createSettingsCommand;

    private SpiralPointGeneratorsType _selectedSpiralType = SpiralPointGeneratorsType.Circular;

    public SpiralPointGeneratorsType SelectedSpiralType
    {
        get => _selectedSpiralType;
        set
        {
            _selectedSpiralType = value;
            OnPropertyChanged();
        }
    }

    public BitmapSource MyImage
    {
        get => _myImage;
        set
        {
            _myImage = value;
            OnPropertyChanged();
        }
    }
    //public ICommand OpenCommand => _openCommand;
    //public ICommand SaveImageCommand => _saveImageCommand;
    //public ICommand ThresholdFilter => _thresholdFilterCommand;
    //public ICommand BlackWhiteFilter => _blackWhiteFilterCommand;
    //public ICommand InversionFilter => _inversionFilterCommand;
    //public ICommand WordCount => _wordCountCommand;
    //public ICommand Cancel => _cancelCommand;
    //public ICommand CreateSettingsCommand => _createSettingsCommand;
}
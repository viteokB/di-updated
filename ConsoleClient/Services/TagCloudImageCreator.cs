using BitmapSavers;
using TagCloud;
using TagCloud.Visualisers;
using WordHandlers.Interfaces;
using WordReaders.Factory;
using WordReaders.Settings;

namespace ConsoleClient.Services;

public class TagCloudImageCreator(
    BitmapSaver bitmapSaver,
    ImageSaveSettings imageSaveSettings,
    ImageCreateSettings imageCreateSettings,
    IWordReaderFactory wordReaderFactory,
    WordReaderSettings wordReaderSettings,
    IWordCounter wordsCounter,
    TagCloudBitmapCreator tagCloudCreator)
{
    public void CreateCloudImage()
    {
        var wordsReader = wordReaderFactory.CreateWordReader(wordReaderSettings);
        var fileWords = wordsReader.Read();
        var dictCountWords = wordsCounter.CountWords(fileWords);

        var bitmap = tagCloudCreator.CreateTagCloudBitmap(dictCountWords, imageCreateSettings);
        bitmapSaver.Save(imageSaveSettings, bitmap);
    }
}
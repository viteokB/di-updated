using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmapSavers;
using TagCloud;
using TagCloud.Visualisers;
using WordReaders.Factory;
using WordReaders.Settings;

namespace ConsoleClient.Services
{
    public class TagCloudImageCreator
    {
        private readonly BitmapSaver bitmapSaver;

        private readonly ImageSaveSettings imageSaveSettings;

        private readonly ImageCreateSettings imageCreateSettings;

        private readonly IWordReaderFactory wordReaderFactory;

        private readonly WordReaderSettings readerSettings;

        private readonly FilteredWordsCounter wordsCounter;

        private readonly TagCloudCreator tagCloudCreator;

        public TagCloudImageCreator(
            BitmapSaver bitmapSaver,
            ImageSaveSettings imageSaveSettings,
            ImageCreateSettings imageCreateSettings,
            IWordReaderFactory wordReaderFactory,
            WordReaderSettings wordReaderSettings,
            FilteredWordsCounter wordsCounter,
            TagCloudCreator tagCloudCreator)
        {
            this.bitmapSaver = bitmapSaver;
            this.imageSaveSettings = imageSaveSettings;
            this.imageCreateSettings = imageCreateSettings;
            this.wordReaderFactory = wordReaderFactory;
            this.readerSettings = wordReaderSettings;
            this.wordsCounter = wordsCounter;
            this.tagCloudCreator = tagCloudCreator;
        }

        public void CreateCloudImage()
        {
            var wordsReader = wordReaderFactory.CreateWordReader(readerSettings);
            var fileWords = wordsReader.Read();
            var dictCountWords = wordsCounter.CountWords(fileWords);

            var bitmap = tagCloudCreator.CreateTagCloudBitmap(dictCountWords, imageCreateSettings);
            bitmapSaver.Save(imageSaveSettings, bitmap);
        }
    }
}

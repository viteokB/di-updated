using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmapSavers;
using TagCloud.Visualisers;
using WordReaders.Settings;

namespace ConsoleClient.Services
{
    public record SettingsStorage(
        ImageCreateSettings ImageCreate,
        ImageSaveSettings ImageSave,
        WordReaderSettings ReaderSettings);
}

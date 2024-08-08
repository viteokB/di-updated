using di.Infrastructure.Common;
using FractalPainting.App;
using FractalPainting.Infrastructure.Common;

namespace di.Application
{
    public class SettingsManager
    {
        private readonly IObjectSerializer serializer;
        private readonly IBlobStorage storage;
        private string settingsFilename;

        public SettingsManager(IObjectSerializer serializer, IBlobStorage storage)
        {
            this.serializer = serializer;
            this.storage = storage;
            settingsFilename = "app.settings";
        }

        public AppSettings Load()
        {
            try
            {
                var data = storage.Get(settingsFilename);
                if (data == null)
                {
                    var defaultSettings = CreateDefaultSettings();
                    Save(defaultSettings);
                    return defaultSettings;
                }
                return serializer.Deserialize<AppSettings>(data);
            }
            catch (Exception e)
            {
                return CreateDefaultSettings();
            }
        }

        private static AppSettings CreateDefaultSettings()
        {
            return new AppSettings
            {
                ImagesDirectory = ".",
                ImageSettings = new ImageSettings()
            };
        }

        public void Save(AppSettings settings)
        {
            storage.Set(settingsFilename, serializer.Serialize(settings));
        }
    }
}
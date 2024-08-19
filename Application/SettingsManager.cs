using di.Infrastructure.Common;
using FractalPainting.Infrastructure.Common;

namespace FractalPainting.Application;

public class SettingsManager(IObjectSerializer serializer, IBlobStorage storage)
{
    private readonly string settingsFilename = "app.settings";

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
        catch (Exception)
        {
            return CreateDefaultSettings();
        }
    }

    private static AppSettings CreateDefaultSettings()
    {
        return new AppSettings
        {
            ImageSettings = new ImageSettings()
        };
    }

    private void Save(AppSettings settings)
    {
        storage.Set(settingsFilename, serializer.Serialize(settings));
    }
}
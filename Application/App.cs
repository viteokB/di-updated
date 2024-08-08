using System.Net;
using di.Application.Actions;
using di.Infrastructure.Common;
using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using Microsoft.Extensions.DependencyInjection;

namespace di.Application;

internal sealed class App
{
    private readonly HttpListener httpListener;
    private readonly IReadOnlyDictionary<string, IApiAction> routeActions;

    public App() : this(
        new IApiAction[]
        {
            new SaveImageAction(),
            new DragonFractalAction(),
            new KochFractalAction(),
            new UpdateImageSettingsAction(),
            new GetImageSettingsAction(),
            new UpdatePaletteSettingsAction(),
            new GetPaletteSettingsAction()
        })
    {
    }

    public App(IEnumerable<IApiAction> actions)
    {
        var actionsArray = actions.ToArray();
        httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://localhost:8080/");
        routeActions = actionsArray.ToDictionary(action => $"{action.HttpMethod} {action.Endpoint}", action => action);
        DependencyInjector.Inject<IImageDirectoryProvider>(actionsArray, CreateSettingsManager().Load());
        DependencyInjector.Inject<IImageSettingsProvider>(actionsArray, CreateSettingsManager().Load());
        DependencyInjector.Inject(actionsArray, new Palette());
    }

    public async Task Run()
    {
        httpListener.Start();
        while (true)
        {
            try
            {
                var context = await httpListener.GetContextAsync();
                var actionKey = $"{context.Request.HttpMethod} {context.Request.Url!.AbsolutePath}";
                if (!routeActions.TryGetValue(actionKey, out var action))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.Close();
                    continue;
                }

                action.Perform(context.Request.InputStream, context.Response.OutputStream);
                context.Response.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }

    private static SettingsManager CreateSettingsManager()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IObjectSerializer, XmlObjectSerializer>();
        services.AddSingleton<IBlobStorage, FileBlobStorage>();
        services.AddSingleton<SettingsManager>();

        var sp = services.BuildServiceProvider();
        var settingsManager = sp.GetRequiredService<SettingsManager>();

        return settingsManager;
    }
}
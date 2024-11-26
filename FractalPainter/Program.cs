using FractalPainting.Application;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// services.AddSingleton<IApiAction, KochFractalAction>();
// ...
// var serviceProvider = services.BuildServiceProvider();
// var app = serviceProvider.GetService<App>();

await new App().Run();
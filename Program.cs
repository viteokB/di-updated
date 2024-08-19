using FractalPainting.Application;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// DI Container

await new App().Run();
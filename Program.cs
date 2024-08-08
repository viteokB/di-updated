using di.Application;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

await new App().Run();
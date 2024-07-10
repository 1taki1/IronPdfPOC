using Microsoft.Extensions.Hosting;
using AutoPayStatement.Functions;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((hostBuilderContext, services) => {

        services.RegisterAzureApplicationInsights();
        services.RegisterServices();

    })
    .Build();

host.Run();

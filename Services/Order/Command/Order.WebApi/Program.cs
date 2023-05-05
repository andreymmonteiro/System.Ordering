using Order.WebApi.Configuration;
using Order.Infraestructure;
using Order.Infraestructure.Data;
using Serilog;
using Order.Domain.Data;

const string V1 = "v1";
const string APPLICATION = "Order.WebApi";
const string JSON_PATH = "/swagger/v1/swagger.json";

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureLogging((context, logging) =>
{
    Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(context.Configuration)
                    .CreateLogger();

    logging.ClearProviders();
    logging.AddSerilog();
});

builder.ConfigureServices((context, services) =>
{
    // Add services to the container.
    IConfig config = context.Configuration.GetSection("AppSettings:Config").Get<Config>();
    services
        .AddInfraestructureDependencies(config);
});

using var host = builder.Build();

try
{
    await host.RunAsync();
}
catch (Exception ex)
{
    await host.StopAsync();
}
finally
{
    Log.CloseAndFlush();
}


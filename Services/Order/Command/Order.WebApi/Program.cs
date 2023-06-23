using FluentMigrator.Runner;
using Order.Domain.Data;
using Order.Infraestructure;
using Order.Infraestructure.Data;
using Serilog;
using System.Reflection;

const string V1 = "v1";
const string APPLICATION = "Order.WebApi";
const string JSON_PATH = "/swagger/v1/swagger.json";
const string INFRAESTRUCTURE = "Order.Infraestructure";

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .CreateLogger();

//webApplication.Services.ConfigureLogging((context, logging) =>
//{


//    logging.ClearProviders();
//    logging.AddSerilog();
//});

//webApplication.Services.AddSerilog();

IConfig config = builder.Configuration.GetSection("AppSettings:Config").Get<Config>();

await ((Config)config).CreateDatabase();
builder.Services.AddInfraestructureDependencies(config);

builder.Services.AddControllers();

builder.Services.AddFluentMigratorCore().ConfigureRunner(configure =>
{
    configure
        .AddPostgres()
        .WithGlobalConnectionString(config.ConnectionString)
        .ScanIn(Assembly.Load(INFRAESTRUCTURE)).For.Migrations();

}).AddLogging(lb => lb.AddFluentMigratorConsole());


using var app = builder.Build();

using var scope = app.Services.CreateScope();

var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

migrator.MigrateUp();

app.UseHttpsRedirection();

try
{
    await app.RunAsync();
}
catch
{
    await app.StopAsync();
}
finally
{
    Log.CloseAndFlush();
}


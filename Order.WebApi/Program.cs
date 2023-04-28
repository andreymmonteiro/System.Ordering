using Order.WebApi.Configuration;
using Order.Infraestructure;
using Order.Infraestructure.Data;

const string V1 = "v1";
const string APPLICATION = "Order.WebApi";
const string JSON_PATH = "/swagger/v1/swagger.json";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .AddSwagger()
    .AddInfraestructureDependencies(new Config())
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddCors(o => 
    o.AddDefaultPolicy(p => 
    {
        p.AllowAnyOrigin();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint(JSON_PATH, $"{APPLICATION} {V1}");
});

app.Run();
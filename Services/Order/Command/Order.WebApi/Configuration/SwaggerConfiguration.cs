using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Order.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {

        const string V1 = "v1";
        const string APPLICATION = "Order.WebApi";
        const string JSON_PATH = "/swagger/v1/swagger.json";
        const string XML_EXTENSIONS = ".xml";
        const string SECTION = "Default";
        const string BEARER = "Bearer";
        const string SET_TOKEN = "Set your Token";
        const string AUTHORIZATION = "Authorization";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(V1, new OpenApiInfo { Title = APPLICATION, Version = V1 });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSIONS;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}

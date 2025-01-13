using Asp.Versioning;
using COMB.SpaParking.API.Middlewares;
using COMB.SpaParking.Base;
using COMB.SpaParking.Persistence;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    RunWebapi();
}
catch (Exception ex)
{
    logger.Error(ex, "An unhandled exception occurred.");
}
finally
{
    NLog.LogManager.Shutdown();
}

void RunWebapi()
{
    var builder = WebApplication.CreateBuilder(args);

    const string API_VERSION = "v1";

    builder.Services.AddDbContext<DatabaseContext>();

    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new HeaderApiVersionReader("api-version");
    });

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc(API_VERSION, new OpenApiInfo
        {
            Version = API_VERSION,
            Title = "Parking - CityOfMiamiBeach API",
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    AddControllersWithNewtonsoftJson(builder.Services);

    builder.RunTypesRegistration();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", API_VERSION);
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.MapControllers();

    app.Run();
}


[RequiresUnreferencedCode("MVC does not currently support trimming or native AOT.")]
void AddControllersWithNewtonsoftJson(IServiceCollection services)
{
    services.AddControllers()
        .AddNewtonsoftJson(setup => {

            setup.UseCamelCasing(true);
            setup.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            setup.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        });
}

public static class TypesRegistry
{
    public static void RunTypesRegistration(this WebApplicationBuilder builder)
    {
        var serviceColletion = builder.Services;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies.Where(a => a.FullName is not null && a.FullName.StartsWith("COMB.SpaParking")))
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.GetInterfaces().Contains(typeof(ITypeRegistration)))
                {
                    var instance = Activator.CreateInstance(type) as ITypeRegistration;
                    if (instance is not null)
                        instance.RegisterTypes(serviceColletion);
                }
            }
        }
    }
}
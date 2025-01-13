using COMB.SpaParking.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System.Net;

namespace COMB.SpaParking.UI.Server;

static class Logging
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
        }
        else
        {
            //builder.Logging.AddApplicationInsights(configureTelemetryConfiguration: opts =>
            //{
            //    opts.ConnectionString = builder.Configuration["ApplicationInsights:Instrumentationkey"] ?? throw new ArgumentNullException("ApplicationInsights:Instrumentationkey cannot be null");
            //}, configureApplicationInsightsLoggerOptions: opts => 
            //{ 
            //});
            //builder.Services.AddApplicationInsightsTelemetry();
        }
    }
}

static class DatabaseContext 
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Persistence.DatabaseContext>();
    }
}

static class Authentication
{
    public static void ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(opts =>
        {
            opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(opts => 
        { 
            opts.Cookie.Name = "_authcomb";
            opts.Cookie.SameSite = SameSiteMode.Strict;  

            opts.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Task.CompletedTask;
            };
        });
    }
}

public static class TypesRegistry
{
    public static void RunTypesRegistration(this WebApplicationBuilder builder)
    {
        var serviceColletion = builder.Services;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies.Where(a => a.FullName is not null && a.FullName.StartsWith("COMB")))
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
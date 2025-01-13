using COMB.SpaParking.UI.Server;
using Microsoft.AspNetCore.Identity;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    RunWebApp();
}
catch (Exception e)
{
    logger.Error(e, "An unhandled exception occurred.");
}
finally
{
    LogManager.Shutdown();
}

void RunWebApp()
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<COMB.SpaParking.Persistence.DatabaseContext>();

    builder.ConfigureLogging();
    builder.ConfigureDatabase();
    builder.ConfigureAuthentication();

    builder.Services.AddHttpClient(); // Add HttpClient for proxying
    builder.Services.AddControllers();
    builder.Services.AddRazorPages();

    builder.RunTypesRegistration();

    //reverse proxy for API
    builder.Services.AddReverseProxy()
        .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

    var app = builder.Build();

    app.UseDefaultFiles();
    app.MapStaticAssets();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseRouting();

    app.MapControllers();
    app.MapRazorPages();

    app.MapReverseProxy();

    app.MapFallbackToFile("/index.html");
    app.Run();
}
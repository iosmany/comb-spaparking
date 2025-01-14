using COMB.SpaParking.UI.Server;
using COMB.SpaParking.UI.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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

    COMB.SpaParking.Persistence.Configuration.Load(builder.Configuration);

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<COMB.SpaParking.Persistence.DatabaseContext>()
        .AddDefaultTokenProviders();

    builder.ConfigureLogging();
    builder.ConfigureDatabase();
    builder.ConfigureAuthentication();

    builder.Services.AddHttpClient(); // Add HttpClient for proxying
    builder.Services.AddRazorPages();

    builder.Services.AddTransient<IEmailSender, EmailSender>();

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

    app.MapGet("/Identity/Account", (HttpContext context, SignInManager<IdentityUser> SignInManager) =>
    {
        bool signedIn = SignInManager.IsSignedIn(context.User);
        if (!signedIn)
            return Results.Unauthorized();
        return Results.Ok();

    }).RequireAuthorization();

    app.MapRazorPages()
        .WithStaticAssets();

    app.MapReverseProxy();

    app.MapFallbackToFile("/index.html");
    app.Run();
}
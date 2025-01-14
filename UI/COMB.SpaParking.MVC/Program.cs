using COMB.SpaParking.MVC.Infrastructure;
using COMB.SpaParking.Persistence;
using Microsoft.AspNetCore.Identity;
using NLog;
using NLog.Web;
using static System.Net.Mime.MediaTypeNames;

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

    // Add services to the container.
    builder.Services.AddDbContext<DatabaseContext>();
    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<DatabaseContext>();

    builder.Services.AddHttpClient("SpaParkingAPI", httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["SpaCOMBApi:Url"] ?? throw new ArgumentNullException());
    });

    builder.Services.AddSingleton<ICOMBParkingApi, COMBParkingApi>();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseStatusCodePagesWithRedirects("/Error/{0}");

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();

    app.Run();
}


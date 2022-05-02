using Microsoft.EntityFrameworkCore;
using Satistools.GameData;
using Satistools.GameData.Extensions;

namespace Satistools.Web;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddGameDataModel(_configuration);
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(cfg =>
        {
            cfg.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            cfg.MapFallbackToFile("index.html");
        });
    }
}
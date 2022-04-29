using Satistools.GameData;
using Satistools.Web;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>();
    })
    .Build();

IServiceProvider provider = host.Services;
IWebHostEnvironment env = provider.GetRequiredService<IWebHostEnvironment>();

if (env.IsDevelopment())
{
    using IServiceScope scope = provider.CreateScope();
    ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    
    logger.LogInformation("Development environment detected, dev database will be used");
    GameDataContext context = scope.ServiceProvider.GetRequiredService<GameDataContext>();
    
    logger.LogInformation("Deleting current development database");
    context.Database.EnsureDeleted();
    
    logger.LogInformation("Creating a new development database");
    context.Database.EnsureCreated();
}

host.Run();
using Satistools.Web;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); }).Build().Run();

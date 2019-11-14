using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplicationAPI.Data;

namespace WebApplicationAPI
{
  public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateWebHostBuilder(args).Build();
            // using(var scope = host.Services.CreateScope())  // dispose context after using it
            // {
            //     var services = scope.ServiceProvider;
            //     try
            //     {
            //         var context=services.GetRequiredService<DataContext>();
            //         context.Database.Migrate();
            //         Seed.SeedUsers(context);
            //     }catch(Exception ex){
            //         var logger=services.GetRequiredService<ILogger<Program>>();
            //         logger.LogError(ex,"An error during migration");
            //     } 
            // }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

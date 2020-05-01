using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using SafeTurn.Persistence.DataAccess;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;

namespace PriceManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddFilter<EntityFrameworkLoggerProvider<ApplicationDbContext>>("Microsoft", LogLevel.None);
                    logging.AddFilter<EntityFrameworkLoggerProvider<ApplicationDbContext>>("System", LogLevel.None);
                    logging.AddEntityFramework<ApplicationDbContext>();

                })
                .CaptureStartupErrors(true) // the default
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>();
    }
}

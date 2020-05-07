using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
                .CaptureStartupErrors(true) // the default
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>();
    }
}

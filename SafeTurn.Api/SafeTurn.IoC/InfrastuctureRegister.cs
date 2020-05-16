using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Interfaces.Infrastucture;
using SafeTurn.Infrastucure.Mailer;

namespace PriceManager.IoC
{
    public static class InfrastuctureRegister
    {
        public static void RegisterInfrastucture(IServiceCollection services, IConfiguration configuration)
        {
            var asd = configuration["Smtp:Username"];
            asd = configuration["Smtp:Password"];
            asd = configuration["Smtp:Host"];
            asd = configuration["Smtp:Port"];
            services.AddFluentEmail(configuration["Smtp:From"])
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient()
                {
                    Credentials = new NetworkCredential(configuration["Smtp:Username"], configuration["Smtp:Password"]),
                    Host = configuration["Smtp:Host"],
                    Port = int.Parse(configuration["Smtp:Port"])
                });
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}

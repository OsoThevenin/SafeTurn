using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Interfaces.Infrastucture;
using SafeTurn.Infrastucure.Mailer;

namespace PriceManager.IoC
{
    public static class InfrastuctureRegister
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Shops;
using SafeTurn.Application.Turns;

namespace PriceManager.IoC
{
    public static class ApplicationRegister
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<ICreateTurn, CreateTurn>();
            services.AddScoped<ICreateShop, CreateShop>();
            services.AddScoped<IGetDisponibilityShop, GetDisponibilityShop>();
        }
    }
}

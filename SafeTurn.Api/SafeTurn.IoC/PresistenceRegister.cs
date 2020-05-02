using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.DataAccess.Identity;
using SafeTurn.Persistence.Shared;
using SafeTurn.Persistence.Shops;
using SafeTurn.Persistence.Turns;

namespace PriceManager.IoC
{
    public static class PresistenceRegister
    {
        public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
                options
                    .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                    .UseInternalServiceProvider(sp));
        }

        public static void RegisterRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ITurnRepository, TurnRepository>();

        }

        public static void RegisterIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        }
    }
}

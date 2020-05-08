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
    public static class PersistenceRegister
    {
        public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddEntityFrameworkSqlServer();
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }

        public static void RegisterIdentity(IServiceCollection services)
        {
            services.AddIdentityCore<User>()
               .AddEntityFrameworkStores<ApplicationDbContext>();        }

        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ITurnRepository, TurnRepository>();
        }

        public static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<IShopQueries, ShopQueries>();
        }
    }
}

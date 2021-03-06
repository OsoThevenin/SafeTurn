﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.Identity;
using SafeTurn.Persistence.Shared;
using SafeTurn.Persistence.Shops;
using SafeTurn.Persistence.Turns;
using SafeTurn.Persistence.Users;

namespace PriceManager.IoC
{
    public static class PersistenceRegister
    {
        public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(c => 
                c.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }

        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ITurnRepository, TurnRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<IShopQueries, ShopQueries>();
        }
    }
}

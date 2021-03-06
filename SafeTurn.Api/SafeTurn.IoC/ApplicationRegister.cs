﻿using Microsoft.Extensions.DependencyInjection;
using SafeTurn.Application.Auth.AuthenticateCommand;
using SafeTurn.Application.Auth.RegisterCommand;
using SafeTurn.Application.Shops.CreateShopCommand;
using SafeTurn.Application.Shops.DeleteShopCommand;
using SafeTurn.Application.Shops.GetDisponibilityShopCommand;
using SafeTurn.Application.Shops.GetShopQuery;
using SafeTurn.Application.Shops.PublishShopCommand;
using SafeTurn.Application.Shops.UpdateShopCommand;
using SafeTurn.Application.Turns.ConfirmTurnCommand;
using SafeTurn.Application.Turns.CreateTurnCommand;
using SafeTurn.Application.Turns.DeleteTurnCommand;
using SafeTurn.Application.Turns.RejectTurnCommand;
using SafeTurn.Application.Utils;

namespace PriceManager.IoC
{
    public static class ApplicationRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Auth
            services.AddScoped<IAuthenticate, Authenticate>();
            services.AddScoped<IRegister, Register>();

            // Turns
            services.AddScoped<ICreateTurn, CreateTurn>();
            services.AddScoped<IDeleteTurn, DeleteTurn>();
            services.AddScoped<IConfirmTurn, ConfirmTurn>();
            services.AddScoped<IRejectTurn, RejectTurn>();

            //Shops
            services.AddScoped<IGetShop, GetShop>();
            services.AddScoped<ICreateShop, CreateShop>();
            services.AddScoped<IGetDisponibilityShop, GetDisponibilityShop>();
            services.AddScoped<IDeleteShop, DeleteShop>();
            services.AddScoped<IPublishShop, PublishShop>();
            services.AddScoped<IUpdateShop, UpdateShop>();

            //Utils
            services.AddScoped<IUtilDateTime, UtilDateTime>();
        }
    }
}

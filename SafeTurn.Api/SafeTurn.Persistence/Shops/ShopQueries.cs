using Microsoft.Extensions.Configuration;
using Dapper;
using System.Linq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Application.Shops.GetShopQuery;
using System;
using SafeTurn.Persistence.Shared;

namespace SafeTurn.Persistence.Shops
{
    public class ShopQueries : QueryConnection, IShopQueries
    {
        public ShopQueries(IConfiguration configuration) : base(configuration) { }

        public GetShopModel GetShop(Guid id)
        {
            string url = @"
                SELECT TOP 1 [Code], [Name], SimultaneousTurns, MinutesForTurn
                FROM Shops WHERE Id = @id";
                
            return Connection.Query<GetShopModel>(
                url,
                param: new { id }
            ).First();
        }
    }
}

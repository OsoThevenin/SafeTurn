using Microsoft.EntityFrameworkCore;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.Shared;
using System;
using System.Linq;


namespace SafeTurn.Persistence.Shops
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext database) : base(database) { }

        public Shop GetByCode(string code)
        {
            return _database.Shops.SingleOrDefault(s => s.Code.ToUpper() == code.ToUpper());
        }

        public Shop GetByIdWithTorns(Guid id)
        {
            return _database.Shops.AsQueryable()
                .Include(s => s.Turns)
                .SingleOrDefault(s => s.Id == id);
        }
    }
}

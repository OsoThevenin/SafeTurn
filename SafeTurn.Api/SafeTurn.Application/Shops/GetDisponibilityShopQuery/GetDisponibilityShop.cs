using SafeTurn.Application.Common;
using SafeTurn.Application.Interfaces.Persistence;
using System.Collections.Generic;

namespace SafeTurn.Application.Shops.GetDisponibilityShopQuery
{
    public class GetDisponibilityShop : IGetDisponibilityShop
    {
        private readonly IShopRepository _shopRepo;

        public GetDisponibilityShop
        (
            IShopRepository shopRepo
        )
        {
            _shopRepo = shopRepo;
        }

        public DisponibilityShopResponse Execute(string code)
        {
            var shop = _shopRepo.GetByCode(code);

            if (shop == null) return null;
            return new DisponibilityShopResponse()
            {
                ShopId = shop.Id,
                ShopName = shop.Name,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop()
                    {
                        Range = HoursDisponibilityRange.Min15
                    },
                    new HourDisponibilityShop()
                    {
                        Range = HoursDisponibilityRange.Now
                    },
                    new HourDisponibilityShop()
                    {
                        Range = HoursDisponibilityRange.Hour2,
                        Offer = "Tofu gratis"
                    },
                    new HourDisponibilityShop()
                    {
                        Range = HoursDisponibilityRange.Hour4
                    },
                }
            };
        }
    }
}

using SafeTurn.Application.Common;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Application.Utils;
using System.Collections.Generic;

namespace SafeTurn.Application.Shops.GetDisponibilityShopCommand
{
    public class GetDisponibilityShop : IGetDisponibilityShop
    {
        private readonly IShopRepository _shopRepo;
        private readonly IUtilDateTime _utilDateTime;

        public GetDisponibilityShop
        (
            IShopRepository shopRepo,
            IUtilDateTime utilDateTime
        )
        {
            _shopRepo = shopRepo;
            _utilDateTime = utilDateTime;
        }

        public GetDisponibilityShopResponse Execute(GetDisponibilityShopModel model)
        {
            var shop = _shopRepo.GetByCodeWithTurns(model.Code);
            if (shop == null) return null;
            var now = _utilDateTime.GetNow();
            var availableNow = shop.IsAvailable(now, 2);
            var available15Min = shop.IsAvailable(now.AddMinutes(15), 5);
            var available30Min = shop.IsAvailable(now.AddMinutes(30), 10);
            var available1Hour = shop.IsAvailable(now.AddHours(1), 20);
            var available2Hour = shop.IsAvailable(now.AddHours(2), 30);
            var available4Hour = shop.IsAvailable(now.AddHours(4), 60);

            var hoursDisponibilities = new List<HourDisponibilityShop>();
            if (availableNow) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Now });
            if (available15Min) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Min15 });
            if (available30Min) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Min30 });
            if (available1Hour) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour1 });
            if (available2Hour) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour2 });
            if (available4Hour) hoursDisponibilities.Add(new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour4 });
            return new GetDisponibilityShopResponse()
            {
                ShopId = shop.Id,
                ShopName = shop.Name,
                Hours = hoursDisponibilities
            };
        }
    }
}

using SafeTurn.Application.Common;
using System;
using System.Collections.Generic;

namespace SafeTurn.Application.Shops.GetDisponibilityShopCommand
{
    public class GetDisponibilityShopResponse
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public List<HourDisponibilityShop> Hours { get; set; }
    }

    public class HourDisponibilityShop
    {
        public HoursDisponibilityRange Range { get; set; }
        public string Offer { get; set; }
    }
}

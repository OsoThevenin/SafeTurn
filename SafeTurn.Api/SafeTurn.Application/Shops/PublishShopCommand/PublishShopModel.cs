using System;

namespace SafeTurn.Application.Shops.PublishShopCommand
{
    public class PublishShopModel
    {
        public Guid ShopId { get; set; }
        public bool Publish { get; set; }   // true --> publish  -/- false --> unpublish
    }
}

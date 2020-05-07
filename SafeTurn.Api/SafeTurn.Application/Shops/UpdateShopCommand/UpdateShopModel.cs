using System;

namespace SafeTurn.Application.Shops.UpdateShopCommand
{
    public class UpdateShopModel
    {
        public Guid ShopId { get; set; }
        public string Name { get; set; }
        public int SimultaneousTurns { get; set; }
        public int MinutesForTurn { get; set; }
    }
}

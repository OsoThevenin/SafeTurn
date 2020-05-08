namespace SafeTurn.Application.Shops.GetShopQuery
{
    public class GetShopModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SimultaneousTurns { get; set; }
        public int MinutesForTurn { get; set; }
    }
}

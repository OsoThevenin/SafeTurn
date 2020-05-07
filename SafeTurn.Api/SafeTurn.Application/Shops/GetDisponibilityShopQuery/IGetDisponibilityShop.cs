namespace SafeTurn.Application.Shops.GetDisponibilityShopQuery
{
    public interface IGetDisponibilityShop
    {
        DisponibilityShopResponse Execute(string code);
    }
}

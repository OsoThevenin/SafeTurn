namespace SafeTurn.Application.Shops
{
    public interface IGetDisponibilityShop
    {
        DisponibilityShopResponse Execute(string code);
    }
}

namespace SafeTurn.Application.Shops.GetDisponibilityShopCommand
{
    public interface IGetDisponibilityShop
    {
        DisponibilityShopResponse Execute(string code);
    }
}

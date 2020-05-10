namespace SafeTurn.Application.Shops.GetDisponibilityShopCommand
{
    public interface IGetDisponibilityShop
    {
        GetDisponibilityShopResponse Execute(GetDisponibilityShopModel model);
    }
}

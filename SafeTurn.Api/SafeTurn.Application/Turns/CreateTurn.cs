using SafeTurn.Application.Interfaces.Persistence;
using System;

namespace SafeTurn.Application.Turns
{
    public class CreateTurn : ICreateTurn
    {
        private readonly IShopRepository _shopRepo;
        private readonly ITurnRepository _turnRepo;
        private readonly IUnitOfWork _uow;

        public CreateTurn
        (
            IShopRepository shopRepo,
            ITurnRepository turnRepo,
            IUnitOfWork uow
        ) {
            _shopRepo = shopRepo;
            _turnRepo = turnRepo;
            _uow = uow;
        }

        public void Execute(CreateTurnModel model)
        {
            var shop = _shopRepo.GetByIdWithTorns(model.ShopId);
            DateTime dateRangeStart, dateRangeEnd, now = DateTime.Now;
            switch (model.Range)
            {
                case Common.HoursDisponibilityRange.Now:
                    dateRangeStart = now;
                    dateRangeEnd = now.AddMinutes(5);
                    break;
                case Common.HoursDisponibilityRange.Min15:
                    dateRangeStart = now.AddMinutes(10);
                    dateRangeEnd = now.AddMinutes(20);
                    break;
                case Common.HoursDisponibilityRange.Min30:
                    dateRangeStart = now.AddMinutes(25);
                    dateRangeEnd = now.AddMinutes(40);
                    break;
                case Common.HoursDisponibilityRange.Hour1:
                    dateRangeStart = now.AddMinutes(50);
                    dateRangeEnd = now.AddMinutes(80);
                    break;
                case Common.HoursDisponibilityRange.Hour2:
                    dateRangeStart = now.AddMinutes(100);
                    dateRangeEnd = now.AddMinutes(150);
                    break;
                case Common.HoursDisponibilityRange.Hour4:
                    dateRangeStart = now.AddMinutes(190);
                    dateRangeEnd = now.AddMinutes(290);
                    break;
                default:
                    dateRangeStart = dateRangeEnd = now;
                    break;
            }
            shop.SetNewTurn(dateRangeStart, dateRangeEnd, model.ClientName);

        }
    }
}

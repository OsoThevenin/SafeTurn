using SafeTurn.Application.Common;
using System;

namespace SafeTurn.Application.Turns.CreateTurnCommand
{
    public class CreateTurnModel
    {
        public Guid ShopId { get; set; }
        public string ClientName { get; set; }
        public HoursDisponibilityRange Range { get; set; }
    }
}

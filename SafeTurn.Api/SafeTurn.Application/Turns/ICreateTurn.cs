using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTurn.Application.Turns
{
    public interface ICreateTurn
    {
        void Execute(CreateTurnModel model);
    }
}

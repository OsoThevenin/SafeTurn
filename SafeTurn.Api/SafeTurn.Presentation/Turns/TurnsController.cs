using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Turns.ConfirmTurnCommand;
using SafeTurn.Application.Turns.CreateTurnCommand;
using SafeTurn.Application.Turns.DeleteTurnCommand;
using SafeTurn.Application.Turns.RejectTurnCommand;
using System;
using System.Collections.Generic;

namespace SafeTurn.Api.Turns
{
    [Route("[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ICreateTurn _createTurn;
        private readonly IConfirmTurn _confirmTurn;
        private readonly IDeleteTurn _deleteTurn;
        private readonly IRejectTurn _rejectTurn;

        public TurnsController(
            ICreateTurn createTurn,
            IConfirmTurn confirmTurn,
            IDeleteTurn deleteTurn,
            IRejectTurn rejectTurn
        ) {
            _createTurn = createTurn;
            _confirmTurn = confirmTurn;
            _deleteTurn = deleteTurn;
            _rejectTurn = rejectTurn;
        }

        [HttpPost]
        public ActionResult<List<string>> Post(CreateTurnModel model)
        {
            try
            {
                _createTurn.Execute(model);
                return Ok();

            }
            catch (Exception e)
            {
                if (e.Message == "No disponible") return Conflict();
                throw;
            }
        }

        [HttpPut]
        [Route("confirm")]
        public ActionResult<List<string>> Confirm(ConfirmTurnModel model)
        {
            _confirmTurn.Execute(model);
            return Ok();
        }

        [HttpPut]
        [Route("reject")]
        public ActionResult<List<string>> Reject(RejectTurnModel model)
        {
            _rejectTurn.Execute(model);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<List<string>> Delete(DeleteTurnModel model)
        {
            _deleteTurn.Execute(model);
            return Ok();
        }
    }
}

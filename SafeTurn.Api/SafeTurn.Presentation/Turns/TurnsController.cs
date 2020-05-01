using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Turns;
using System;
using System.Collections.Generic;

namespace SafeTurn.Api.Turns
{
    [Route("[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ICreateTurn _createTurn;

        public TurnsController(
            ICreateTurn createTurn
        ) {
            _createTurn = createTurn;
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
    }
}

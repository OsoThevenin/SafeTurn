using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Turns;
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

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            _createTurn.Execute(new CreateTurnModel() { ClientName = "asd" });
            return Ok("hola");
        }
    }
}

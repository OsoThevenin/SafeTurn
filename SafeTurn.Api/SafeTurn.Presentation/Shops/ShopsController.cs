using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Shops;
using System.Collections.Generic;

namespace SafeTurn.Api.Turns
{
    [Route("[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IGetDisponibilityShop _getDisponibilityShop;
        private readonly ICreateShop _createShop;

        public ShopsController(
            IGetDisponibilityShop getDisponibilityShop,
            ICreateShop createShop
        )
        {
            _getDisponibilityShop = getDisponibilityShop;
            _createShop = createShop;
        }

        [HttpGet]
        public ActionResult<List<string>> Get(string code)
        {
            var shops = _getDisponibilityShop.Execute(code);
            if (shops == null) return NoContent();
            return Ok(shops);
        }

        [HttpPost]
        public ActionResult<List<string>> Post(CreateShopModel model)
        {
            _createShop.Execute(model);
            return Ok();
        }

        [HttpPost]
        public ActionResult<List<string>> Post()
        {
            return Ok();
        }
    }
}

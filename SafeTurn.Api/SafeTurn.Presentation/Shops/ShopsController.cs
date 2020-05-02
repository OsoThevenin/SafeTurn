using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Shops;
using System;
using System.Collections.Generic;

namespace SafeTurn.Api.Turns
{
    [Route("[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IGetDisponibilityShop _getDisponibilityShop;
        private readonly IGetShop _getShop;
        private readonly ICreateShop _createShop;

        public ShopsController(
            IGetDisponibilityShop getDisponibilityShop,
            IGetShop getShop,
            ICreateShop createShop
        )
        {
            _getDisponibilityShop = getDisponibilityShop;
            _getShop = getShop;
            _createShop = createShop;
        }

        [HttpGet]
        public ActionResult<List<string>> GetByCode(string code)
        {
            var shops = _getDisponibilityShop.Execute(code);
            if (shops == null) return NoContent();
            return Ok(shops);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<string>> Get(Guid id)
        {
            var shop = _getShop.Execute(id);
            if (shop == null) return NoContent();
            return Ok(shop);
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

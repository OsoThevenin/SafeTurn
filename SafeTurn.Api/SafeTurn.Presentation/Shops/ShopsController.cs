﻿using Microsoft.AspNetCore.Mvc;
using SafeTurn.Application.Shops.CreateShopCommand;
using SafeTurn.Application.Shops.DeleteShopCommand;
using SafeTurn.Application.Shops.GetDisponibilityShopCommand;
using SafeTurn.Application.Shops.GetShopQuery;
using SafeTurn.Application.Shops.PublishShopCommand;
using SafeTurn.Application.Shops.UpdateShopCommand;
using System;
using System.Collections.Generic;

namespace SafeTurn.Api.Turns
{
    [ApiController]
    [Route("[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly IGetDisponibilityShop _getDisponibilityShop;
        private readonly IGetShop _getShop;
        private readonly ICreateShop _createShop;
        private readonly IUpdateShop _updateShop;
        private readonly IDeleteShop _deleteShop;
        private readonly IPublishShop _publishShop;

        public ShopsController(
            IGetDisponibilityShop getDisponibilityShop,
            IGetShop getShop,
            ICreateShop createShop,
            IUpdateShop updateShop,
            IDeleteShop deleteShop,
            IPublishShop publishShop
        )
        {
            _getDisponibilityShop = getDisponibilityShop;
            _getShop = getShop;
            _createShop = createShop;
            _updateShop = updateShop;
            _deleteShop = deleteShop;
            _publishShop = publishShop;
        }

        [HttpGet]
        public ActionResult<List<string>> GetByCode(string code)
        {
            if (String.IsNullOrEmpty(code)) return BadRequest();
            var model = new GetDisponibilityShopModel() { Code = code };
            var shops = _getDisponibilityShop.Execute(model);
            if (shops == null) return NoContent();
            return Ok(shops);
        }

        [HttpGet("{id}")]
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

        [HttpPut]
        public ActionResult<List<string>> Put(UpdateShopModel model)
        {
            _updateShop.Execute(model);
            return Ok();
        }

        [HttpPut]
        [Route("publish")]
        public ActionResult<List<string>> Publish(PublishShopModel model)
        {
            _publishShop.Execute(model);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<List<string>> Delete(DeleteShopModel model)
        {
            _deleteShop.Execute(model);
            return Ok();
        }
    }
}

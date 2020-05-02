﻿using System;
using System.Collections.Generic;
using System.Text;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.Shops;

namespace SafeTurn.Application.Shops
{
    public class GetShop : IGetShop
    {
        private readonly IShopRepository _shopRepo;

        public GetShop(IShopRepository shopRepo)
        {
            _shopRepo = shopRepo;
        }

        public Shop Execute(Guid id)
        {
            return _shopRepo.GetByIdWithTurns(id);
        }
    }
}
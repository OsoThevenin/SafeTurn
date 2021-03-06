﻿using CleanArchitecture.Domain.Common;
using SafeTurn.Domain.Shops;
using System;
using System.Collections.Generic;

namespace SafeTurn.Domain.Turns
{
    public class Turn : IEntity
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public virtual Shop Shop { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string ClientName { get; set; }
        public bool Confirmed { get; set; }

        private Turn() { /* Required by EF */ }

        public Turn(Guid shopId, DateTime date, string clientName, List<int> numbersUsed)
        {
            ShopId = shopId;
            Date = date;
            ClientName = clientName;
            Number = GenerateNumber(numbersUsed);
        }

        public void ConfirmTurn()
        {
            if (Confirmed) throw new TurnExceptionAlreadyEXist();
            Confirmed = true;
        }

        private int GenerateNumber(List<int> numbersUsed)
        {
            var number = (new Random()).Next(1000, 9999);
            if (numbersUsed.Contains(number)) GenerateNumber(numbersUsed);
            return number;
        }
    }
}

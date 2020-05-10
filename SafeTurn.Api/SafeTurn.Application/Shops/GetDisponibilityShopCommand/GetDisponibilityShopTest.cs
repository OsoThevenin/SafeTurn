using Moq;
using Newtonsoft.Json;
using SafeTurn.Application.Common;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Application.Utils;
using SafeTurn.Domain.Shops;
using SafeTurn.Domain.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace SafeTurn.Application.Shops.GetDisponibilityShopCommand
{
    public class GetDisponibilityShopTest
    {

        private Mock<IShopRepository> _shopRepo;
        private Mock<IUtilDateTime> _utilDateTime;
        private GetDisponibilityShop _service;

        public GetDisponibilityShopTest()
        {
            _shopRepo = new Mock<IShopRepository>();
            _utilDateTime = new Mock<IUtilDateTime>();
            _service = new GetDisponibilityShop(_shopRepo.Object, _utilDateTime.Object);
        }

        [Fact]
        public void GetDisponibilityWithEmptyTurns()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName) { Id = shopId };
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Now },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Min15 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Min30 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour1 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour2 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour4 },
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibilityWhereSopClosed()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName) { Id = shopId };
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 0, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibilityWunavailable()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName) {
                Id = shopId,
                Turns = new List<Turn>()
            };
            var date = new DateTime(2020, 5, 6, 9, 0, 0);
            do
            {
                returnShop.Turns.Add(new Turn(shopId, date, "pepe", new List<int>()));
                date = date.AddMinutes(5);
            } while (date.Hour < 20);
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibilityOnlyNow()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName)
            {
                Id = shopId,
                Turns = new List<Turn>()
            };
            var date = new DateTime(2020, 5, 6, 9, 0, 0);
            do
            {
                if (new DateTime(2020, 5, 6, 10, 5, 0) != date)
                    returnShop.Turns.Add(new Turn(shopId, date, "pepe", new List<int>()));
                date = date.AddMinutes(5);
            } while (date.Hour < 20);
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Now },
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibilityOnly4Hour()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName)
            {
                Id = shopId,
                Turns = new List<Turn>()
            };
            var date = new DateTime(2020, 5, 6, 9, 0, 0);
            do
            {
                if (new DateTime(2020, 5, 6, 13, 0, 0) != date)
                    returnShop.Turns.Add(new Turn(shopId, date, "pepe", new List<int>()));
                date = date.AddMinutes(5);
            } while (date.Hour < 20);
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour4 },
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibilityNowAnd1Hour()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName)
            {
                Id = shopId,
                Turns = new List<Turn>()
            };
            var date = new DateTime(2020, 5, 6, 9, 0, 0);
            do
            {
                if (new DateTime(2020, 5, 6, 10, 0, 0) != date && new DateTime(2020, 5, 6, 11, 10, 0) != date)
                    returnShop.Turns.Add(new Turn(shopId, date, "pepe", new List<int>()));
                date = date.AddMinutes(5);
            } while (date.Hour < 20);
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Now },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour1 },
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }

        [Fact]
        public void GetDisponibility30MinAnd1HourAnd2Hour()
        {
            const string shopName = "name";
            Guid shopId = Guid.NewGuid();
            var returnShop = new Shop("codigo", shopName)
            {
                Id = shopId,
                Turns = new List<Turn>()
            };
            var date = new DateTime(2020, 5, 6, 9, 0, 0);
            do
            {
                if (
                    new DateTime(2020, 5, 6, 10, 30, 0) != date
                    && new DateTime(2020, 5, 6, 11, 5, 0) != date
                    && new DateTime(2020, 5, 6, 11, 10, 0) != date
                    && new DateTime(2020, 5, 6, 12, 30, 0) != date
                ) returnShop.Turns.Add(new Turn(shopId, date, "pepe", new List<int>()));
                date = date.AddMinutes(5);
            } while (date.Hour < 20);
            var model = new GetDisponibilityShopModel() { Code = "codigo" };

            _shopRepo.Setup(x => x.GetByCodeWithTurns(It.IsAny<string>()))
                .Returns(returnShop)
                .Verifiable();
            _utilDateTime.Setup(x => x.GetNow())
                .Returns(new DateTime(2020, 5, 6, 10, 0, 0))
                .Verifiable();

            var expected = new GetDisponibilityShopResponse()
            {
                ShopId = shopId,
                ShopName = shopName,
                Hours = new List<HourDisponibilityShop>()
                {
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Min30 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour1 },
                    new HourDisponibilityShop() { Range = HoursDisponibilityRange.Hour2 },
                }
            };

            var resolve = _service.Execute(model);

            Assert.Equal(expected.ShopId, resolve.ShopId);
            Assert.Equal(expected.ShopName, resolve.ShopName);
            Assert.Equal(
                JsonConvert.SerializeObject(expected.Hours.OrderBy(h => h.Range)),
                JsonConvert.SerializeObject(resolve.Hours.OrderBy(h => h.Range))
            );

            _shopRepo.VerifyAll();
            _utilDateTime.VerifyAll();
        }
    }
}

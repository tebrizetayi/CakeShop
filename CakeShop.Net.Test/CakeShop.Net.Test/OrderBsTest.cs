using CakeShop.Net.BS.Implementation;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CakeShop.Net.Test
{
    [TestClass]
    public class OrderBsTest
    {
        Mock<AppDbContext> _mockAppDbContext;
        UnitOfWork _unitofwork;
        Mock<IShoppingCartBs> _mockShoppingCartBs = new Mock<IShoppingCartBs>();
        OrderBs _orderBs;

        [TestCleanup]
        public void TestCleanup()
        {
            _unitofwork = null;
            _mockAppDbContext = null;
            _orderBs = null;
            Transformation.MapperReset();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //Transformation stuff.
            Transformation.MapperInitialization();
            //Database configuration.
            DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString(), null)
                                .Options;
            _mockAppDbContext = new Mock<AppDbContext>(_options);
            _unitofwork = new UnitOfWork(_mockAppDbContext.Object);
            Mock<IShoppingCartBs> _mockShoppingCartBs = new Mock<IShoppingCartBs>();
            _orderBs = new OrderBs(_mockAppDbContext.Object);
        }

        [TestMethod]
        public void OrderCreate()
        {
            //Arrange
            OrderDto orderDto = new OrderDto()
            {
                Id = Guid.NewGuid()
            };
            var lstShoppingCartItemDto = new List<ShoppingCartItemDto>()
            {
                new ShoppingCartItemDto()
                {
                    Amount = 10,
                    Pie = new PieDto() { Id = Guid.NewGuid(),Price=10 },
                    Id=Guid.NewGuid()
                },
                new ShoppingCartItemDto()
                {
                    Amount = 20,
                    Pie = new PieDto() { Id = Guid.NewGuid(),Price=20 },
                    Id=Guid.NewGuid()
                },
                new ShoppingCartItemDto()
                {
                    Amount = 30,
                    Pie = new PieDto() { Id = Guid.NewGuid(),Price=30 },
                    Id=Guid.NewGuid()
                }
            };
            _mockShoppingCartBs.Setup(x => x.ShoppingCartItems)
                               .Returns(lstShoppingCartItemDto);


            //Act
            _orderBs.CreateOrder(orderDto, _mockShoppingCartBs.Object);
            //Assert
            Assert.IsTrue(_mockShoppingCartBs.Object.ShoppingCartItems==lstShoppingCartItemDto, "There is a problem in CreateOrder in OrderBs!");
        }
    }
}

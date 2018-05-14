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
    public class UnitOfWorkBsTest
    {
        Mock<AppDbContext> _mockAppDbContext;
        UnitOfWork _unitofwork;

        [TestInitialize]
        public void TestInitialize()
        {
            //Database configuration.
            DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("CakeShopeDb", null)
                                .Options;
            _mockAppDbContext = new Mock<AppDbContext>(_options);
            _unitofwork = new UnitOfWork(_mockAppDbContext.Object);
        }

        [TestMethod]
        public void UnitOfWorkCommit()
        {
            //Arrange
            _mockAppDbContext.Setup(x => x.SaveChanges());

            //Act
            _unitofwork.Commit();
            //Assert
            _mockAppDbContext.Verify(x => x.SaveChanges());
        }

        [TestMethod]
        public void UnitOfWorkReject()
        {
            //Arrange
            _mockAppDbContext.Setup(x => x.ChangeTracker).Returns(() => null);            
            //Act
            _unitofwork.RejectChanges();
            //Assert
            _mockAppDbContext.Verify(x => x.ChangeTracker);
        }
    }
}

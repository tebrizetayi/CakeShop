using AutoMapper;
using CakeShop.Net.BS.Implementation;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Linq;

namespace CakeShop.Net.Test
{
    [TestClass]
    public class PieUnitTest
    {
        DbContextOptions<AppDbContext> _options;
        private AppDbContext _appDbContext;
        private UnitOfWork _UnitOfWork;
        private Guid _pieId;
        private PieDto _pieDto;

        [TestInitialize]
        public void TestInitialize()
        {
            //Transformation stuff.
            Transformation.MapperInitialization();
            //Database configuration.
            _options = new DbContextOptionsBuilder<AppDbContext>()
                                            .UseInMemoryDatabase(Guid.NewGuid().ToString(), null)
                                            .Options;

            _appDbContext = new AppDbContext(_options);
            _UnitOfWork = new UnitOfWork(_appDbContext);

            //pie Initialization 
            _pieId = Guid.NewGuid();
            _pieDto = new PieDto()
            {
                Id = _pieId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Status = true
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _UnitOfWork=null;
            _appDbContext=null;
            _options = null;
            Transformation.MapperReset();
        }

        [TestMethod]
        public void PieAdd()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            var pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            //Assert
            Assert.IsNotNull(pieDto, "Object could not be added!The Problem is in Add function.");
        }
        [TestMethod]
        public void PieGetByIdExisting()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            var pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            //Assert
            Assert.IsNotNull(pieDto, "Object could not be found!The Problem in GetById function.");
        }

        [TestMethod]
        public void PieGetByIdNonExisting()
        {
            //Arrange

            //Act
            var pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            //Assert
            Assert.IsNull(pieDto, "There is an object that should not be in the system!The Problem in GetById function.");
        }


        [TestMethod]
        public void PieEdit()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            var pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            _pieDto.ModifiedDate = DateTime.Now;
            _UnitOfWork.PieBs.Edit(pieDto);
            _UnitOfWork.Commit();
            //Act
            pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            //Assert
            Assert.IsNotNull(pieDto, "There is a problem in modifing item!The Problem in Edit function.");
            Assert.IsTrue(pieDto.ModifiedDate != pieDto.CreatedDate, "There is problem in modifing item!The Problem in Edit function.");
        }

        [TestMethod]
        public void PieDelete()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            _UnitOfWork.PieBs.Delete(_pieId);
            var pieDto = _UnitOfWork.PieBs.GetById(_pieId);
            //Assert
            Assert.IsNull(pieDto, "There is a problem in deleting item!The problem in Delete function");
        }


        [TestMethod]
        public void PieFindBy()
        {
            //Arrange
            Console.WriteLine(_UnitOfWork.PieBs.GetAll().Count());
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            var lstPieDt = _UnitOfWork.PieBs.FindBy(x => x.Id == _pieId);
            //Assert
            Assert.IsNotNull(lstPieDt, "The return object is null!There is a problem in FindBy function.");
            Assert.IsTrue(lstPieDt.Count()>0, "The return count is equals to zero!There is a problem in FindBy function.");
        }

        [TestMethod]
        public void PieFindByUnsuccessfully()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            Guid newId = Guid.NewGuid();
            var lstPieDt = _UnitOfWork.PieBs.FindBy(x => x.Id == newId);
            //Assert
            Assert.IsNotNull(lstPieDt, "The return object is null!There is a problem in FindBy function.");
            Assert.IsTrue(lstPieDt.Count()==0, "The return object is null!There is a problem in FindBy function.");
        }

        [TestMethod]
        public void PieGetAll()
        {
            //Arrange
            _UnitOfWork.PieBs.Add(_pieDto);
            _UnitOfWork.Commit();
            //Act
            var lstPieDto = _UnitOfWork.PieBs.GetAll();
            //Assert
            Assert.IsNotNull(lstPieDto, "The return object is null!There is a problem in GetAll function.");
            Assert.IsTrue(lstPieDto.Count() == 1, "Count does not match!There is a problem in GetAll function.");
        }

    }
}

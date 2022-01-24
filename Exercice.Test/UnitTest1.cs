using AutoFixture;
using AutoMapper;
using Exercice.Dto;
using Exercice.MonApi;
using Exercice.MonApi.Controllers;
using Exercice.Persistance;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Exercice.Test
{
    [TestClass]
    public class MoqUsersControllerTest
    {
       // private MonApiContext _context { get; set; } = new

        private IMapper _mapper;
        private UserInfoController UserInfoController { get; set; }

        private Mock<IGeneriqueRepo<UserInfoEntity>> UserRepo { get; set;}
        public ILogger<UserInfoController> Logger { get; set; } = new NullLogger<UserInfoController>();

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<UserInfoEntity> Users { get; set; }

        public MoqUsersControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UserInfoController)));
            _mapper = new Mapper(configuration);
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Users = Fixture.CreateMany<UserInfoEntity>(10);
            UserRepo = new Mock<IGeneriqueRepo<UserInfoEntity>>();
            UserInfoController = new UserInfoController(UserRepo.Object, _context, _mapper, Logger);
        }


        [TestMethod]
        public void TestGetAllUsers_Ok()
        {
            //Arrange
            UserRepo.Setup(repo => repo.GetAll()).Returns(Users);
            UserRepo.Setup(repo => repo.Add(It.IsAny<UserInfoEntity>()))
                .Throws(new Exception("test unitaire"));

            //Act
            var result = UserInfoController.Get();

            //Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<UserInfoDto>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            UserRepo.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void TestGetAllUsers_NullRepository()
        {
            //Arrange
            UserInfoController = new UserInfoController(null, _context, _mapper, Logger);


            //Act
            var result = UserInfoController.Get();

            //Assert
            var statusResult = result as StatusCodeResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZTimeTracker.API.Controllers;
using NLog;
using NUnit.Framework;

namespace GZIT.GZTimeTracker.Test._1000_ProcessTest
{
    [TestFixture]
    public class Test001_CreateUser
    {

        private IUnitOfWork _unitOfWork;
        private NLog.ILogger _logger;

        [SetUp]
        public void Setup()
        {
            var connectionFactory = new ConnectionFactory();
            _unitOfWork = connectionFactory.CreateUnitOfWork();

            _logger = LoggerFactory.GetLogger();


        }

        [Test]
        public void CreateUser()
        {
            _unitOfWork.UserRepository.Insert(new Core.Infrastructure.Entities.UserEntity()
            {
                Email = "Mihalcosi",
                FirstName = "Michal",
                LastName = "Grznar"
            });

            _unitOfWork.Save();

            TestController testController = new TestController(_unitOfWork);

            var data = testController.GetPersons();
            Assert.IsNotNull(data);

        }
    }
}

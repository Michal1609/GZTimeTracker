using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Infrastructure.Data;
using NUnit.Framework;

namespace GZIT.GZTimeTracker.Test._0001_TestRole
{
    [TestFixture]
    public class TestRole
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            var connectionFactory = new ConnectionFactory();
            _unitOfWork = connectionFactory.CreateUnitOfWork();

        }
        [Test]
        public void AddRole()
        {

            //Prepare data
            var roleEntity = new RoleEntity()
            {
                Role = "Admin",
                Description = "Full privilegia",
                Actions = new List<ActionEntity>() {
                new ActionEntity() {
                     Entity = "Action",
                     Privilegia = "Full",
                     Description= "Super new action"},
            new ActionEntity() {
                    Entity= "Readrole",
                    Privilegia = "Full",
                     Description= "Reading roles"}}
                     
            };
            

            // Insert
             _unitOfWork.RoleRepository.Insert(roleEntity);
             _unitOfWork.Save();

            // Load data
            Task<RoleEntity> task = _unitOfWork.RoleRepository.GetById(roleEntity.Id);

            //Assert
            Assert.AreEqual(roleEntity.Actions, task.Result.Actions);
        }

        public void GetRole()
        {

        }

        public void EditRole()
        {

        }

        public void DeleteRole()
        {

        }
    }
}

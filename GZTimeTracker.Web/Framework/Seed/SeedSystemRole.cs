using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Seed
{
    public class SeedSystemRole
    {
        private const int ADMIN_ID = 1;
        private const int MANAGER_ID = 2;
        private const int GUEST_ID = 3;


        private readonly IUnitOfWork _unitOfWork;
        public SeedSystemRole(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SeedData()
        {
            var systemRoleEntities = new List<SystemRoleEntity>();
            systemRoleEntities.Add(new SystemRoleEntity() { Id = ADMIN_ID, Name = "admin", Description = "Administrátor" });
            systemRoleEntities.Add(new SystemRoleEntity() { Id = MANAGER_ID, Name = "manager", Description = "Manager" });
            systemRoleEntities.Add(new SystemRoleEntity() { Id = GUEST_ID, Name = "guest", Description = "Host" });

            var actions = new List<ActionEntity>();
            actions.Add(new ActionEntity() { Id = 1, Action = "project.create", Description = "Create project" });
            actions.Add(new ActionEntity() { Id = 2, Action = "project.edit", Description = "Editace projektu" });
            actions.Add(new ActionEntity() { Id = 3, Action = "project.delete", Description = "Mazání projektu" });
            actions.Add(new ActionEntity() { Id = 4, Action = "project.read", Description = "Čtení projektu" });

            var systemRoleActionsEntities = new List<SystemRoleActionsEntity>();
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 1, SystemRoleId = ADMIN_ID, ActionId = 1 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 2, SystemRoleId = ADMIN_ID, ActionId = 2 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 3, SystemRoleId = ADMIN_ID, ActionId = 3 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 4, SystemRoleId = ADMIN_ID, ActionId = 4 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 5, SystemRoleId = MANAGER_ID, ActionId = 1 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 6, SystemRoleId = MANAGER_ID, ActionId = 2 });
            systemRoleActionsEntities.Add(new SystemRoleActionsEntity() { Id = 7, SystemRoleId = MANAGER_ID, ActionId = 4 });

            _unitOfWork.BeginTransaction();
            SetIdentity("ON", "SystemRoles");
            SeedSystemRoles(systemRoleEntities);
            SetIdentity("OFF", "SystemRoles");   
            
            SetIdentity("ON", "Action");
            SeedActions(actions);
            SetIdentity("OFF", "Action");

            SetIdentity("ON", "SystemRoleActions");
            SeedSystemRoleActions(systemRoleActionsEntities);
            SetIdentity("OFF", "SystemRoleActions");
            _unitOfWork.Commit();

        }

        private void SeedSystemRoles(List<SystemRoleEntity> systemRoles)
        {
            foreach (var role in systemRoles)
            {
                var roleEntity = _unitOfWork.SystemRoleRepository.GetById(role.Id);
                if (roleEntity == null)
                    _unitOfWork.SystemRoleRepository.Insert(role);
                else
                {
                    roleEntity.Name = role.Name;
                    roleEntity.Description = role.Description;
                    _unitOfWork.SystemRoleRepository.Update(roleEntity);
                }
            }

            _unitOfWork.Save();
        }

        private void SeedActions(List<ActionEntity> actionEntities)
        {
            foreach (var action in actionEntities)
            {
                var actionEntity = _unitOfWork.ActionRepository.GetById(action.Id);

                if (actionEntity == null)
                    _unitOfWork.ActionRepository.Insert(action);
                else
                {
                    actionEntity.Action = action.Action;
                    actionEntity.Description = action.Description;
                    _unitOfWork.ActionRepository.Update(actionEntity);
                }
            }

            _unitOfWork.Save();
        }

        private void  SeedSystemRoleActions(List<SystemRoleActionsEntity> systemRoleActionsEntities)
        {
            foreach (var systemRoleAction in systemRoleActionsEntities)
            {
                var entity = _unitOfWork.SystemRoleActionsRepository.GetById(systemRoleAction.Id);

                if (entity == null)
                    _unitOfWork.SystemRoleActionsRepository.Insert(systemRoleAction);
                else
                {
                    entity.SystemRoleId = systemRoleAction.SystemRoleId;
                    entity.ActionId = systemRoleAction.ActionId;
                    _unitOfWork.SystemRoleActionsRepository.Update(entity);
                }
            }

            _unitOfWork.Save();
        }

        private void SetIdentity(string value, string tableName)
        {
            /*
            string sql = "INSERT INTO[dbo].SystemRoles(Name, Description) VALUES('Name', 'aaa')";
            _unitOfWork.SystemRoleRepository.RunRawSql(sql);
            _unitOfWork.Save();
            */
            string sqlCommand = "SET IDENTITY_INSERT dbo.{table} {value}";
            sqlCommand = sqlCommand.Replace("{table}", tableName).Replace("{value}", value);
            _unitOfWork.SystemRoleRepository.RunRawSql(sqlCommand);
            _unitOfWork.Save();
        }
    }
}

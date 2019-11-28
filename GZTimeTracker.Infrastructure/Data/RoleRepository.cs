using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)            
        {
            _context = context;
        }
        public IList<SystemRole> GetSystemRolesActions()
        {
            var systemRoles = new List<SystemRole>();

            var roles = from row in _context.SystemRoles
                        select row;

            foreach (var role in roles)
                systemRoles.Add(new SystemRole() { id = role.Id, Name = role.Name, Actions = new List<string>() });

           foreach(var role in systemRoles)
            {
                role.Actions = (from roleAction in _context.SystemRoleActions
                                join action in _context.Action on roleAction.ActionId equals action.Id
                                where roleAction.SystemRoleId == role.id
                                select action.Action).ToList();
            }

            return systemRoles;

        }

        public int GetUserRoleId(int userId, int projectId)
        {
            return (from role in _context.UserInRoles
                    where role.UserId == userId &&
                        role.ProjectId == projectId
                    select role.RoleId).FirstOrDefault();
        }

        public UserInRoleEntity GetUserRole(int userId, int projectId)
        {
            return (from role in _context.UserInRoles
                    where role.UserId == userId &&
                        role.ProjectId == projectId
                    select role).FirstOrDefault();
        }

        public bool IsUserAuthorizeForAction(int userId, int projectId, string action)
        {
            var userInRole = (from row in _context.UserInRoles
                              where row.UserId == userId &&
                              row.ProjectId == projectId
                              select row).FirstOrDefault();

            if (userInRole.IsSystemRole)
            {
                var actionEntity = (from roleAction in _context.SystemRoleActions
                                    join actioRow in _context.Action on roleAction.ActionId equals actioRow.Id
                                    where roleAction.SystemRoleId == userInRole.RoleId &&
                                    actioRow.Action == action
                                    select actioRow).FirstOrDefault();

                if (actionEntity == null)
                    return false;
                else
                    return true;
            }
            else
            {
                var actionEntity = (from roleAction in _context.CustomerRoleActions
                                    join actioRow in _context.Action on roleAction.ActionId equals actioRow.Id
                                    where roleAction.CustomerRoleId == userInRole.RoleId &&
                                    actioRow.Action == action
                                    select actioRow).FirstOrDefault();

                if (actionEntity == null)
                    return false;
                else
                    return true;
            }
        }

        public bool IsUserAuthorizeForActionInCustomerRole(int roleId, string action)
        {
            var result = (from role in _context.CustomerRoleActions
                          join actionEntity in _context.Action on role.ActionId equals actionEntity.Id
                          where role.Id == roleId &&
                          actionEntity.Action == action
                          select action).SingleOrDefault();

            if (result == null)
                return false;

            return true;
        }
    }
}

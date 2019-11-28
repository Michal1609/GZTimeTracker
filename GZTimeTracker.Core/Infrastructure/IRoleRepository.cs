using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IRoleRepository
    {
        int GetUserRoleId(int userId, int projectId);

        bool IsUserAuthorizeForAction(int userId, int projectId, string action);

        IList<SystemRole> GetSystemRolesActions();

        UserInRoleEntity GetUserRole(int userId, int projectId);

        bool IsUserAuthorizeForActionInCustomerRole(int roleId, string action);

    }
}

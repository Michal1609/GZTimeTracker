using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Core.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Role
{
    public class RoleServices : IRoleServices
    {
        private IList<SystemRole> _systemRoles;
        private readonly IUnitOfWork _unitOfWork;

        public RoleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _systemRoles = _unitOfWork.RoleRepository.GetSystemRolesActions();
        }

        public bool HasUserPrivilegia(int userId, int projectId, string action)
        {
            var userRole = _unitOfWork.RoleRepository.GetUserRole(userId, projectId);

            if (userRole == null) return false;

            if (userRole.IsSystemRole)
            {
                var role = _systemRoles.Where(a => a.id == userRole.RoleId).FirstOrDefault();
                if (role == null) 
                    return false;

                return role.Actions.Contains(action);
            }
            else
            {
                return _unitOfWork.RoleRepository.IsUserAuthorizeForActionInCustomerRole(userRole.Id, action);
            }
        }
    }
}

using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task RegisterUserAsync(UserEntity userEntity, string password);

        UserEntity Authenticate(string username, string password);

        UserEntity GetUserByUserId(Guid userId);
    }
}

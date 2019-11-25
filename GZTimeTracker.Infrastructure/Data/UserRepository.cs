using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {
            
        }

        public async Task RegisterUserAsync(UserEntity userEntity, string password)
        {
            byte[] passwordHash, passwordSalt;
            PasswordService.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            await table.AddAsync(userEntity);
            
        }

        public UserEntity Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = (from row in table
                       where row.Email == username
                       select row).FirstOrDefault();

            if (user is null)
                return null;
            if (!PasswordService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;

        }

        public UserEntity GetUserByUserId(Guid userId)
        {
            if (userId == null)
                return null;

            var user = (from row in table
                        where row.UserId == userId
                        select row).FirstOrDefault();

            return user;
        }
    }
}

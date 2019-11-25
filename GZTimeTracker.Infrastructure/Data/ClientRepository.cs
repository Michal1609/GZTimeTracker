using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class ClientRepository : Repository<ClientEntity>, IClientRepository
    {
        public ClientRepository(DataContext context)
           : base(context)
        {

        }

        public IList<ClientEntity> GetClientsForOwner(UserEntity userEntity)
        {
            if (userEntity == null)
                return new List<ClientEntity>();

            return (from row in table
                    where row.Owner == userEntity
                    select row).ToList();
        }

        public ClientEntity GetClientForOwner(UserEntity userEntity, int clientId)
        {
            if (userEntity == null)
                return new ClientEntity();

            return (from row in table
                    where row.Owner == userEntity &&
                    row.Id == clientId
                    select row).FirstOrDefault();
        }
    }
}

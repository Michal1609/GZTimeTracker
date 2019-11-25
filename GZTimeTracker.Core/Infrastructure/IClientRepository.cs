using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        IList<ClientEntity> GetClientsForOwner(UserEntity userEntity);

        ClientEntity GetClientForOwner(UserEntity userEntity, int clientId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Web
{
    public interface IRoleServices
    {
        bool HasUserPrivilegia(int userId, int projectId, string action);
    }
}

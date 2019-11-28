using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZTimeTracker.Web.Framework.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Extensions
{
    public static class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            var unitOfWork = host.Services.GetService<IUnitOfWork>();

            SeedSystemRole seed = new SeedSystemRole(unitOfWork);
            seed.SeedData();

            return host;
        }
    }
}

using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Infrastructure.Data;
using GZTimeTracker.Web.Framework.Seed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Instalation
{
    public class InstallService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public InstallService(DataContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public void Install()
        {
            // Create database if necessery
            _context.Database.EnsureCreated();

            // Set product Version
            string versionString = _configuration.GetSection("SystemVersion").Value;
            decimal version = decimal.Parse(versionString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            

            var systemInformationEntity = _context.SystemInformation.FirstOrDefault();
            if (systemInformationEntity == null)
                _context.SystemInformation.Add(new SystemInformationEntity() { Version = version });
            else if (systemInformationEntity.Version != version)
            {
                systemInformationEntity.Version = version;
                _context.SystemInformation.Update(systemInformationEntity);
            }

            _context.SaveChanges();

            // Seed system roles
            SeedSystemRole seed = new SeedSystemRole(_unitOfWork);
            seed.SeedData();
        }
    }
}

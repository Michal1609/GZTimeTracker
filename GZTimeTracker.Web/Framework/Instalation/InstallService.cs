using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Infrastructure.Data;
using GZTimeTracker.Web.Framework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<RequestLocalizationOptions> _locOptions;
        public InstallService(DataContext context, IConfiguration configuration, 
            IUnitOfWork unitOfWork, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _locOptions = locOptions;
        }

        public void Install()
        {
            // Create database if necessery
            CreateDbIfNecessery();

            // Set product Version           
            SetProductVersion();

            // Seed system roles
            SeedRole();

            // Set supported languages
            SetSupportedLanguages();
           
        }

        private void CreateDbIfNecessery()
        {
            _context.Database.EnsureCreated();
        }

        private void SetProductVersion()
        {
            string versionString = _configuration.GetSection("SystemVersion").Value;
            decimal version = decimal.Parse(versionString, NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture);

            var systemInformationEntity = _context.SystemInformation.FirstOrDefault();
            if (systemInformationEntity == null)
                _context.SystemInformation.Add(new SystemInformationEntity() { Version = version });
            else if (systemInformationEntity.Version != version)
            {
                systemInformationEntity.Version = version;
                _context.SystemInformation.Update(systemInformationEntity);
            }

            _context.SaveChanges();
        }

        private void SeedRole()
        {
            SeedSystemRole seed = new SeedSystemRole(_unitOfWork);
            seed.SeedData();
        }

        private void SetSupportedLanguages()
        {
            var languages = _context.Language.ToList();
            
            CultureInfo[] cultureInfos = new CultureInfo[languages.Count];
            for (int i = 0; i < languages.Count; i++)
            {
                cultureInfos[i] = new CultureInfo(languages[i].Code);
            }

            _locOptions.Value.SupportedCultures = cultureInfos;
            _locOptions.Value.SupportedUICultures = cultureInfos;
        }
    }
}

using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Localizations
{
    public class StringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IWebHostEnvironment _env;

        public StringLocalizerFactory(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public IStringLocalizer Create(string baseName, string location)
        {
            return new StringLocalizer(_unitOfWork);
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            string baseName = resourceSource.FullName;
            return Create(baseName, _env.ApplicationName);
        }
    }
}

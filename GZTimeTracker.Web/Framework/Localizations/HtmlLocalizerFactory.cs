using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Localizations
{
    public class HtmlLocalizerFactory : IHtmlLocalizerFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public HtmlLocalizerFactory(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public IHtmlLocalizer Create(string baseName, string location)
        {
            return new HtmlLocalizer(_unitOfWork);
        }

        public IHtmlLocalizer Create(Type resourceSource)
        {
            string baseName = resourceSource.FullName;
            return Create(baseName, _env.ApplicationName);
        }
    }
}

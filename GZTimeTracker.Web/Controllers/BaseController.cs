using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{

    public class BaseController : Controller, IBaseController
    {        
        protected readonly ILanguageServices _languageServices;
        public BaseController( ILanguageServices languageServices)
        {            
            _languageServices = languageServices;
            SetPageAndCookiesLanguage();
        }

        private void SetPageAndCookiesLanguage()
        {
            var language =_languageServices.GetLanguage();
            _languageServices.SetLanguage(language);           
        }
    }
}
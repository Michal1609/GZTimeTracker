using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    public class LanguageController : BaseController
    {

        #region Ctor
        public LanguageController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IRoleServices roleServices) : base(languageServices, unitOfWork, roleServices)
        {

        }

        #endregion

        #region Method
        public IActionResult Changlanguge(string selectedLanguage)
        {
            _languageServices.SetLanguage(selectedLanguage);            
                      
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        #endregion
    }
}
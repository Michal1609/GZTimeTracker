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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
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

            string returnUrl = HttpContext.Request.Headers["Referer"].ToString();
            if (Url.IsLocalUrl(returnUrl)) // Make sure the url is relative, not absolute path
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
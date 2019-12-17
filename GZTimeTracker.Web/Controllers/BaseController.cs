using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using GZIT.GZTimeTracker.Core.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GZTimeTracker.Web.Controllers
{

    public class BaseController : Controller, IBaseController
    {        
        protected readonly ILanguageServices _languageServices;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRoleServices _roleServices;
        public BaseController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IRoleServices roleServices)
        {            
            _languageServices = languageServices;
            _unitOfWork = unitOfWork;
            _roleServices = roleServices;
            SetPageAndCookiesLanguage();
        }

        private void SetPageAndCookiesLanguage()
        {
            var language =_languageServices.GetLanguage();
            _languageServices.SetLanguage(language);           
        }

        protected UserEntity GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return null;

            return _unitOfWork.UserRepository.GetUserByUserId(Guid.Parse(userId));
        }

        protected bool HasUserPrivilegia(int userId, int projectId, string action)
        {
            return _roleServices.HasUserPrivilegia(userId, projectId, action);
                       
        }        
    }
}
using GZTimeTracker.Core.Web;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Cookies
{
    public class CookiesServices : ICookiesServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;        
        
        public CookiesServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCookiesByKey(string key)
        {            
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        public void SetCookies(string key, string value)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value);
        }        
    }
}

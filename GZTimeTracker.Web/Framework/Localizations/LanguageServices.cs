using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Core.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Localizations
{
    
    public class LanguageServices : ILanguageServices
    {
        private const string LANGUAGE_KEY = "language";

        private readonly ICookiesServices _cookiesServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<RequestLocalizationOptions> _locOptions;
        public LanguageServices(ICookiesServices cookiesServices, 
            IHttpContextAccessor httpContextAccessor,
            IOptions<RequestLocalizationOptions> locOptions)
        {
            _cookiesServices = cookiesServices;
            _httpContextAccessor = httpContextAccessor;
            _locOptions = locOptions;
        }

        public string GetLanguage()
        {            

            //Get from cookies
            string language = _cookiesServices.GetCookiesByKey(LANGUAGE_KEY);

            if (!string.IsNullOrEmpty(language))
                return language;

            // Get language from http request header
            language = GetLanguageFromRequest();
            if (!string.IsNullOrEmpty(language))
                return language;

            // Get default language
            language = _locOptions.Value.SupportedUICultures.FirstOrDefault().Name;

            return language;

        }

        public void SetLanguage(string languageCode)
        {
            var cultureInfo = new CultureInfo(GetLanguage());            

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            _cookiesServices.SetCookies(LANGUAGE_KEY, languageCode);
        }

        private string GetLanguageFromRequest()
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
                return null;

            //get request culture
            var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture;
            if (requestCulture == null)
                return null;

            return requestCulture.UICulture.Name;
            
        }
    }
}

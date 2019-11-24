using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Localizations
{
    public class ViewLocalizer : IViewLocalizer
    {
        private readonly IHtmlLocalizer _htmlLocalizer;
        public ViewLocalizer(IHtmlLocalizer htmlLocalizer)
        {
            _htmlLocalizer = htmlLocalizer;
        }
        public virtual LocalizedHtmlString this[string key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                return _htmlLocalizer[key];
            }
        }

        public virtual LocalizedHtmlString this[string key, params object[] arguments]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                return _htmlLocalizer[key, arguments];
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _htmlLocalizer.GetAllStrings(includeParentCultures);
        }

        public LocalizedString GetString(string name)
        {
            return _htmlLocalizer.GetString(name);
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            return _htmlLocalizer.GetString(name, arguments);
        }

        [Obsolete]
        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return _htmlLocalizer.WithCulture(culture);
        }
    }
}

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
    public class HtmlLocalizer : IHtmlLocalizer
    {
        private readonly IUnitOfWork _unitOfWork;
        public HtmlLocalizer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        LocalizedHtmlString IHtmlLocalizer.this[string name]
        {
            get { return new LocalizedHtmlString(name, GetString(name)); }
        }

        LocalizedHtmlString IHtmlLocalizer.this[string name, params object[] arguments]
        {
            get { return new LocalizedHtmlString(name, GetString(name, arguments)); }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var list = new List<LocalizedString>();
            var localizedStrings = _unitOfWork.LocaleStringResourceRepository.GetAllStrings();

            foreach (var localizedString in localizedStrings)
                list.Add(new LocalizedString(localizedString.Name, localizedString.Value));

            return list;
            
        }

        public LocalizedString GetString(string name)
        {
            
            var value =_unitOfWork.LocaleStringResourceRepository.GetString(name, WebWorker.GetLanguageIdForCode(CultureInfo.CurrentUICulture.Name));
            if (value == null)
                value = name;
            return new LocalizedString(name, value);
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            var localizedString = GetString(name);
            var value = string.Format(localizedString.Value, arguments);
            return new LocalizedString(name, value);
        }

        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            return new HtmlLocalizer(_unitOfWork);


        }
    }
}

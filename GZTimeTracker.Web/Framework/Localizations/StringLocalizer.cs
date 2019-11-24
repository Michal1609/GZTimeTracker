using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Localizations
{
    public class StringLocalizer : IStringLocalizer
    {
        private readonly IUnitOfWork _unitOfWork;
        public StringLocalizer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public LocalizedString this[string name]
        {
            get
            { 
                var value = _unitOfWork.LocaleStringResourceRepository.GetString(name, CultureInfo.CurrentUICulture.Name);
                if (value == null)
                    value = name;

                return new LocalizedString(name, value);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var value = _unitOfWork.LocaleStringResourceRepository.GetString(name, CultureInfo.CurrentUICulture.Name);
                if (value == null)
                    value = name;

                value = string.Format(value, arguments);
                return new LocalizedString(name, value);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var list = new List<LocalizedString>();
            var localizedStrings = _unitOfWork.LocaleStringResourceRepository.GetAllStrings();

            foreach (var localizedString in localizedStrings)
                list.Add(new LocalizedString(localizedString.Name, localizedString.Value));

            return list;
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            return new StringLocalizer(_unitOfWork);
        }
    }
}

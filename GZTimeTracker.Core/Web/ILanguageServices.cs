using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Web
{
    public interface ILanguageServices
    {
        void SetLanguage(string languageCode);

        string GetLanguage();
    }
}

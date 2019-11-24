using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Core.Web
{
    public interface ICookiesServices
    {
        void SetCookies(string key, string value);

        string GetCookiesByKey(string key);

    }
}

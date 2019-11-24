using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Web
{
    public class LanguageCodeToFlag
    {
        public const string FLAG_FOR_LANGUAGE_CS = "cz";
        public const string FLAG_FOR_LANGUAGE_EN = "us";

        public static Dictionary<string, string> LanguageToFlag
        {
            get
            {
                Dictionary<string, string> dictionoary = new Dictionary<string, string>();
                dictionoary.Add("cs", "cz");
                dictionoary.Add("en", "us");

                return dictionoary;
            }
        }
    }
}

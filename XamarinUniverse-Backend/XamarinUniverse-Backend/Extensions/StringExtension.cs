using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XamarinUniverse_Backend.Extensions
{
    public static class StringExtension
    {
        public static string StringHtmlCleanup(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = Regex.Replace(str, "<.*?>", "");
                str = System.Net.WebUtility.HtmlDecode(str);
            }
            return str;
        }
    }
}

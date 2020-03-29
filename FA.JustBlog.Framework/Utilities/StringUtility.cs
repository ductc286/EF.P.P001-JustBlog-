using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Framework.Utilities
{
    public static class StringUtility
    {
        public static string GenerateShortDescription(string str, int maxLength)
        {
            maxLength = (maxLength > 0) ? maxLength : 0;
            if (str.Length > maxLength)
            {
                string txtAppend = "...";
                str = str.Substring(0, maxLength-1)+txtAppend;
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.Framework.Extensions
{
    public static class ShortStringExtension
    {
        public static MvcHtmlString ShortString(this HtmlHelper helper, string str, int maxLength)
        {
            maxLength = (maxLength > 0) ? maxLength : 0;
            if (str.Length > maxLength)
            {
                string txtAppend = "...";
                str = str.Substring(0, maxLength - 1) + txtAppend;
            }
            return new MvcHtmlString(str);
        }
    }
}

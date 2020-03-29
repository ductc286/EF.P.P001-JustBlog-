using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FA.JustBlog.Framework.Extensions
{
    public static class CheckBoxListExtensition
    {
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, SelectList selectList, object htmlAttribute = null)
        {
            var result = string.Empty;
            if (selectList != null )
            {
                foreach (SelectListItem item in selectList)
                {
                    result += htmlHelper.CheckBox(name, item.Selected, htmlAttribute) + "&nbsp;" + item.Text + "<br />";
                }
            }

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString CheckBoxListFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, SelectList selectList, object htmlAttribute = null)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var result = string.Empty;
            //if (selectList.Count() > 0)
            //{
            //    foreach (SelectListItem item in selectList)
            //    {
            //       result += htmlHelper.CheckBoxFor(expression, htmlAttribute) + "&nbsp;" + item.Text + "<br />";
            //    }
            //}

            return new MvcHtmlString(result);
        }
    }
}

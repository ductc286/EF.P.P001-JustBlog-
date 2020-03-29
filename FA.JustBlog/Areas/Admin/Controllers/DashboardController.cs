using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Blog Owner, Contributor")]
    //[Authorize(Roles = "Contributor")]
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
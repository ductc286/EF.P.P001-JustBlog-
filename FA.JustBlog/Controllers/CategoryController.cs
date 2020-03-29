using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            var listCategories = _categoryRepository.GetAll();
            return PartialView("_CategoriesMenu", listCategories);
        }
    }
}
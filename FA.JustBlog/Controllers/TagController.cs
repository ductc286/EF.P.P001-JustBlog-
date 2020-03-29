using FA.JustBlog.Core.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        
        public TagController()
        {
            _tagRepository = new TagRepository();
        }
        
        [ChildActionOnly]
        public ActionResult PopurlarTags()
        {
            var popularTags = _tagRepository.FindAll().OrderByDescending(t => t.Count).Take(5);
            return PartialView("_PopurlarTags", popularTags);
        }
    }
}
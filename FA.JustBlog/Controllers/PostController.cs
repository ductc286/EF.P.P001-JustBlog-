using FA.JustBlog.Core.Repositories;
using PagedList;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;
        public const int defaultPageSize = 10;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PostController()
        {
            _postRepository = new PostRepository();
            _tagRepository = new TagRepository();
            _categoryRepository = new CategoryRepository();
        }

        //private JustBlogContext db = new JustBlogContext();

        // GET: Posts
        public ActionResult Index(int page = 1)
        {
            log.Info("Load index page");
            var posts = _postRepository.FindAll();
            var onePageOfData = posts.Where(p => p.Published).OrderByDescending(s => s.PostedOn).ToPagedList(page, defaultPageSize);
            ViewBag.OnePageOfData = onePageOfData;
            ViewBag.actionName = "Index";
            ViewBag.controllerName = "Post";
            return View(onePageOfData);
        }
        public ActionResult Category(string category, int page = 1)
        {
            ViewBag.ActionTitle = category;
            var categoryObject = _categoryRepository.GetByUrlSlug(category);

            // Check for invalid cases 
            if (categoryObject == null || page < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            // Execute actions when valid
            var posts = _postRepository.GetPostsByCategory(category);
            var onePageOfData = posts.ToPagedList(page, defaultPageSize);
            ViewBag.OnePageOfData = onePageOfData;
            ViewBag.actionName = categoryObject.UrlSlug;
            ViewBag.controllerName = "Category";
            return View("Index", onePageOfData);
        }
        public ActionResult Tag(string tag, int page = 1)
        {
            var tagObject = _tagRepository.GetTagByUrlSlug(tag);
            // Check for invalid cases 
            if (tagObject == null || page < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.ActionTitle = tagObject.Name;
            var onePageOfData = _postRepository.GetPostsByTag(tag).ToPagedList(page, defaultPageSize);
            ViewBag.OnePageOfData = onePageOfData;
            ViewBag.actionName = tagObject.UrlSlug;
            ViewBag.controllerName = "Tag";
            return View("Index", onePageOfData);
        }
        // GET: Posts/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = postRepository.Find((object) id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(post);
        //}

        public ActionResult Details(int year, int month, string title)
        {
            var post = _postRepository.Find(year, month, title);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [ChildActionOnly]
        public PartialViewResult MostViewedPosts()
        {
            ViewBag.PartialName = "Most viewed posts!";
            var posts = _postRepository.GetMostViewedPost(5);
            //// Map from Post model to PostSummary view model

            return PartialView("_ListPosts", posts);
        }

        [ChildActionOnly]
        public PartialViewResult LatestPosts()
        {
            ViewBag.PartialName = "Latest posts!";
            var posts = _postRepository.GetLatestPost(5);
            //// Map from Post model to PostSummary view model

            return PartialView("_ListPosts", posts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _postRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

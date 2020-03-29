using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Framework.Utilities;
using System;
using System.Net;
using System.Web.Mvc;


namespace FA.JustBlog.Areas.Admin.Controllers
{
    enum Days { one, two};

    [Authorize(Roles = "Blog Owner, Contributor")]
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PostsController()
        {
            _postRepository = new PostRepository();
            _tagRepository = new TagRepository();
            _categoryRepository = new CategoryRepository();
        }

        ////  List posts
        // GET: Admin/Posts
        public ActionResult Index(string id)
        {
            var posts = _postRepository.GetAll();

            return View(posts);
            
            //return RedirectToAction("LatestPosts");
        }

        // GET: Admin/Posts/LatestPosts
        public ActionResult LatestPosts()
        {
            ViewBag.PartialName = "Latest posts!";
            var posts = _postRepository.GetLatestPost();
            return View("Index", posts);

            //// Use MVCGrid
            //return View();
        }
        // GET: Admin/Posts/MostViewedPosts
        public ActionResult MostViewedPosts()
        {
            ViewBag.PartialName = "Most Viewed Posts!";
            var posts = _postRepository.GetMostViewedPost();
            return View("Index", posts);
        }

        // GET: Admin/Posts/MostInterestingPosts
        // Same MostViewedPosts
        public ActionResult MostInterestingPosts()
        {
            ViewBag.PartialName = "Most Interesting Posts!";
            var posts = _postRepository.GetMostViewedPost();
            return View("Index", posts);

        }

        // GET: Admin/Posts/PublishedPosts
        public ActionResult PublishedPosts()
        {
            ViewBag.PartialName = "Published Posts!";
            var posts = _postRepository.GetPublisedPosts();
            return View("Index", posts);
        }

        // GET: Admin/Posts/PublishedPosts
        public ActionResult UnpublishedPosts()
        {
            ViewBag.PartialName = "Un-published Posts!";
            var posts = _postRepository.GetUnpublisedPosts();
            return View("Index", posts);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postRepository.Find((object)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            var post = new Post();
            post.Published = true;
            var categoriesList = _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            return View(post);
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,PostContent,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate")] Post post)
        {
            post.UrlSlug = UrlUtility.GenerateSlug(post.Title);
            post.PostedOn = DateTime.Now;
            post.Modified = DateTime.Now;
            if (ModelState.IsValid)
            {
                var temp  = _postRepository.Add(post);
                return RedirectToAction("Index");
            }

            var categoriesList = _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postRepository.Find((object)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var categoriesList = _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,PostContent,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate")] Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Update(post);
                return RedirectToAction("Index");
            }
            var categoriesList = _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        [Authorize(Roles = "Blog Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postRepository.Find((object)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = _postRepository.Find((object)id);
            _postRepository.Delete(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Blog Owner")]
        public JsonResult SetPublished(int id, bool published)
        {
            var post = _postRepository.Find(id);
            
                post.Published = published;
               var result = _postRepository.Update(post);
            
            return Json(JsonRequestBehavior.AllowGet);
        }
        //// Child action
        [ChildActionOnly]
        public PartialViewResult PartialLatestPosts()
        {
            ViewBag.PartialName = "Latest posts!";
            var posts = _postRepository.GetAll();
            return PartialView("_ListPost", posts);
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

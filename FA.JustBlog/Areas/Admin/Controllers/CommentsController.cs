using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using IdentitySample.Models;
using System.Net;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IComment _commentRepository;
        private readonly IPostRepository _postRepository;

        public CommentsController()
        {
            _commentRepository = new CommentRepository();
            _postRepository = new PostRepository();
        }

        // GET: Admin/Comments
        public ActionResult Index()
        {
            var comments = _commentRepository.GetAll();
            return View(comments);
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentRepository.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(_postRepository.GetAll(), "Id", "Title");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepository.Add(comment);
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(_postRepository.GetAll(), "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentRepository.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(_postRepository.GetAll(), "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepository.Update(comment);
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_postRepository.GetAll(), "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentRepository.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _commentRepository.Find(id);
            _commentRepository.Delete(comment);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _commentRepository.Dispose();
                _postRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

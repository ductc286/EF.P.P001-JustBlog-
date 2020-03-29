using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class TagsController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private readonly ITagRepository _tagRepository;

        public TagsController()
        {
            _tagRepository = new TagRepository();
        }

        // GET: Admin/Tags
        public ActionResult Index()
        {
            return View(_tagRepository.GetAll());
        }

        // GET: Admin/Tags/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Admin/Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Count,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Add(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Admin/Tags/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Count,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Update(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Admin/Tags/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tag tag = _tagRepository.Find(id);
            _tagRepository.Delete(tag);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tagRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

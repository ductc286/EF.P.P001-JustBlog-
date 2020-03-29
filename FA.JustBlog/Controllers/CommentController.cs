using CaptchaMvc.Attributes;
using CaptchaMvc.HtmlHelpers;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly IComment _commentRepository;
        public CommentController()
        {
            _commentRepository = new CommentRepository();
        }
        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            comment.CommentTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                //// Test capcha but not success
                //if (!this.IsCaptchaValid("hi"))
                //{
                //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return Json("Capcha is incorrect!", MediaTypeNames.Text.Plain);
                //}
                _commentRepository.Add(comment);
                return Json(JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Data is incorrect!", MediaTypeNames.Text.Plain);

            //return Json(new { success = false, responseText = "Data is incorrect!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using VulnerableCoreApp.ViewModels;
using VulnerableCoreApp.Models;
using VulnerableCoreApp.Repository;

namespace VulnerableCoreApp.Controllers
{
    public class CrossSiteScriptingController : Controller
    {
        private ICommentsRepository commentsRepository;
        public CrossSiteScriptingController(ICommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DemoTypeI()
        {
            CommentsViewModel comments = commentsRepository.GetAll();
            
            return View(comments);
        }

        [HttpPost]
        public IActionResult DemoTypeI(CommentViewModel comment)
        {
            Comment newComment = new Comment();
            newComment.ID = Guid.NewGuid().ToString();
            newComment.Username = "Anonymous";
            newComment.CreatedAt = DateTime.Now;
            newComment.Text = comment.Text;
            commentsRepository.Save(newComment);

            return RedirectToAction("DemoTypeI");
        }

        [HttpPost]
        public IActionResult DemoTypeIDelete(String ID)
        {
            commentsRepository.Delete(ID);

            return RedirectToAction("DemoTypeI");
        }

        [HttpGet]
        public IActionResult DemoTypeII(string query)
        {
            ViewData["query"] = query;
            
            // Disable Chrome browser XSS protection 
            HttpContext.Response.Headers.Add("X-XSS-Protection","0");
            return View();
        }
    }
}
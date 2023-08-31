using BLL.Interfaces;
using DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var dtos = _postService.GetAllPosts();
            var posts = dtos.Select(x => new PostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Date = x.Date.ToString()
            }).ToList();

            return View(posts);
        }

        // [HttpGet, ActionName("Create")]
        [HttpGet]
        //[Route("/Create")]
        public IActionResult CreatePost()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel createPostVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var dto = new PostDto
            {
                //Id
                Author = createPostVM.Author,
                Content = createPostVM.Content,
            };

            _postService.CreatePost(dto);

            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
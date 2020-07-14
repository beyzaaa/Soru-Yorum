using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soruyorum.DataTransferObjects;
using Soruyorum.Models;
using Soruyorum.Repositories.Interfaces;

namespace Soruyorum.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private int i = 0;
        private readonly IQuestionRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IQuestionRepository repo, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var questions = _repo.GetQuestions();
            ViewBag.questions = questions;

            var buttons = _repo.GetCategories();
            ViewBag.buttons = buttons;
            return View();
        }

        [HttpGet]
        [Route("/Home/Category/{id}")]
        public IActionResult Category(int id)
        {
            var questions = _repo.GetQuestionsByCategory(id);
            ViewBag.questions = questions;

            var buttons = _repo.GetCategories();
            ViewBag.buttons = buttons;
            return View();
        }

        public IActionResult MyQuestions()
        {
            var questions = _repo.GetUserQuestions(User.FindFirstValue(ClaimTypes.Name));
            ViewBag.questions = questions;
            return View();
        }

        [HttpGet]
        [Route("/Home/Comments/{id}")]
        public IActionResult Comments(int id)
        {
            var question = _repo.GetUserQuestions(id);
            i = id;
            ViewBag.Id = question.Id;
            ViewBag.Username = question.Username;
            ViewBag.Title = question.Title;
            ViewBag.Description = question.Description;

            var comments = _repo.GetComments(id);

            ViewBag.Comments = comments;

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Question()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Question(string Title, string Description)
        {

            QuestionToAddDTO q = new QuestionToAddDTO();
            string dl = Request.Form["dl"].ToString();
            q.Username = User.FindFirstValue(ClaimTypes.Name);
            q.Category = int.Parse(dl);
            q.Title = Title;
            q.Description = Description;
            var question = _mapper.Map<Question>(q);
            try
            {
                _repo.AddQuestion(question);
                if (_repo.SaveAll())
                {
                    ViewBag.Name = string.Format("Soru yayınlandı");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }



        [HttpPost]
        public IActionResult Comments(string Text, string QuestionId)
        {
            var comments = _repo.GetComments(int.Parse(QuestionId));
            ViewBag.Comments = comments;
            var question = _repo.GetUserQuestions(int.Parse(QuestionId));
            i = int.Parse(QuestionId);
            ViewBag.Id = question.Id;
            ViewBag.Username = question.Username;
            ViewBag.Title = question.Title;
            ViewBag.Description = question.Description;


            CommentToAdd c = new CommentToAdd();
            string dl = Request.Form["dl"].ToString();
            c.Username = User.FindFirstValue(ClaimTypes.Name);
            c.Text = Text;
            c.QuestionId = int.Parse(QuestionId);
            var comment = _mapper.Map<Comments>(c);
            try
            {
                _repo.AddComment(comment);
                if (_repo.SaveAll())
                {
                    ViewBag.Name = string.Format("Yorum yayınlandı");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

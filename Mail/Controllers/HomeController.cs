using Mail.Models;
using System.Diagnostics;
using Mail.Service.IService;
using Mail.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mail.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _logger = logger;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserByName(Request.Cookies["UserName"]);
            var receivedMsg = await _messageService.GetAllReceivedMessage(user.Id);
            return View(receivedMsg);
        }

        public async Task<IActionResult> Privacy()
        {
            var user = await _userService.GetUserByName(Request.Cookies["UserName"]);
            var sendedMsg = await _messageService.GetAllSendedMessage(user.Id);
            return View(sendedMsg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName)
        {
            var user = await _userService.GetUserByName(userName);
            if (user == null)
            {
                await _userService.AddUser(new Entities.User { Name = userName });
            }
            Response.Cookies.Append("UserName", $"{userName}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> WriteMessage()
        {
            ViewBag.UserName = Request.Cookies["UserName"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriteMessage(string title, string body, string reciplientName)
        {
            var sender = await _userService.GetUserByName(Request.Cookies["UserName"]);
            var recipient = await _userService.GetUserByName(reciplientName);
            var msg = new MessagesInfo()
            {
                Title = title,
                Body = body,
                DispatchTime = DateTime.Now,
                SenderId = sender.Id,
                RecipientId = recipient.Id
            };
            await _messageService.AddMessage(msg);
            return RedirectToAction("Privacy");
        }

        [HttpPost]
        public async Task<JsonResult> AutoComplete(string prefix)
        {
            var users = await _userService.GetAllUser();
            var persons = (from person in users
                           where person.Name.StartsWith(prefix)
                           select new
                           {
                               label = person.Name,
                               val = person.Name
                           }).Take(5).ToList();

            return Json(persons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
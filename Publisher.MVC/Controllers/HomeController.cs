using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Publisher.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISendMessageService _sendMessageService;
        public HomeController(ILogger<HomeController> logger, ISendMessageService sendMessageService)
        {
            _logger = logger;
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(SendMessage_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model: model);
            }
            _sendMessageService.SendMessageToRabbitMQ(model);
            TempData["Success"] = true;
            return RedirectToAction("Index", controllerName: "home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
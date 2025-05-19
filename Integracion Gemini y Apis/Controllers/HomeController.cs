using System.Diagnostics;
using Integracion_Gemini_y_Apis.Models;
using Integracion_Gemini_y_Apis.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Integracion_Gemini_y_Apis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            GeminiRepositorie repo = new GeminiRepositorie();
            string response  = await repo.GetChatBotResponse("Dame un resumen de 100 palbras del titanic");
            ViewBag.chatbotResponse = response;

            return View();
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

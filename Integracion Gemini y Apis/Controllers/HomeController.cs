using System.Diagnostics;
using Integracion_Gemini_y_Apis.Models;
using Integracion_Gemini_y_Apis.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Integracion_Gemini_y_Apis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HuggingsReponse_ContextoBaseDeDatos _contexto;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        

        public async Task<IActionResult> Index()
        {
            //OpenAIRepositorie repo = new OpenAIRepositorie();
            HuggingRepositorie repo = new HuggingRepositorie(_contexto);
            string response = await repo.GetChatBotResponse("Translate inglish to french: hi my name is john");
            ViewBag.chatbotResponse = response;


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GuradarChatBot() 
        {
            HuggingRepositorie repo = new HuggingRepositorie(_contexto);
            string response = await repo.GetChatBotResponse("Translate inglish to french: hi my name is john");
            ViewBag.chatbotResponse = response;
            return View("Index");
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

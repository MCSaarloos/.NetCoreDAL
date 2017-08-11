using Microsoft.AspNetCore.Mvc;
using NetCoreDAL.Businesss.Infrastructure.Interfaces;

namespace NetCoreDAL.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsLogic _settingsLogic;

        public HomeController(ISettingsLogic settingsLogic)
        {
            _settingsLogic = settingsLogic;
        }

        public IActionResult Index()
        {
            var settings = _settingsLogic.GetAllSettings();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

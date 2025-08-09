using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ProductMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public HomeController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _localizer["Home"];
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Nupat_CSharp.Service;
using Nupat_CSharp.ViewModel;

namespace Nupat_CSharp.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanguageService _lanService;


        public LanguageController(ILogger<HomeController> logger, ILanguageService lanService)
        {
            _logger = logger;
            _lanService = lanService;
        }
        public async Task<IActionResult> Index()
        {
            var lans = await _lanService.Getlanguages();  
            return View(lans);
        }
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> AddLanguage(LanguageViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                var lan = await _lanService.AddLanguage(languageViewModel);
                return RedirectToAction("Index", lan);
            }

            return View("Add", languageViewModel);
        }

    }
}

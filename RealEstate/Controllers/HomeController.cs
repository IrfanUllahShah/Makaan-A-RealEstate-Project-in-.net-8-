using InfraStructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger,IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }


        //Home page for anyone
        public async Task<IActionResult> Index()
        {
            var properties = await _homeRepository.PropertyList();
            return View(properties);
        }

        //Home page for owner
        public async Task<IActionResult> IndexForOwner()
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

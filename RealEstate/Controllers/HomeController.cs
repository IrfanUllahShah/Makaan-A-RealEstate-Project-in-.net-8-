using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        private readonly ITypeRepository typeRepository;
        private readonly IChoiseRepository choiseRepository;

        public HomeController(ILogger<HomeController> logger,IHomeRepository homeRepository,ITypeRepository typeRepository,IChoiseRepository choiseRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
            this.typeRepository = typeRepository;
            this.choiseRepository = choiseRepository;
        }


        //Home page for anyone
        public async Task<IActionResult> Index()
        {
            //Model which contain both lists and types count for home page
            var model = new PropertyListPlusTypeVm();
            model.types = await typeRepository.TypeGetAll();
            model.choises = await choiseRepository.ChoiseGetAll();
            model.propertyList= await _homeRepository.PropertyList();
            model.propertyTypesCountVm = await _homeRepository.PropertyTypeCount();
            return View(model);
        }

        //Home page for owner
        public async Task<IActionResult> IndexForOwner()
        {
            //Model which contain both lists and types count for home page
            var model = new PropertyListPlusTypeVm();
            model.types=await typeRepository.TypeGetAll();
            model.choises=await choiseRepository.ChoiseGetAll();
            model.propertyList = await _homeRepository.PropertyList();
            model.propertyTypesCountVm = await _homeRepository.PropertyTypeCount();
            return View(model);
        }

        //contact page for
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }


        //action for search box on home page
        [HttpPost]
        public async Task<IActionResult> SearchBox(HomeSearchVm model)
        {
            var results=await _homeRepository.PropertyListOfSearchBar(model);
            return View(results);
        }

        //action for search box on home page for owner pannel
        [HttpPost]
        public async Task<IActionResult> SearchBoxForOwner(HomeSearchVm model)
        {
            var results = await _homeRepository.PropertyListOfSearchBar(model);
            return View(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

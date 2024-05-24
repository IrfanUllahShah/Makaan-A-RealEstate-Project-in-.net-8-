using InfraStructure.Implementation;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ITypeRepository typeRepository;
        private readonly IChoiseRepository choiseRepository;
        private readonly IPropertyRepository propertyRepository;
        private readonly IHomeRepository homeRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PropertyController(ITypeRepository typeRepository,IChoiseRepository choiseRepository, IPropertyRepository propertyRepository, IWebHostEnvironment webHostEnvironment,IHomeRepository homeRepository)
        {
            this.typeRepository = typeRepository;
            this.choiseRepository = choiseRepository;
            this.propertyRepository = propertyRepository;
            this._hostEnvironment = webHostEnvironment;
            this.homeRepository = homeRepository;

        }
        public async Task<IActionResult> AddProperty()
        {
            var viewModel = new PropertyCreatVm();
            viewModel.types = await typeRepository.TypeGetAll();
            viewModel.choises = await choiseRepository.ChoiseGetAll();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty(PropertyCreatVm model)
        {
            //retrive owner model of current owner from session becaue we need owner id in property
            var result = HttpContext.Session.GetObject<OwnerVm>("LogInModel");

            if (result != null) 
            {
                model.OwnerId=result.Id;
            }

            if (!(await propertyRepository.IsImageFile(model.ImageFile)))
            {
                //ModelState.AddModelError("", "Only image files are allowed.");
                ViewBag.ErrorMessage = "Only image files are allowed.";
                return RedirectToAction("AddProperty","Property"); // Return to the view with the validation error
            }

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            model.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            if (await propertyRepository.AddProperty(model))
            {
                ViewBag.ErrorMessage = "Property addded successfully.";
            }
            else
            {
                ViewBag.ErrorMessage="something went wrong";
            }

            //return RedirectToAction("Students", new { Controller = "Student" });
            return View();

        }

        //List of all propery for home dropdown list
        public async Task<IActionResult> PropertyGetAll()
        {
            var properties = await homeRepository.PropertyList();
            return View(properties);
        }

        //List of all propery for owner pannel
        public async Task<IActionResult> PropertyGetAllForOwner()
        {
            var properties = await homeRepository.PropertyList();
            return View(properties);
        }

        //List of all propery type for home dropdown list
        public async Task<IActionResult> PropertyTypeGetAll()
        {
            var types = await homeRepository.PropertyTypeCount();
            return View(types);
        }



        //Action to show all property list for specific owner
        public async Task<IActionResult> ShowOwnerPropertyList()
        {
            //retrive owner model of current owner from session becaue we need owner id in property
            var result = HttpContext.Session.GetObject<OwnerVm>("LogInModel");

            var proprtyList=await propertyRepository.PropertyListForOwner(result.Id);
            return View(proprtyList);
        }

        //Actions to show all property list for specific type id
        public async Task<IActionResult> ApartmentList()
        {
            int id = 1; //id for apartment
            var proprtyList = await propertyRepository.PropertyListForType(id);
            if(proprtyList == null)
            {
                ViewBag.ErrorMessage = "No listing yet";
                return View(proprtyList);
            }
            else
            {
                return View(proprtyList);
            }
            
        }
        public async Task<IActionResult> ApartmentListForOwner()
        {
            int id = 1; //id for apartment
            var proprtyList = await propertyRepository.PropertyListForType(id);
            if (proprtyList == null)
            {
                ViewBag.ErrorMessage = "No listing yet";
                return View(proprtyList);
            }
            else
            {
                return View(proprtyList);
            }

        }

        public async Task<IActionResult> villaList()
        {
            int id = 2; //id for villa
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> villaListForOwner()
        {
            int id = 2; //id for villa
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> HomeList()
        {
            int id = 3; //id for home
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> HomeListForOwner()
        {
            int id = 3; //id for home
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> TownHouseList()
        {
            int id = 4; //id for townhouse
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> TownHouseListForOwner()
        {
            int id = 4; //id for townhouse
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> BuildingList()
        {
            int id = 5; //id for building
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> BuildingListForOwner()
        {
            int id = 5; //id for building
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> OfficeList()
        {
            int id = 6; //id for office
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> OfficeListForOwner()
        {
            int id = 6; //id for office
            var proprtyList = await propertyRepository.PropertyListForType(id);
            return View(proprtyList);
        }

        //-------------------------------------------------------------------------------------------------------
        //Actions to show all property list for specific Choise id like rent or sale for home page
        public async Task<IActionResult> SaleList()
        {
            int id = 1; //id for sale
            var proprtyList = await propertyRepository.PropertyListForChoise(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> SaleListForOwner()
        {
            int id = 1; //id for sale
            var proprtyList = await propertyRepository.PropertyListForChoise(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> RentList()
        {
            int id = 2; //id for rent
            var proprtyList = await propertyRepository.PropertyListForChoise(id);
            return View(proprtyList);
        }

        public async Task<IActionResult> RentListForOwner()
        {
            int id = 2; //id for rent
            var proprtyList = await propertyRepository.PropertyListForChoise(id);
            return View(proprtyList);
        }


        //-------------------------------------------------------------------------------------------------------
        //Actions to show all details of specific property on click
        public async Task<IActionResult> PropertyDetails(int id)
        {
          var result=await propertyRepository.PropertyDetails(id);
          return View(result);
        }

        public async Task<IActionResult> PropertyDetailsForOwner(int id)
        {
            var result = await propertyRepository.PropertyDetails(id);
            return View(result);
        }

        //Actions for delete property by owner after sale
        public async Task<IActionResult> PropertyDelete(int id)
        {
            if(await propertyRepository.PropertyDelete(id))
            {
                return RedirectToAction("ShowOwnerPropertyList");
            }
            else
            {
                return RedirectToAction("ShowOwnerPropertyList");
            }  
        }

    }
}

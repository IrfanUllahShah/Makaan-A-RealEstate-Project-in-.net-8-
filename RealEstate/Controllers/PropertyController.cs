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
        private readonly IWebHostEnvironment _hostEnvironment;

        public PropertyController(ITypeRepository typeRepository,IChoiseRepository choiseRepository, IPropertyRepository propertyRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.typeRepository = typeRepository;
            this.choiseRepository = choiseRepository;
            this.propertyRepository = propertyRepository;
            this._hostEnvironment = webHostEnvironment;

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
                return View(model); // Return to the view with the validation error
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


    }
}

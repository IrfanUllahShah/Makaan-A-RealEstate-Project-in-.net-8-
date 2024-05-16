using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
	public class OwnerController : Controller
	{
        private readonly IOwnerRepository _ownerRepository;
        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }


        public async Task<IActionResult> Dashboard()
		{
            if (HttpContext.Session.GetString("FirstName") == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            else
            {
                return View();
            } 
        }

        public async Task<IActionResult> Profile()
        {
            var model = HttpContext.Session.GetObject<OwnerVm>("LogInModel");
            if (model != null)
            {
                var result = await _ownerRepository.OwnerVmGetById(model.Id);

                if (result != null)
                {
                    return View(result);
                }
                return View(model);
            }
            else
            {
                return View();
            }
        }


        //Owner update actions
        public async Task<IActionResult> Update(int id)
        {
            return View(await _ownerRepository.OwnerGetById(id));
        }


        //Action for student update   ------- Teacher pannel
        [HttpPost]
        public async Task<IActionResult> Update(OwnerUpdateVm model)
        {
            await _ownerRepository.OwnerUpdate(model);
            return RedirectToAction("Profile","Owner");
        }
    }
}

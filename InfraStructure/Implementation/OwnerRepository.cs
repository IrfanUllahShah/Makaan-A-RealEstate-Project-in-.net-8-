using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Implementation
{
	public class OwnerRepository:IOwnerRepository
	{
		
		private readonly IGenericRepository _genericRepository;
		private readonly RealEstateContext db;

		public OwnerRepository(IGenericRepository genericRepository,RealEstateContext realEstateContext)
		{
			_genericRepository = genericRepository;
			db = realEstateContext;
		}

		//add owner to db
		public async Task<bool> AddOwner(OwnerCreateVm model)
		{
			var owner = new Owner()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Contact = model.Contact,
				Password = model.Password,
			};
			_genericRepository.Create<Owner>(owner);
			return true;

		}

        //Get by id owner
        public async Task<OwnerUpdateVm> OwnerGetById(int id)
        {
            var owner = await db.Owners.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (owner != null)
            {
                return new OwnerUpdateVm()
                {
                  Id = owner.Id,
                  FirstName = owner.FirstName, 
                  LastName = owner.LastName,
                  Email = owner.Email,
                  Contact = owner.Contact,
                  Password = owner.Password,
                };
            }
            else
            {
                return null;
            }
        }

        //update owner
        public async Task<bool> OwnerUpdate(OwnerUpdateVm model)
        {
            var owner = await db.Owners.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (owner != null)
            {
                owner.Id = model.Id;
                owner.FirstName = model.FirstName;
                owner.LastName = model.LastName;
                owner.Email = model.Email;
                owner.Contact = model.Contact;
                owner.Password = model.Password;
            }
            _genericRepository.Update<Owner>(owner);
            return true;
        }

        //retrive ownerVm from id of session model whuch used for profile after editing
        public async Task<OwnerVm> OwnerVmGetById(int id)
        {
            var owner = await db.Owners.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (owner != null)
            {
                return new OwnerVm()
                {
                    Id = owner.Id,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Email = owner.Email,
                    Contact = owner.Contact,
                    Password = owner.Password,
                };
            }
            else
            {
                return null;
            }
        }


    }
}

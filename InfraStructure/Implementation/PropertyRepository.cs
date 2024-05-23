using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InfraStructure.Implementation
{
    public class PropertyRepository: IPropertyRepository
    {
        private readonly IGenericRepository genericRepository;
        private readonly RealEstateContext db;

        public PropertyRepository(IGenericRepository genericRepository,RealEstateContext realEstateContext)
        {
            this.genericRepository = genericRepository;
            db = realEstateContext;
        }

        //method for checking image file
        public async Task<bool> IsImageFile(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            // Check if the file has a valid image extension
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico", ".jfif", ".webp" };
            string extension = Path.GetExtension(file.FileName).ToLower();

            return allowedExtensions.Contains(extension);
        }

        public async Task<bool> AddProperty(PropertyCreatVm model)
        {
            var property = new Property()
            {
                Title = model.Title,
                Price = model.Price,
                Image = model.Image, 
                Size = model.Size,
                Baths = model.Baths,
                Rooms = model.Rooms,
                Address = model.Address,
                ChoiseId = model.ChoiseId,
                TypeId = model.TypeId,
                OwnerId = model.OwnerId,
            };

            await genericRepository.Create<Property>(property);
            return true;
        }


        //Property list for owner
        public async Task<List<PropertyVm>> PropertyListForOwner(int id)
        {

            var results = await db.Properties.Where(p=>p.OwnerId==id)
             .Select(p => new PropertyVm
               {
                 Id = p.Id,
                 Title = p.Title,
                 Price = p.Price,
                  Address = p.Address,
                  Baths = p.Baths,
                  Rooms = p.Rooms,
                  Size = p.Size,
                  Image = p.Image,
                  choise = p.Choise != null ? p.Choise.Choise1 : "N/A",
                  type = p.Type != null ? p.Type.Type1 : "N/A",
                 owner = p.Owner != null ? p.Owner.FirstName : "N/A"
             })
             .ToListAsync();

            return results;
        }

        //Property list for differnt type on the basis of type ID for home page
        public async Task<List<PropertyVm>> PropertyListForType(int id)
        {

            var results = await db.Properties.Where(p => p.TypeId == id)
             .Select(p => new PropertyVm
             {
                 Id = p.Id,
                 Title = p.Title,
                 Price = p.Price,
                 Address = p.Address,
                 Baths = p.Baths,
                 Rooms = p.Rooms,
                 Size = p.Size,
                 Image = p.Image,
                 choise = p.Choise != null ? p.Choise.Choise1 : "N/A",
                 type = p.Type != null ? p.Type.Type1 : "N/A",
                 owner = p.Owner != null ? p.Owner.FirstName : "N/A"
             })
             .ToListAsync();

            return results;
        }

        //Property list for differnt choise(rent or sale) on the basis of choise ID for home page
        public async Task<List<PropertyVm>> PropertyListForChoise(int id)
        {

            var results = await db.Properties.Where(p => p.ChoiseId == id)
             .Select(p => new PropertyVm
             {
                 Id = p.Id,
                 Title = p.Title,
                 Price = p.Price,
                 Address = p.Address,
                 Baths = p.Baths,
                 Rooms = p.Rooms,
                 Size = p.Size,
                 Image = p.Image,
                 choise = p.Choise != null ? p.Choise.Choise1 : "N/A",
                 type = p.Type != null ? p.Type.Type1 : "N/A",
                 owner = p.Owner != null ? p.Owner.FirstName : "N/A"
             })
             .ToListAsync();

            return results;
        }

        //Property details
        public async Task<PropertyDetailsVm> PropertyDetails(int id)
        {

            var result = await db.Properties.Where(p => p.Id == id)
             .Select(p => new PropertyDetailsVm
             {
                 Id = p.Id,
                 Title = p.Title,
                 Price = p.Price,
                 Address = p.Address,
                 Baths = p.Baths,
                 Rooms = p.Rooms,
                 Size = p.Size,
                 Image = p.Image,
                 Choise = p.Choise != null ? p.Choise.Choise1 : "N/A",
                 Type = p.Type != null ? p.Type.Type1 : "N/A",
                 ownerName = p.Owner != null ? p.Owner.FirstName+" "+p.Owner.LastName : "N/A",
                 ownerContact = p.Owner != null ? p.Owner.Contact : "N/A",
                 ownerEmail = p.Owner != null ? p.Owner.Email : "N/A"
             })
             .FirstOrDefaultAsync();

            return result;
        }
    }
}


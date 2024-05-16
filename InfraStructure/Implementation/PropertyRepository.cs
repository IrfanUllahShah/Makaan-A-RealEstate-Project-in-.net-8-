using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Http;
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

        public PropertyRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
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
    }
}

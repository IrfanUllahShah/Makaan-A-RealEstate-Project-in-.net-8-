using InfraStructure.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IPropertyRepository
    {
         Task<bool> IsImageFile(IFormFile file);
        Task<bool> AddProperty(PropertyCreatVm model);
        Task<List<PropertyVm>> PropertyListForOwner(int id);
        Task<List<PropertyVm>> PropertyListForType(int id);
        Task<List<PropertyVm>> PropertyListForChoise(int id);
        Task<PropertyDetailsVm> PropertyDetails(int id);
    }
}

using InfraStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IHomeRepository
    {
        Task<List<PropertyVm>> PropertyList();
        Task<PropertyTypesCountVm> PropertyTypeCount();
        Task<List<PropertyVm>> PropertyListOfSearchBar(HomeSearchVm model);
    }
}

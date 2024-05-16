using InfraStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface ITypeRepository
    {
        Task<List<TypeVm>> TypeGetAll();
    }
}

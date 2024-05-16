using InfraStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
	public interface IOwnerRepository
	{
		Task<bool> AddOwner(OwnerCreateVm model);
		Task<OwnerUpdateVm> OwnerGetById(int id);
		Task<bool> OwnerUpdate(OwnerUpdateVm model);
		Task<OwnerVm> OwnerVmGetById(int id);

    }
}

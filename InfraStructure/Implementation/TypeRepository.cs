using InfraStructure.ViewModels;
using Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStructure.Interfaces;

namespace InfraStructure.Implementation
{
    public class TypeRepository: ITypeRepository
    {
        private readonly IGenericRepository repository;
        public TypeRepository(IGenericRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<TypeVm>> TypeGetAll()
        {
            List<TypeVm> types = new List<TypeVm>();

            var results = await repository.GetAll<Domain_Models.Type>();

            foreach (var type in results)
            {
                var typeVm = new TypeVm
                {
                    Id = type.Id,
                    Type1 = type.Type1
                };

                types.Add(typeVm);
            }

            return types;
        }
    }
}

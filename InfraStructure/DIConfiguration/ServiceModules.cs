using InfraStructure.Implementation;
using InfraStructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DIConfiguration
{
    public class ServiceModules
    {
        public static void Regsiter(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
			services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IChoiseRepository, ChoiseRepository>(); 
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IPropertyRepository,PropertyRepository>();
            services.AddTransient<IHomeRepository, HomeRepository>(); 
        }
    }
}

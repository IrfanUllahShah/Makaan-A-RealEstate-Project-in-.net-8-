using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IGenericRepository
    {
        Task<List<T>> GetAll<T>() where T : class;
        Task<bool> Create<T>(T entity) where T : class;
        Task<bool> Update<T>(T entity) where T : class;
        Task<bool> Delete<T>(T entity) where T : class;
    }
}

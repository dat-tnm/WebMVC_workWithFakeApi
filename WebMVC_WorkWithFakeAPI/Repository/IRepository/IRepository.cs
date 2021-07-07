using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_WorkWithFakeAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> CreateAsync(T objectToCreate);
        Task<bool> UpdateAsync(int id, T objectToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}

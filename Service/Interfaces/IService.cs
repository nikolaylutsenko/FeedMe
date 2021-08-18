using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IService<T>
    {
        Task AddAsync(T item);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(string id);
        Task UpdateAsync(T item);
    }
}
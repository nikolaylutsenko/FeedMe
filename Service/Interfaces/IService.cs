using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IService<T>
    {
        Task AddAsync(T item);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T item);
    }
}
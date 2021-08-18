using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Service(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item), "Pass null");

            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Pass empty value", nameof(id));

            var result = await _dbSet.FindAsync(id);

            if (result is null) throw new ArgumentNullException(nameof(result), $"Item with id {id} not found");

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Pass empty value", nameof(id));
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
        }

        public async Task UpdateAsync(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item), "Pass empty value");

            _dbSet.Update(item);

            await _context.SaveChangesAsync();
        }
    }
}
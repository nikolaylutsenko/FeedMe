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

        public async Task<T> GetAsync(Guid id)
        {
            var result = await _dbSet.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item is null) return false;

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            if (item is null) return false;

            _dbSet.Update(item);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
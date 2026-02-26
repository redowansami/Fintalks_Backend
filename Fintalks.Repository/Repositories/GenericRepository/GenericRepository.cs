using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Interfaces;
using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Repository.Repositories.GenericRepository
{
    public class GenericRepository<T>(ApplicationDBContext _context) : IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> _dbSet = _context.Set<T>();

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            if (entity is ISoftDeletable softDeletable)
            {
                softDeletable.DeletedAt = DateTime.UtcNow;
                var entry = _context.Entry(softDeletable);
                entry.Property(e => e.DeletedAt).IsModified = true;
            }
            else
            {
                _dbSet.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

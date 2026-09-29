using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB.DBEntity;

namespace Fintalks.Repository.Repositories.GenericRepository
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}

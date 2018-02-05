using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoEFCore.BaseRepository
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        void Add(T entity);
        Task<bool> AddAsync(T entity);

        bool CheckExist(Expression<Func<T, bool>> predicate);
        Task<bool> CheckExistAsync(Expression<Func<T, bool>> predicate);

        int Commit();
        Task<bool> CommitAsync();

        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllAsIQuerable();

        T GetSingle(Guid id);
        Task<T> GetSingleAsync(Guid id);

        T GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
      

        void Update(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
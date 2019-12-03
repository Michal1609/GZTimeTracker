using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    /// <summary>
    /// Represent database context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        public IList<T> GetAll();
        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T Insert(T obj);
        void Insert(List<T> list);
        void Update(T obj);
        void Delete(int id);

        void Delete(IEnumerable<T> items);
        void DeleteAll();
        Task<int> Count();      
        void RunRawSql(string sql);
        void Save();
    }
}



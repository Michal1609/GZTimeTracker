using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void DeleteAll();
        Task<int> Count();

        IQueryable<T> EntityFromSql<T>(string sql, params object[] parameters) where T : BaseClass;

        void Save();
    }
}



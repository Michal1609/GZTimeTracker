using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        private DataContext _context;
        public DbSet<T> table = null;

        public Repository(DataContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();         
        }

        public Task<T> GetById(int id)
        {
            return table.FirstAsync(x => x.Id == id);            
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void DeleteAll()
        {
            table.RemoveRange(table);
        }

        public async Task<int> Count()
        {
            return await table.CountAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<T1> EntityFromSql<T1>(string sql, params object[] parameters) where T1 : BaseClass
        {
            throw new NotImplementedException();
        }
    }

}

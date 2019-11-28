using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEnitity
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

        public Task<T> GetByIdAsync(int id)
        {     
            return table.FirstAsync(x => x.Id == id);            
        }

        public T GetById(int id)
        {            
            return table.FirstOrDefault(x => x.Id == id);
        }

        public T Insert(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public void Update(T obj)
        {
            try
            {
                
                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
            }
            catch(Exception ex)
            {

            }
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

        public void RunRawSql(string sql)
        {
            _context.Database.ExecuteSqlRaw(sql);
        }
        public IQueryable<T1> EntityFromSql<T1>(string sql, params object[] parameters) where T1 : BaseEnitity
        {
            throw new NotImplementedException();
        }
    }

}

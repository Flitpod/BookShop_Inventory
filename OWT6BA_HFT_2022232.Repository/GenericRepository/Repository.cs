using OWT6BA_HFT_2022232.Repository.Database;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Repository.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        // members 
        protected BookDbContext dbContext;

        // ctor
        protected Repository(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CRUD methods
        public void Create(T item)
        {
            dbContext.Set<T>().Add(item);
            dbContext.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return dbContext.Set<T>();
        }
        public void Delete(int id)
        {
            dbContext.Set<T>().Remove(Read(id));
            dbContext.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}

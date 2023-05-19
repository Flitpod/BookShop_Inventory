using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Repository.Interface
{
    public interface IRepository<T>  where T : class
    {
        public void Create(T item);
        public T Read(int id);
        public IQueryable<T> ReadAll();
        public void Update(T item);
        public void Delete(int id);
    }
}

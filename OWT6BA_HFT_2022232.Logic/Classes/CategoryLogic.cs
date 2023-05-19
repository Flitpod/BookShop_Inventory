using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Classes
{
    public class CategoryLogic
    {
        // members
        IRepository<Category> repository;

        // ctor
        public CategoryLogic(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        // CRUD methods
        public void Create(Category item)
        {
            if (item.CategoryName == "")
            {
                throw new Exception("[EXCEPTION] CategoryName can not be an empty string!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            if (this.repository.ReadAll().Where(a => a.CategoryId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Category in the database identified by given id ({id})!");
            }
            this.repository.Delete(id);
        }

        public Category Read(int id)
        {
            if (this.repository.ReadAll().Where(a => a.CategoryId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Category in the database identified by given id ({id})!");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<Category> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Category item)
        {
            this.repository.Update(item);
        }
    }
}

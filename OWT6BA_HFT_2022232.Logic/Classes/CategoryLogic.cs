using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Classes
{
    public class CategoryLogic:ICategoryLogic
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


        // NON-CRUD method
        public IEnumerable<CategoryStatistics> GetStatisticsFromStartYear(int startYear)
        {
            return (from c in this.repository.ReadAll()
                    from b in c.Books
                    where b.ReleaseYear >= startYear
                    group b by c.CategoryName into g
                    select new CategoryStatistics()
                    {
                        CategoryName = g.Key,
                        NumberOfBooks = g.Count(),
                        AvgRating = g.Average(b => b.Rating),
                        SumNumberOfReviews = g.Sum(b => b.NumberOfReviews),
                    }).AsEnumerable();
        }
    }
}

using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Database;
using OWT6BA_HFT_2022232.Repository.GenericRepository;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Repository.ModelRepositories
{
    public class CategoryRepository : Repository<Category>
    {
        // ctor
        public CategoryRepository(BookDbContext dbContext) : base(dbContext)
        {
        }

        // override astract crud methods
        public override Category Read(int id)
        {
            return this.dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public override void Update(Category item)
        {
            var old = Read(item.CategoryId);
            foreach(var prop in item.GetType().GetProperties()) 
            {
                prop.SetValue(old, prop.GetValue(item));
            }
        }
    }
}

using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Database;
using OWT6BA_HFT_2022232.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Repository.ModelRepositories
{
    public class BookRepository : Repository<Book>
    {
        // ctor
        public BookRepository(BookDbContext dbContext) : base(dbContext)
        {
        }

        // override abstract crud methods
        public override Book Read(int id)
        {
            return dbContext.Books.FirstOrDefault(b => b.BookId == id);
        }

        public override void Update(Book item)
        {
            var old = Read(item.BookId);
            foreach(var prop in item.GetType().GetProperties()) 
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            dbContext.SaveChanges();
        }
    }
}

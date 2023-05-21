using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class AuthorRepository : Repository<Author>
    {
        // ctor
        public AuthorRepository(BookDbContext dbContext) : base(dbContext)
        {
        }

        // override abstract crud methods
        public override Author Read(int id)
        {
            return dbContext.Authors.FirstOrDefault(a => a.AuthorId == id);
        }

        public override void Update(Author item)
        {
            var old = Read(item.AuthorId);
            foreach (var prop in item.GetType().GetProperties())
            {
                if(prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            dbContext.SaveChanges();
        }
    }
}

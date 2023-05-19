using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Classes
{
    public class BookLogic
    {
        // members
        IRepository<Book> repository;

        // ctor - dependency injection
        public BookLogic(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        // CRUD methods
        public void Create(Book item)
        {
            if (item.Title == "")
            {
                throw new Exception("[EXCEPTION] Book Title can not be an empty string!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            if (this.repository.ReadAll().Where(a => a.BookId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Book in the database identified by given id ({id})!");
            }
            this.repository.Delete(id);
        }

        public Book Read(int id)
        {
            if (this.repository.ReadAll().Where(a => a.BookId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Book in the database identified by given id ({id})!");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<Book> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Book item)
        {
            this.repository.Update(item);
        }
    }
}

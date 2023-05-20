using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Classes
{
    public class BookLogic : IBookLogic
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
            if (this.repository.ReadAll().FirstOrDefault(b => b.BookId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Book in the database identified by given id ({id})!");
            }
            this.repository.Delete(id);
        }

        public Book Read(int id)
        {
            if (this.repository.ReadAll().FirstOrDefault(b => b.BookId == id) == null)
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


        // NON-CRUD methods
        /// <summary>
        /// Give back the all book from the given year order by categories and then order by ratings in a category subgroup
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Book> BooksFromYear(int year)
        {
            return (this.repository.ReadAll()
                    .Where(b => b.ReleaseYear == year)
                    .OrderBy(b => b.Category.CategoryName)
                    .ThenByDescending(b => b.Rating))
                    .AsEnumerable();
        }

        /// <summary>
        /// Give back BookYearStatistics objects containing the year, NumberOfBooks, NumberOfCategories, NumberOfAuthors in the same year, if the actual year contains minimum 1 book
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<BookYearStatistics> GetStatisticsByYears()
        {
            return (from b in this.repository.ReadAll()
                    group b by b.ReleaseYear into g
                    select new BookYearStatistics()
                    {
                        Year = g.Key,
                        NumberOfBooks = g.Count(),
                        NumberOfAuthors = g.GroupBy(b => b.Author.AuthorId).Count(),
                        NumberOfCategories = g.GroupBy(b => b.Category.CategoryId).Count(),
                    }).AsEnumerable();                             
        }
    }
}

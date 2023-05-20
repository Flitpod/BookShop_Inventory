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
    public class AuthorLogic : IAuthorLogic
    {
        // members
        IRepository<Author> repository;

        // ctor - dependency injection
        public AuthorLogic(IRepository<Author> repository)
        {
            this.repository = repository;
        }


        // CRUD methods
        public void Create(Author item)
        {
            if (item.AuthorName == "") 
            {
                throw new Exception("[EXCEPTION] AuthorName can not be an empty string!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            if(this.repository.ReadAll().Where(a => a.AuthorId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Author in the database identified by given id ({id})!");
            }
            this.repository.Delete(id);
        }


        public Author Read(int id)
        {
            if (this.repository.ReadAll().Where(a => a.AuthorId == id) == null)
            {
                throw new Exception($"[EXCEPTION] No Author in the database identified by given id ({id})!");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Author item)
        {
            this.repository.Update(item);
        }


        // NON-CRUD methods
        /// <summary>
        /// Gives back AuthorStatistics object containing Authorname, Average - NumberOfPages/book, Average Price/book, Average Rating/book
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AuthorStatistics> GetStatistics()
        {
            return (from a in this.repository.ReadAll()
                    from b in a.Books
                    group b by a.AuthorName into g
                    select new AuthorStatistics()
                    {
                        AuthorName = g.Key,
                        AvgPageNumber = g.Average(b => b.Pages),
                        AvgPrice = g.Average(b => b.Price),
                        AvgRating = g.Average(b => b.Rating),
                    }).AsEnumerable();
        }

        /// <summary>
        /// Gives back the category names of the chosen author (by id) in ascending order without recurrence
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<string> CategoriesOfAuthor(int id)
        {
            return (from b in this.repository.Read(id).Books
                    orderby b.Category.CategoryName ascending
                    select b.Category.CategoryName)
                    .Distinct()
                    .AsEnumerable();
        }
    }
}

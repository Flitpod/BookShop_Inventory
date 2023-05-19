using Microsoft.EntityFrameworkCore;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Database;
using OWT6BA_HFT_2022232.Repository.Interface;
using OWT6BA_HFT_2022232.Repository.ModelRepositories;
using System;
using System.Linq;

namespace OWT6BA_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // manual tests during developement
            // BookDbContextTest(); // PASSED
            // RepositoryTests(); // PASSED

        }

        /// <summary>
        /// Tests - Entitity Database works with the loaded DbSeeds
        /// </summary>
        static void BookDbContextTest()
        {
            BookDbContext db = new BookDbContext();
            var authors = db.Authors.ToArray();
            var categories = db.Categories.ToArray();
            var books = db.Books.ToArray();
            ;
        }

        /// <summary>
        /// Tests - Repository classes work as should
        /// </summary>
        static void RepositoryTests()
        {
            BookDbContext dbContext = new BookDbContext();

            IRepository<Author> AuthorRepo = new AuthorRepository(dbContext);
            IRepository<Book> BookRepo = new BookRepository(dbContext);
            IRepository<Category> CategoryRepo = new CategoryRepository(dbContext);

            var authors = AuthorRepo.ReadAll().ToArray();
            var books = BookRepo.ReadAll().ToArray();
            var categories = CategoryRepo.ReadAll().ToArray();

            ;
        }
    }
}

using ConsoleTools;
using OWT6BA_HFT_2022232.Client.Classes;
using OWT6BA_HFT_2022232.Client.Interfaces;
using OWT6BA_HFT_2022232.Models;
using System;
using System.Runtime.ConstrainedExecution;

namespace OWT6BA_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region manual tests during developement
            // BookDbContextTest(); // PASSED
            // RepositoryTests(); // PASSED
            #endregion


            IRestService rest = new RestService("http://localhost:6614/",nameof(Author) + "/ReadAll");

            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => crud.ReadAll<Author>())
                .Add("Read", () => crud.Read<Author>())
                .Add("Create", () => crud.Create<Author>())
                .Add("Delete", () => crud.Delete<Author>())
                .Add("Update", () => crud.Update<Author>())
                .Add("GetStatistics", () => nonCrud.ReadAuthorStatistics())
                .Add("GetCategoriesOfAuthor", () => nonCrud.ReadAllCategoriesOfAuthor())
                .Add("Exit", ConsoleMenu.Close);

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => crud.ReadAll<Book>())
                .Add("Read", () => crud.Read<Book>())
                .Add("Create", () => crud.Create<Book>())
                .Add("Delete", () => crud.Delete<Book>())
                .Add("Update", () => crud.Update<Book>())
                .Add("BooksFromYear", () => nonCrud.ReadBooksFromYear())
                .Add("BookStatisticsByYears", () => nonCrud.ReadBookStatisticsByYears())
                .Add("Exit", ConsoleMenu.Close);

            var categorySubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => crud.ReadAll<Category>())
                .Add("Read", () => crud.Read<Category>())
                .Add("Create", () => crud.Create<Category>())
                .Add("Delete", () => crud.Delete<Category>())
                .Add("Update", () => crud.Update<Category>())
                .Add("CategoryStatisticsFromStartYear", () => nonCrud.ReadCategoryStatisticsFromStartYear())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Books", () => bookSubMenu.Show())
                .Add("Categories", () => categorySubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }

        #region Manual Tests during development
        /// <summary>
        /// Tests - Entitity Database works with the loaded DbSeeds
        /// </summary>
        static void BookDbContextTest()
        {
            //BookDbContext db = new BookDbContext();
            //var authors = db.Authors.ToArray();
            //var categories = db.Categories.ToArray();
            //var books = db.Books.ToArray();
            //;
        }

        /// <summary>
        /// Tests - Repository classes work as should
        /// </summary>
        static void RepositoryTests()
        {
            //BookDbContext dbContext = new BookDbContext();

            //IRepository<Author> AuthorRepo = new AuthorRepository(dbContext);
            //IRepository<Book> BookRepo = new BookRepository(dbContext);
            //IRepository<Category> CategoryRepo = new CategoryRepository(dbContext);

            //var authors = AuthorRepo.ReadAll().ToArray();
            //var books = BookRepo.ReadAll().ToArray();
            //var categories = CategoryRepo.ReadAll().ToArray();

            //IBookLogic bookLogic = new BookLogic(BookRepo);

            //var a = bookLogic.GetStatisticsByYears().ToArray();
            //;
        }
        #endregion
    }
}

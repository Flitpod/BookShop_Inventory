using OWT6BA_HFT_2022232.Repository.Database;
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
    }
}

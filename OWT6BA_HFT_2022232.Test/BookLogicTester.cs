using Moq;
using NUnit.Framework;
using OWT6BA_HFT_2022232.Logic.Classes;
using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models.DTO;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Test
{
    [TestFixture]
    public class BookLogicTester
    {
        // members
        IBookLogic bookLogic;

        // setup with mock repository
        [SetUp]
        public void Init()
        {
            var mockBookRepo = new Mock<IRepository<Book>>();

            // seeds
            Author a1 = new Author() { AuthorId = 1, AuthorName = "A" }; 
            Author a2 = new Author() { AuthorId = 2, AuthorName = "B" }; 

            Category c1 = new Category() { CategoryId = 1, CategoryName = "a" };
            Category c2 = new Category() { CategoryId = 2, CategoryName = "b" };
            Category c3 = new Category() { CategoryId = 3, CategoryName = "c" };

            Book b1 = new Book() { BookId = 1, ReleaseYear = 2001, Rating = 4.1, Category = c1, Author = a1 };
            Book b2 = new Book() { BookId = 2, ReleaseYear = 2001, Rating = 4.2, Category = c3, Author = a2 };
            Book b3 = new Book() { BookId = 3, ReleaseYear = 2001, Rating = 4.3, Category = c2, Author = a1 };
            Book b4 = new Book() { BookId = 4, ReleaseYear = 2002, Rating = 4.4, Category = c2, Author = a2 };
            Book b5 = new Book() { BookId = 5, ReleaseYear = 2002, Rating = 4.5, Category = c2, Author = a2 };
            Book b6 = new Book() { BookId = 6, ReleaseYear = 2004, Rating = 4.6, Category = c3, Author = a1 };
            Book b7 = new Book() { BookId = 7, ReleaseYear = 2004, Rating = 4.7, Category = c2, Author = a1 };
            Book b8 = new Book() { BookId = 8, ReleaseYear = 2004, Rating = 4.8, Category = c2, Author = a1 };

            var books = new List<Book>() { b1, b2, b3, b4, b5, b6, b7, b8 }.AsQueryable();

            // mockRepository Setup
            mockBookRepo.Setup(br => br.ReadAll()).Returns(books);

            // CategoryLogic instancing
            this.bookLogic = new BookLogic(mockBookRepo.Object);
        }


        // NON-CRUD tests
        [Test]
        public void BookLogic_BooksFromYear_Test()
        {
            // arrange - 2004
            Author a1 = new Author() { AuthorId = 1, AuthorName = "A" };

            Category c2 = new Category() { CategoryId = 2, CategoryName = "b" };
            Category c3 = new Category() { CategoryId = 3, CategoryName = "c" };

            Book b6 = new Book() { BookId = 6, ReleaseYear = 2004, Rating = 4.6, Category = c3, Author = a1 };
            Book b7 = new Book() { BookId = 7, ReleaseYear = 2004, Rating = 4.7, Category = c2, Author = a1 };
            Book b8 = new Book() { BookId = 8, ReleaseYear = 2004, Rating = 4.8, Category = c2, Author = a1 };

            var expected = new List<Book>() { b8, b7, b6};

            // act 
            var actual = this.bookLogic.BooksFromYear(2004);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void BookLogic_GetStatisticsByYears_Test()
        {
            // arrange
            var expected = new List<BookYearStatistics>()
            {
                new BookYearStatistics() {Year = 2001, NumberOfAuthors = 2, NumberOfBooks = 3, NumberOfCategories = 3},
                new BookYearStatistics() {Year = 2002, NumberOfAuthors = 1, NumberOfBooks = 2, NumberOfCategories = 1},
                new BookYearStatistics() {Year = 2004, NumberOfAuthors = 1, NumberOfBooks = 3, NumberOfCategories = 2},
            };

            // act 
            var actual = this.bookLogic.GetStatisticsByYears().ToArray();
            
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

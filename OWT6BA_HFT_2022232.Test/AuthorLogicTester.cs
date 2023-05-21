using Moq;
using NUnit.Framework;
using OWT6BA_HFT_2022232.Logic.Classes;
using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using OWT6BA_HFT_2022232.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Test
{
    [TestFixture]
    public class AuthorLogicTester
    {
        // members
        private IAuthorLogic authorLogic;
        private Mock<IRepository<Author>> mockAuthorRepo;

        // setup with mock repository
        [SetUp]
        public void Init()
        {
            this.mockAuthorRepo = new Mock<IRepository<Author>>();

            // seeds
            Category c1 = new Category() {CategoryId = 1, CategoryName = "a" };
            Category c2 = new Category() {CategoryId = 2, CategoryName = "b" };
            Category c3 = new Category() {CategoryId = 3, CategoryName = "c" };

            Book b1 = new Book() { BookId = 1, Pages = 100, Price = 10, Rating = 4.1, Category = c1 };
            Book b2 = new Book() { BookId = 2, Pages = 200, Price = 20, Rating = 4.2, Category = c2 };
            Book b3 = new Book() { BookId = 3, Pages = 300, Price = 30, Rating = 4.3, Category = c2 };
            Book b4 = new Book() { BookId = 4, Pages = 400, Price = 40, Rating = 4.4, Category = c3 };
            Book b5 = new Book() { BookId = 5, Pages = 500, Price = 50, Rating = 4.5, Category = c3 };
            Book b6 = new Book() { BookId = 6, Pages = 600, Price = 60, Rating = 4.6, Category = c3 };
            Book b7 = new Book() { BookId = 7, Pages = 700, Price = 70, Rating = 4.7, Category = c1 };
            Book b8 = new Book() { BookId = 8, Pages = 800, Price = 80, Rating = 4.8, Category = c3 };
  
            Author a1 = new Author() { AuthorId = 1, AuthorName = "A", Books = new List<Book>() { b1, b2, b3, b4 } }; // categories c1, c2, c2, c3 (a,b,b,c)
            Author a2 = new Author() { AuthorId = 2, AuthorName = "B", Books = new List<Book>() { b5, b6, b7, b8 } }; // categories c3, c3, c1, c3 (c,c,a,c)

            var authors = new List<Author>() { a1, a2 }.AsQueryable();

            // mockRepository Setup
            mockAuthorRepo.Setup(ar => ar.ReadAll()).Returns(authors);
            mockAuthorRepo.Setup(ar => ar.Read(It.Is<int>(id => id==1))).Returns(a1);

            // AuthorLogic instancing
            this.authorLogic = new AuthorLogic(mockAuthorRepo.Object);
        }


        // CRUD tests
        // Create tests
        [Test]
        public void AuthorLogic_Create_RepositoryCreateCall_Test()
        {
            // arrange 
            Author author = new Author() { AuthorId = 3, AuthorName = "C" };

            // act
            this.authorLogic.Create(author);

            // assert
            this.mockAuthorRepo.Verify(ar => ar.Create(author), Times.Once);
        }

        [Test]
        public void AuthorLogic_CreateThrowsExceptionEmptyString_RepositoryCreateNotCall_Test()
        {
            // arrange 
            Author author = new Author() { AuthorId = 3, AuthorName = "" };

            // asserts
            Assert.Throws<Exception>(() => this.authorLogic.Create(author));
            this.mockAuthorRepo.Verify(ar => ar.Create(author),Times.Never);
        }


        // Delete Test
        [Test]
        public void AuthorLogic_DeleteInvalidIdThrowsException_Test()
        {
            // assert
            Assert.Throws<Exception>(() => this.authorLogic.Delete(3));
        }

        // Read Test
        [Test]
        public void AuthorLogic_ReadInvalidIdThrowsException_Test()
        {
            // assert
            Assert.Throws<Exception>(() => this.authorLogic.Read(3));
        }

        // NON-CRUD tests
        [Test]
        public void AuthorLogic_GetStatistics_Test()
        {
            // arrange
            var expected = new List<AuthorStatistics>()
            {
                new AuthorStatistics() {AuthorName = "A", AvgPageNumber = 250, AvgPrice = 25, AvgRating = 4.2},
                new AuthorStatistics() {AuthorName = "B", AvgPageNumber = 650, AvgPrice = 65, AvgRating = 4.6},
            };

            // act 
            var actual = this.authorLogic.GetStatistics();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AuthorLogic_CategoriesOfAuthor_Test()
        {
            // arrange 
            var expected = new List<string>() { "a", "b", "c" };

            // act
            var actual = this.authorLogic.CategoriesOfAuthor(1);

            // assert
            Assert.AreEqual(expected,actual);
        }
    }
}

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
    public class CategoryLogicTester
    {
        // members
        private ICategoryLogic categoryLogic;
        private Mock<IRepository<Category>> mockCategoryRepo;

        // setup with mock repository
        [SetUp]
        public void Init()
        {
            this.mockCategoryRepo = new Mock<IRepository<Category>>();

            // seeds
            Book b1 = new Book() { BookId = 1, ReleaseYear = 1901, Rating = 4.1, NumberOfReviews = 10 };
            Book b2 = new Book() { BookId = 2, ReleaseYear = 2002, Rating = 4.2, NumberOfReviews = 20 };
            Book b3 = new Book() { BookId = 3, ReleaseYear = 2003, Rating = 4.3, NumberOfReviews = 30 };
            Book b4 = new Book() { BookId = 4, ReleaseYear = 2004, Rating = 4.4, NumberOfReviews = 40 };
            Book b5 = new Book() { BookId = 5, ReleaseYear = 1905, Rating = 4.5, NumberOfReviews = 50 };
            Book b6 = new Book() { BookId = 6, ReleaseYear = 2000, Rating = 4.6, NumberOfReviews = 60 };

            Category c1 = new Category() { CategoryId = 1, CategoryName = "a", Books = new List<Book>() { b1, b2, b3, b4 } };
            Category c2 = new Category() { CategoryId = 2, CategoryName = "b", Books = new List<Book>() { b5, b6 } };

            var categories = new List<Category>() { c1, c2 }.AsQueryable();

            // mockRepository Setup
            mockCategoryRepo.Setup(cr => cr.ReadAll()).Returns(categories);

            // CategoryLogic instancing
            this.categoryLogic = new CategoryLogic(mockCategoryRepo.Object);
        }


        // CRUD tests
        // Create tests
        [Test]
        public void BookLogic_Create_RepositoryCreateCall_Test()
        {
            // arrange 
            Category category = new Category() { CategoryId = 3 };

            // act
            this.categoryLogic.Create(category);

            // assert
            this.mockCategoryRepo.Verify(ar => ar.Create(category), Times.Once);
        }

        [Test]
        public void BookLogic_CreateThrowsExceptionEmptyString_RepositoryCreateNotCall_Test()
        {
            // arrange 
            Category category = new Category() { CategoryId = 3, CategoryName = "" };

            // asserts
            Assert.Throws<Exception>(() => this.categoryLogic.Create(category));
            this.mockCategoryRepo.Verify(ar => ar.Create(category), Times.Never);
        }


        // Delete Test
        [Test]
        public void BookLogic_DeleteInvalidIdThrowsException_Test()
        {
            // assert
            Assert.Throws<Exception>(() => this.categoryLogic.Delete(3));
        }

        // Read Test
        [Test]
        public void BookLogic_ReadInvalidIdThrowsException_Test()
        {
            // assert
            Assert.Throws<Exception>(() => this.categoryLogic.Read(3));
        }



        // NON-CRUD test
        [Test]
        public void CategoryLogic_GetStatisticsFromStartYear_Test()
        {
            // arrange
            var expected = new List<CategoryStatistics>()
            {
                new CategoryStatistics() {CategoryName = "a", NumberOfBooks = 3, AvgRating = 4.3, SumNumberOfReviews = 90 },
                new CategoryStatistics() {CategoryName = "b", NumberOfBooks = 1, AvgRating = 4.6, SumNumberOfReviews = 60 },
            };

            // act 
            var actual = this.categoryLogic.GetStatisticsFromStartYear(2000);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

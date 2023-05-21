using OWT6BA_HFT_2022232.Client.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace OWT6BA_HFT_2022232.Client.Classes
{
    public class NonCrudService
    {
        // members
        IRestService restService;

        // ctor - dependency injection
        public NonCrudService(IRestService restService)
        {
            this.restService = restService;
        }


        // AUTHOR
        public void ReadAuthorStatistics()
        {
            try
            {
                var authorStats = restService.Get<AuthorStatistics>("Author/GetStatistics");
                WriteOutCollection<AuthorStatistics>(authorStats);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReadAllCategoriesOfAuthor()
        {
            try
            {
                Console.WriteLine("Id=");
                int id = int.Parse(Console.ReadLine());
                var categories = restService.Get<string>($"Author/CategoriesOfAuthor?id={id}");
                foreach (var item in categories)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }


        // BOOK
        public void ReadBooksFromYear()
        {
            try
            {
                Console.WriteLine("Year=");
                int year = int.Parse(Console.ReadLine());
                var books = restService.Get<Book>($"Book/BooksFromYear?year={year}");
                WriteOutCollection<Book>(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReadBookStatisticsByYears()
        {
            try
            {
                var bookYearStatistics = restService.Get<BookYearStatistics>($"Book/GetStatisticsByYears");
                WriteOutCollection<BookYearStatistics>(bookYearStatistics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // CATEGORY
        public void ReadCategoryStatisticsFromStartYear()
        {
            try
            {
                Console.WriteLine("startYear=");
                int startYear = int.Parse(Console.ReadLine());
                var categoryStatistics = restService.Get<CategoryStatistics>($"Category/GetStatisticsFromStartYear?startYear={startYear}");
                WriteOutCollection<CategoryStatistics>(categoryStatistics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // helper method
        private void WriteOutCollection<T>(IEnumerable<T> collection)
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));

            foreach (var property in properties)
            {
                Console.Write($"{property.Name}\t");
            }
            Console.Write("\n");

            foreach (var item in collection)
            {
                foreach (var property in properties)
                {
                    Console.Write($"{property.GetValue(item)}\t");
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }

        private void WriteOutCollectionFormated<T>(IEnumerable<T> collection)
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));

            Console.SetWindowSize(200, 40);

            int i = 0;
            int width = 20;
            foreach (var property in properties)
            {
                var actPos = Console.GetCursorPosition();
                Console.SetCursorPosition(i * width, actPos.Top);
                string propName = property.Name;
                if (property.Name.Length > width)
                {
                    propName = property.Name.Substring(0,width-2);
                }
                Console.Write($"{propName}");
                i++;
            }
            Console.Write("\n");

            foreach (var item in collection)
            {
                i = 0;
                foreach (var property in properties)
                {
                    var actPos = Console.GetCursorPosition();
                    Console.SetCursorPosition(i * width, actPos.Top);
                    string value = property.GetValue(item).ToString();
                    if (value.Length > width)
                    {
                        value = value.Substring(0, width - 2);
                    }
                    Console.Write($"{value}");
                    i++;
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }
    }
}

using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Interfaces
{
    public interface IBookLogic
    {
        void Create(Book item);
        Book Read(int id);
        IEnumerable<Book> ReadAll();
        void Update(Book item);
        void Delete(int id);
        IEnumerable<Book> BooksFromYear(int year);
        IEnumerable<BookYearStatistics> GetStatisticsByYears();
    }
}

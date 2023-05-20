using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Interfaces
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author item);
        void Delete(int id);
        IEnumerable<AuthorStatistics> GetStatistics();
        IEnumerable<string> CategoriesOfAuthor(int id);
    }
}

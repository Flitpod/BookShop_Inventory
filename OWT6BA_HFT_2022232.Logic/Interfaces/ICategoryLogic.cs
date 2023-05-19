using OWT6BA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Logic.Interfaces
{
    public interface ICategoryLogic
    {
        void Create(Category item);
        Category Read(int id);
        IEnumerable<Category> ReadAll();
        void Update(Category item);
        void Delete(int id);
    }
}

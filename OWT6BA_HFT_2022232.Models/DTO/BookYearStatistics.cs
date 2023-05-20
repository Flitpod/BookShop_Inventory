using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Models.DTO
{
    public class BookYearStatistics
    {
        // members
        public int Year { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfCategories { get; set; }
        public int NumberOfAuthors { get; set; }

        // overrides for Test
        public override bool Equals(object obj)
        {
            BookYearStatistics a = this;
            BookYearStatistics b = obj as BookYearStatistics;
            return a.Year == b.Year &&
                   a.NumberOfBooks == b.NumberOfBooks &&
                   a.NumberOfCategories == b.NumberOfCategories &&
                   a.NumberOfAuthors == b.NumberOfAuthors;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, NumberOfBooks, NumberOfCategories, NumberOfAuthors);
        }
    }
}

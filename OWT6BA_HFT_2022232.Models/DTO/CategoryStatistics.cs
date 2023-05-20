using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Models.DTO
{
    public class CategoryStatistics
    {
        [StringLength(240)]
        public string CategoryName { get; set; }

        public int NumberOfBooks { get; set; }

        public double AvgRating { get; set; }

        public double SumNumberOfReviews { get; set; }

        // override Equals and GetHashCode
        public override bool Equals(object obj)
        {
            CategoryStatistics a = this;
            CategoryStatistics b = obj as CategoryStatistics;
            return  a.CategoryName == b.CategoryName &&
                    a.NumberOfBooks == b.NumberOfBooks &&
                    a.AvgRating == b.AvgRating &&
                    a.SumNumberOfReviews == b.SumNumberOfReviews;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CategoryName,NumberOfBooks,AvgRating, SumNumberOfReviews);
        }
    }
}

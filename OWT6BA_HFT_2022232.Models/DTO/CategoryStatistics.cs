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
    }
}

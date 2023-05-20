using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Models.DTO
{
    public class AuthorStatistics
    {
        [StringLength(240)]
        public string AuthorName { get; set; }

        public double AvgPageNumber { get; set; }

        public double AvgPrice { get; set; }

        public double AvgRating { get; set; }
    }
}

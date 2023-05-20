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

        // override Equals and GetHashCode for the test
        public override bool Equals(object obj)
        {
            AuthorStatistics a = this;
            AuthorStatistics b = obj as AuthorStatistics;
            return  a.AuthorName == b.AuthorName &&
                    a.AvgPageNumber == b.AvgPageNumber &&
                    a.AvgPrice == b.AvgPrice &&
                    a.AvgRating == b.AvgRating;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AuthorName, AvgPageNumber, AvgPrice, AvgRating);
        }
    }
}

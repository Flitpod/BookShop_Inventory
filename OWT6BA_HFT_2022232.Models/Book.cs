using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int Pages { get; set; }

        public double Rating { get; set; }
        
        public int NumberOfReviews { get; set; }

        public int AuthorId { get; set; }

        public int CaregoryId { get; set; }
    }
}

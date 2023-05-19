using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Models
{
    public class Book
    {
        // members
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int Pages { get; set; }

        public double Price { get; set; }

        public double Rating { get; set; }
        
        public int NumberOfReviews { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(Category))]
        public int CaregoryId { get; set; }


        // Navigation Properties for LazyLoading
        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }


        // ctors 
        public Book()
        {
                
        }

        public Book(string line)
        {
            string[] temp = line.Split('*');
            this.BookId = int.Parse(temp[0]);
            this.Title = temp[1];
            this.ReleaseYear = int.Parse(temp[2]);
            this.Pages = int.Parse(temp[3]);
            this.Price = double.Parse(temp[4].Replace('.', ','));
            this.Rating = double.Parse(temp[5].Replace('.',','));
            this.NumberOfReviews = int.Parse(temp[6]);
            this.AuthorId = int.Parse(temp[7]);
            this.CaregoryId = int.Parse(temp[8]);
        }
    }
}

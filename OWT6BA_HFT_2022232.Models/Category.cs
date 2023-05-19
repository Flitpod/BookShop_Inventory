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
    public class Category
    {
        // members
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [StringLength(240)]
        public string CategoryName { get; set; }

        // Navigation Property for LazyLoading
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        // ctors
        public Category()
        {
            
        }

        public Category(string line)
        {
            string[] temp = line.Split('*');
            this.CategoryId = int.Parse(temp[0]);
            this.CategoryName = temp[1];
        }
    }
}

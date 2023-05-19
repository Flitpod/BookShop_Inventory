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
    public class Author
    {
        //members
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [StringLength(240)]
        string AuthorName { get; set; }

        // Navigation Property for LazyLoading
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        // ctors
        public Author()
        {
            
        }

        public Author(string line)
        {
            string[] temp = line.Split('*');
            this.AuthorId = int.Parse(temp[0]);
            this.AuthorName = temp[1];
        }
    }
}

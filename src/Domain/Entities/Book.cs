using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }   = string.Empty;
        public string Author { get; set; } = string.Empty;
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string CreatedById { get; set; }    
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

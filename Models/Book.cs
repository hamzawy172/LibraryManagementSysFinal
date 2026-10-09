using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSys.Models
{
    [Index(nameof(ISBN) , IsUnique = true)]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required , Range(0.1,double.MaxValue)]
        public decimal Price { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<Borrowing> borrowings { get; set; } = new List<Borrowing>();
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSys.Dtos.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(0.1, double.MinValue)]
        public decimal Price { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
    }
}

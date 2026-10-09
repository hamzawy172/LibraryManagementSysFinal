using System.ComponentModel.DataAnnotations;
using System.Security;

namespace LibraryManagementSys.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]

        public int BookCount { get; set; }
    }
}

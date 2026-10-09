using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSys.Dtos.CategoryDtos
{
    public class CreateCatogoryDto
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}

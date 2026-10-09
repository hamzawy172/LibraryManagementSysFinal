using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSys.Dtos.BorrowingDtos
{
    public class BorrowingDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime BorrowData { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
    }
}

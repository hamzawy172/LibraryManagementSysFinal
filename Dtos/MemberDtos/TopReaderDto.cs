using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSys.Dtos.MemberDtos
{
    public class TopReaderDto
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public int BorrowingCount { get; set; }

    }
}

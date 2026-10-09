using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSys.Models
{
    [Index(nameof(Email) , IsUnique = true)]
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public ICollection<Borrowing> borrowings { get; set; } = new List<Borrowing>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSys.Models
{
    public class Borrowing
    {

        public int Id { get; set; }
        [Required]
        public DateTime BorrowData { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}

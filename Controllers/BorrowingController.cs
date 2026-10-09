using System.Numerics;
using LibraryManagementSys.Dtos.BookDtos;
using LibraryManagementSys.Dtos.BorrowingDtos;
using LibraryManagementSys.Models;
using LibraryManagementSys.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public BorrowingController(IUnitOfWork u)
        {
            this.u = u;
        }
        [HttpPost]
        public IActionResult CreateBorrowing(CreateBorrowingDto dto)
        {
            var mem = u.Member.GetById(dto.MemberId);
            if (mem == null)
            {
                return NotFound("Member Not Found");
            }

            var book = u.Book.GetById(dto.BookId);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            var available = book.IsAvailable;

            if (available == false)
            {
                return BadRequest("Book is Not Available");
            }

            var data = new Borrowing
            {
                MemberId = dto.MemberId,
                BookId = dto.BookId,
                BorrowData = DateTime.Now,
                ReturnDate = null

            };
            u.Borrowing.Add(data);
            available = false;
            u.Save();

            return NoContent();

        }

        [HttpGet]
        public IActionResult GetAllBorrowings()
        {
            var data = u.Borrowing.GetAllBorrowings();

            return Ok(data);
        }
        [HttpPut("{id}/Return")]
        public IActionResult ReturnBook(int id)
        {
            var borr = u.Borrowing.GetById(id);
            if (borr == null)
            {
                return NotFound("Borrowing Not Found");
            }
            if (borr.ReturnDate != null)
            {
                return BadRequest("Book AlredyReturned");
            }
            var book = u.Book.GetById(borr.BookId);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }
            borr.ReturnDate = DateTime.Now;
            book.IsAvailable = true;

            u.Save();
            return NoContent();
        }
    }
}

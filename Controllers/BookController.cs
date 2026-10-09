using LibraryManagementSys.Dtos.BookDtos;
using LibraryManagementSys.Models;
using LibraryManagementSys.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public BookController(IUnitOfWork u)
        {
            this .u = u;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = u.Book.GetAll();
            return Ok(data);
        }
        [HttpGet("Search")]
        public IActionResult Search(string Word)
        {
            var data = u.Book.Search(Word);
            return Ok(data);
        }
        [HttpGet("MostExpinsive")]
        public IActionResult MostExpinsive()
        {
            var data = u.Book.MostExpinsive();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddBook(CreateBookDto dto)
        {
            var cate=u.Category.GetById(dto.CategoryId);
            if (cate == null)
            {
                return NotFound("CAtegry Not Found");
            }
            var isbnex = u.Book.GetAll().Any(a => a.ISBN == dto.ISBN);
            if (isbnex)
            {
                return BadRequest("ISBN Exists");
            }
            var data = new Book
            {
                Author = dto.Author,
                IsAvailable = dto.IsAvailable,
                ISBN = dto.ISBN,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Title = dto.Title

            };
            u.Book.Add(data);
            u.Save();

            return NoContent();
        }
    }
}

using LibraryManagementSys.Dtos.CategoryDtos;
using LibraryManagementSys.Models;
using LibraryManagementSys.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork u;

        public CategoryController(IUnitOfWork u)
        {
            this.u = u;
            
        }
        [HttpPost]
        public IActionResult CreateCatogory(CreateCatogoryDto dto)
        {
            var exi = u.Category.NameExist(dto.Name);
            if (exi == true)
            {
                return BadRequest("The Category name must be unique");
            }
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            u.Category.Add(category);
            u.Save();

            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var data = u.Category.GetAllCategories();

            return Ok(data);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var data = u.Category.HasBooks(id);
            if (data == true)
            {
                return BadRequest("Can't delete category have books");
            }
            u.Category.Delete(id);
            u.Save();
            return NoContent();
        }

    }
}

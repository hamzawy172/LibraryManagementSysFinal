using LibraryManagementSys.Data;
using LibraryManagementSys.Dtos.CategoryDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSys.CustomeRepos.CategoryRepos
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly MyContext c;
        public CategoryRepo(MyContext c) : base(c) 
        {
            this.c = c;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var data = c.Categories.Select(a => new CategoryDto
            {
                Id = a.Id,
                Name = a.Name,
                BookCount = a.Books.Count()
            }).ToList();

            return data;
        }

        public bool HasBooks(int CategoryId)
        {
            var data = c.Books.Any(a => a.CategoryId == CategoryId);

            return data;
        }

        public bool NameExist(string name)
        {
            var data = c.Categories.Any(a => a.Name == name);

            return data;
        }
    }
}

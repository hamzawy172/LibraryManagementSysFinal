using LibraryManagementSys.Dtos.CategoryDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.CategoryRepos
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        bool NameExist(string name);
        bool HasBooks(int CategoryId);
        List<CategoryDto> GetAllCategories();
        
    }
}

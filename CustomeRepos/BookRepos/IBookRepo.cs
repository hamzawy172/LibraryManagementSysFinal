using LibraryManagementSys.Dtos.BookDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.BookRepos
{
    public interface IBookRepo : IGenericRepo<Book>
    {
        List<SearchBookDto> Search(string Word);
        BookDto MostExpinsive();
        
    }
}

using LibraryManagementSys.Data;
using LibraryManagementSys.Dtos.BookDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.BookRepos
{
    public class BookRepo : GenericRepo<Book>, IBookRepo
    {
        private readonly MyContext c;
        public BookRepo(MyContext c) : base(c) 
        {
            this.c = c;
        }
        public BookDto MostExpinsive()
        {
            var data = c.Books.OrderByDescending(a => a.Price).Select(a => new BookDto
            {
                Id = a.Id,
                Author = a.Author,
                IsAvailable = a.IsAvailable,
                CategoryId = a.CategoryId,
                ISBN = a.ISBN,
                Price = a.Price,
                Title = a.Title,
            }).FirstOrDefault();
      

            return data;
        }

        public List<SearchBookDto> Search(string Word)
        {
            var data = c.Books.OrderByDescending(a => a.Title).Where(a => a.Title.Contains(Word)).Select(a => new SearchBookDto
            {
                Title = a.Title,
                Id = a.Id,
                Author = a.Author,
                Price = a.Price
            }).ToList();

            return data;
        }


    }
}

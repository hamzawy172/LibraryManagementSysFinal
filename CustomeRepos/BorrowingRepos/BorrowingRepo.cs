using LibraryManagementSys.CustomeRepos.BookRepos;
using LibraryManagementSys.Data;
using LibraryManagementSys.Dtos.BorrowingDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibraryManagementSys.CustomeRepos.BorrowingRepos
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly MyContext c;
        public BorrowingRepo(MyContext c):base(c) 
        {
            this.c = c;
        }

        public List<BorrowingDto> GetAllBorrowings()
        {
            var data = c.Borrowings.Select(b => new BorrowingDto
            {
                Id = b.Id,
                BorrowData = b.BorrowData,
                ReturnDate = b.ReturnDate,
                BookTitle = b.Book.Title,
                MemberName = b.Member.FullName
            }).OrderByDescending(a => a.BorrowData).ToList();

            return data;

        }
    }
}

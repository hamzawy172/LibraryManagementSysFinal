using LibraryManagementSys.CustomeRepos.BookRepos;
using LibraryManagementSys.CustomeRepos.BorrowingRepos;
using LibraryManagementSys.CustomeRepos.CategoryRepos;
using LibraryManagementSys.CustomeRepos.MemberRepos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IBookRepo Book {  get; }
        ICategoryRepo Category { get; }
        IMemberRepo Member { get; }
        IBorrowingRepo Borrowing { get; }
        void Save();
    }
}

using LibraryManagementSys.CustomeRepos.BookRepos;
using LibraryManagementSys.CustomeRepos.BorrowingRepos;
using LibraryManagementSys.CustomeRepos.CategoryRepos;
using LibraryManagementSys.CustomeRepos.MemberRepos;
using LibraryManagementSys.Data;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext c;
        public IBookRepo Book { get; }
        public ICategoryRepo Category { get; }
        public IMemberRepo Member { get; }
        public IBorrowingRepo Borrowing { get; }    
        public UnitOfWork(MyContext c , IBookRepo book , ICategoryRepo category , IMemberRepo member , IBorrowingRepo borrowing)
        {
            this.c = c;
            Book=book;
            Category=category;
            Member=member;
            Borrowing=borrowing;
        }
        public void Save()
        {
            c.SaveChanges();
        }

    }
}

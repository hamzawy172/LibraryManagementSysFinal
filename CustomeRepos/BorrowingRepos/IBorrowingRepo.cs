using LibraryManagementSys.Dtos.BorrowingDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.BorrowingRepos
{
    public interface IBorrowingRepo : IGenericRepo<Borrowing>
    {
        List<BorrowingDto> GetAllBorrowings();
    }
}

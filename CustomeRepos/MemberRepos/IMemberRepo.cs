using LibraryManagementSys.Dtos.MemberDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.MemberRepos
{
    public interface IMemberRepo : IGenericRepo<Member>
    {
        bool EmailExists(string email);
        List<TopReaderDto> GetTopReader();
        Statistics GetMemberStatistics(int Id);

    }
}

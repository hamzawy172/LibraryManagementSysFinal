using LibraryManagementSys.Data;
using LibraryManagementSys.Dtos.MemberDtos;
using LibraryManagementSys.Generic;
using LibraryManagementSys.Models;

namespace LibraryManagementSys.CustomeRepos.MemberRepos
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly MyContext c;
        public MemberRepo(MyContext c) : base(c)
        {
            this.c = c;
        }

        public bool EmailExists(string email)
        {
            var data = c.Members.Any(m => m.Email == email);

            return data;
        }

        public Statistics GetMemberStatistics(int Id)
        {
            var data = c.Members.Where(a => a.Id == Id).Select(b => new Statistics
            {
                Name = b.FullName,
                currentlyborrowedbooks = b.borrowings.Count(s => s.ReturnDate == null),
                returnedbooks = b.borrowings.Count(a => a.ReturnDate != null),
                totalborrowedbooks = b.borrowings.Count()
            }).FirstOrDefault();

            return data;
        }

        public List<TopReaderDto> GetTopReader()
        {
            var data = c.Members.Select(a => new TopReaderDto
            {
                Id = a.Id,
                Email = a.Email,
                Phone = a.Phone,
                FullName = a.FullName,
                BorrowingCount = a.borrowings.Count()
            }).OrderByDescending(s=>s.BorrowingCount).Take(5).ToList();

            return data;
        }
    }
}

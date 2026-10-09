using LibraryManagementSys.Dtos.MemberDtos;
using LibraryManagementSys.Models;
using LibraryManagementSys.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public MemberController(IUnitOfWork u)
        {
            this.u = u;
        }
        [HttpPost]
        public IActionResult CreateMember(CreateMemberDto dto)
        {
            var exi = u.Member.EmailExists(dto.Email);
            if (exi == true)
            {
                return BadRequest("The Email Already Exists");
            }
            var data = new Member
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
            };
            u.Member.Add(data);
            u.Save();

            return NoContent();
        }
        [HttpGet("Top-Readers")]
        public IActionResult GetTopReaders()
        {
            var data = u.Member.GetTopReader();
            if (data == null)
            {
                return NotFound("There Is No members To Get");
            }

            return Ok(data);
        }
        [HttpGet("{id}/Statistics")]
        public IActionResult GetStatistics(int id)
        {
            var mem = u.Member.GetById(id);
            if (mem == null)
            {
                return NotFound("The member Id Not Found");
            }

            var data = u.Member.GetMemberStatistics(id);

            return Ok(data);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentsList.API.DTO;
using PaymentsList.DataAccess;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly PaymentListDBContext _context;

        public GroupController(PaymentListDBContext context)
        {
            _context = context;
            //_context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Group> GetGroups()
        {
            return _context.Groups.AsNoTracking();
        }

        [HttpGet("{id}")]
        public async Task<Group> GetGroup(int id)
        {
            return await _context.Groups.AsNoTracking().SingleAsync(Group => Group.Id == id);
        }

        [HttpPost]
        public async Task<int> PostGroup(GroupPostDTO GroupDto)
        {
            var Group = new Group { Name = GroupDto.Name };

            if (GroupDto.UserId != null)
            {
                var users = _context.Users.Where(user => GroupDto.UserId.Contains(user.Id));
                Group.User = await users.ToListAsync();
            }

            await _context.Groups.AddAsync(Group);
            await _context.SaveChangesAsync();

            return Group.Id;
        }
    }
}

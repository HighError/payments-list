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
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groupsWithUsers = _context.Groups.AsNoTracking()
                .Select(group => new GroupGetDTO
                {
                    Id = group.Id,
                    Name = group.Name,
                    Users = group.User.Select(g => g.Id).ToList()
                }).ToList();

            return Ok(groupsWithUsers);
        }

        [HttpGet("{id}")]
        public async Task<Group> GetGroup(int id)
        {
            return await _context.Groups.AsNoTracking().SingleAsync(Group => Group.Id == id);
        }

        [HttpPost]
        public async Task<string> PostGroup(GroupPostDTO GroupDto)
        {
            var Group = new Group { Name = GroupDto.Name };
            if (Group.Name == "")
            {
                return "Error creating group!";
            }

            if (GroupDto.UserId != null && Group.Name != "")
            {
                var users = _context.Users.Where(user => GroupDto.UserId.Contains(user.Id));
                Group.User = await users.ToListAsync();
            }

            await _context.Groups.AddAsync(Group);
            await _context.SaveChangesAsync();
            return $"Group {Group.Name} created. Group ID: {Group.Id}";
        }

        [HttpDelete]
        public async Task<string> DeleteGroup(int id)
        {
            var group = _context.Groups.Where(x => x.Id == id).SingleOrDefault();
            if (group == null) return "Group not found!";

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return "Group has successfully deleted!";
        }
    }
}

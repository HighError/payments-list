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
    public class UserController : Controller
    {
        private readonly PaymentListDBContext _context;

        public UserController(PaymentListDBContext context)
        {
            _context = context;
            //_context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetUsers()
        { 
            //var usersWithoutGroups = _context.Users.AsNoTracking().ToList();

            var usersWithGroups = _context.Users.AsNoTracking()
                .Select(user => new UserGetDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Groups = user.Groups.Select(g => g.Id).ToList()
                }).ToList();

            return Ok(usersWithGroups);
        }

        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _context.Users.AsNoTracking().SingleAsync(User => User.Id == id);
        }

        [HttpPost]
        public async Task<int> PostUser(UserPostDTO UserDto)
        {
            var User = new User { Name = UserDto.Name };

            if (UserDto.GroupsId != null)
            {
                var groups = _context.Groups.Where(group => UserDto.GroupsId.Contains(group.Id));
                User.Groups = await groups.ToListAsync();
            }

            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            return User.Id;
        }
    }
}

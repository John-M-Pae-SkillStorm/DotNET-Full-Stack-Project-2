using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TigerPhoneAPI.Contexts;
using TigerPhoneAPI.Models;

namespace TigerPhoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TelecomContext _context;

        public UsersController(TelecomContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
        var users = await _context.Users
                  //.Where(u => u.UserId == userId)
                  //.Include(u => u.Device)
                  //.Include(u => u.Plan)
                  .ToListAsync();
        return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Plans)
                .Include(u => u.Device)
                .ToListAsync();
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'TelecomContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        [HttpPost("device")]
        public async Task<ActionResult<User>> AddDevice(AddDeviceDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newDevice = new Device
            {
                Type = request.Type,
                Model = request.Model,

            };

            _context.Devices.Add(newDevice);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("plan")]
        public async Task<ActionResult<Plan>> AddCharacterPlan(AddUserPlanDto request)
        {
            var user = await _context.Users
                .Where(u => u.Id == request.UserId)
                .Include(u => u.Plans)
                .FirstOrDefaultAsync();
            if (user == null)
                return NotFound();

            var plan = await _context.Plans.FindAsync(request.PlanId);
            if (plan == null)
                return NotFound();

            user.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return user;
        }



        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

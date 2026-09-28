using _09._14._26_DI.Models;
using _09._14._26_DI.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _09._14._26_DI.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new();

        [HttpGet] public IActionResult GetAll() => Ok(_users);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) =>
            _users.FirstOrDefault(u => u.Id == id) is User user ? Ok(user) : NotFound();

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            var user = new User
            {
                Id = _users.Count + 1,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };
            _users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserRequest request)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user is null) return NotFound();

            if (request.Name != null) user.Name = request.Name;
            if (request.Email != null) user.Email = request.Email;
            if (request.Phone != null) user.Phone = request.Phone;
            user.Updated = DateTime.Now;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user is null) return NotFound();
            _users.Remove(user);
            return NoContent();
        }
    }
}

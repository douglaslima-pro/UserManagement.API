using Microsoft.AspNetCore.Mvc;
using UserManagement.API.DTO;
using UserManagement.API.Exceptions;
using UserManagement.API.Extensions;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                throw new NotFoundException($"User ID '{id}' not found!");
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User();
            user.Id = UserManagement.API.Models.User.GenerateId();
            user.MapFromDTO(userDTO);
            users.Add(user);
            return Created($"/api/user/{user.Id}", user);
        }

        [HttpPost("{id:int}")]
        public IActionResult Update(int id, [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToUpdate = users.FirstOrDefault(user => user.Id == id);
            if (userToUpdate == null)
            {
                throw new NotFoundException($"User ID '{id}' not found!");
            }
            users.Remove(userToUpdate);
            userToUpdate.MapFromDTO(userDTO);
            users.Add(userToUpdate);
            return Ok(userToUpdate);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToDelete = users.FirstOrDefault(user => user.Id == id);
            if (userToDelete == null)
            {
                throw new NotFoundException($"User ID '{id}' not found!");
            }
            users.Remove(userToDelete);
            return NoContent();
        }
    }
}

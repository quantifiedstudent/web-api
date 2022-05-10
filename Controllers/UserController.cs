using Microsoft.AspNetCore.Mvc;
using QSWebAPI.Models;
using QSWebAPI.Services.Base;

namespace QSWebAPI.Controllers
{
    /// <summary>
    ///     Controller which takes care of the User-domain
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _service;

        public UserController(IService<User> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _service.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _service.FindAsync(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            return Ok(await _service.Add(user));
        }
        
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User request)
        {
            var dbUser = await _service.Update(request);
            if (dbUser == null)
                return NotFound("User not found");

            return request;
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var dbUser = await _service.FindAsync(id);
            if (dbUser == null)
                return NotFound("User not found");
            await _service.DeleteAsync(id);
            return Ok($"User {id} successfully removed");
        }
    }
}

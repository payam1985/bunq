using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DomainCore;
using Microsoft.AspNetCore.Mvc;

namespace Bunq.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetUser(long? id)
        {
            if (id == null || id == 0) return NotFound("user not found");
            var user = await _userRepository.GetUser(id ?? 0);
            if (user != null) return Ok(user);
            return NotFound("user not found");
        }

        [HttpPost]

        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            if (newUser != null) return Ok(user);
            ModelState.AddModelError(string.Empty, "an error occured while adding new user");
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] User user)
        {
            var editedUser = await _userRepository.Update(user);
            if (editedUser != null) return Ok(editedUser);
            ModelState.AddModelError(string.Empty, "Failed to update user");
            return BadRequest(ModelState);
        }

    }
}

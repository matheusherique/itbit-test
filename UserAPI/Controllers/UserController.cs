using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Models;
using System.Threading.Tasks;


namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserContext _userContext;

        public UserController(UserContext context)
        {
            _userContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userContext.Users.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<User> GetById(int? id)
        {
            if(id <= 0)
            {
                return NotFound("User id must be higher than zero.");
            }

            User user = _userContext.Users.FirstOrDefault(u => u.UserId == id);

            if(user == null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            if(user == null)
            {
                return NotFound("User data is not supplied");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        
            return Ok(user);
        }
        

        ~UserController()
        {
            _userContext.Dispose();
        }
    }
}
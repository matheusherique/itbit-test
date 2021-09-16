using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Cors;


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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userContext.Users.ToList();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            if(user == null)
            {
                return NotFound("User data is not supplied.");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        
            return Ok(user);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]User user)
        {
            if(user == null)
            {
                return NotFound("User data is not supplied.");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            User existingUser = _userContext.Users.FirstOrDefault(u => u.UserId == user.UserId);

            if(existingUser == null)
            {
                return NotFound("User does not exiting in the database.");
            }

            existingUser.Name = user.Name;
            existingUser.Birthday = user.Birthday;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Active = user.Active;
            existingUser.GenreFK = user.GenreFK;
            _userContext.Attach(existingUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _userContext.SaveChangesAsync();
        
            return Ok(user);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound("Id is not supplied.");
            }

            User user = _userContext.Users.FirstOrDefault(u => u.UserId == id);

            if(user == null)
            {
                return NotFound("No user found with particular id suplied");
            }

            _userContext.Users.Remove(user);

            await _userContext.SaveChangesAsync();
            return Ok("User is deleted sucessfully.");

        }
        

        ~UserController()
        {
            _userContext.Dispose();
        }
    }
}
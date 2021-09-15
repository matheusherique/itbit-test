using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Models;


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


        ~UserController()
        {
            _userContext.Dispose();
        }
    }
}
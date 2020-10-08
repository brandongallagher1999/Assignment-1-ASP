using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using test123.Models;
using test123.Services;

namespace test123.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Test123Controller : ControllerBase
    {
        private UserInfoService _userInfoService;
        public Test123Controller()
        {
            //System.Diagnostics.Debug.WriteLine("WE HAVE REACHED HERE");
            _userInfoService = new UserInfoService();
        }
        




        [HttpGet("{username}")]
        public ActionResult<User_Info> Get(string username)
        {
            var temp = _userInfoService.Get(username);
            System.Diagnostics.Debug.WriteLine("FOUND");
            return temp;
        }

        [HttpPost]
        public ActionResult<User_Info> Create(User_Info user)
        {
            var temp = _userInfoService.Create(user);
            return temp;
        }

        [HttpPut("{id}")]
        public ActionResult<User_Info> Update(string id, User_Info newUser)
        {
            _userInfoService.Update(id,newUser);
            return newUser;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var temp = _userInfoService.Get(id);
            if (!(temp == null))
            {
                _userInfoService.Remove(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}

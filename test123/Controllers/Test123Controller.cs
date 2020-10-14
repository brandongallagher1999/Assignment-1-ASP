using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
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
        

        [HttpGet]
        public ContentResult Index()
        {
            return base.Content("<h1>Brandon Gallagher 200454237</h1>", "text/html");
        }

        [HttpGet("json")]
        public ActionResult JsonData()
        {
            // /v3/covid-19/countries/canada
            const string url = "https://disease.sh";
            RestClient client = new RestClient(url);

            var request = new RestRequest("v3/covid-19/countries/canada", Method.GET);
            request.AddHeader("Accept", "application/json");

            var queryResult = client.Execute(request).Content;
            //string json = JsonConvert.SerializeObject(queryResult);
            return Content(queryResult);

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

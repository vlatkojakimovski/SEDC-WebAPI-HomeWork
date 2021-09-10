using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserWebApi.Models;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
            new User()
            {
                FirstName = "Vlatko",
                LastName = "Jakimovski",
                Age = 33
            },
            new User()
            {
                FirstName = "Bob",
                LastName = "Bobsky",
                Age = 16
            },
            new User()
            {
                FirstName = "Steve",
                LastName = "Stevesky",
                Age = 25
            },
            new User()
            {
                FirstName = "Martin",
                LastName = "Martinovski",
                Age = 30
            }
        };

        [HttpGet("users")]
        public ActionResult<List<User>> Get()
        {
            return users;
        }

        [HttpGet("user/{id}")]
        public ActionResult<User> Get (int id)
        {
            try
            {
                return users[id - 1];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound($"The user with id: {id-1} does not exist in users list - {ex.Message}");
            }
        }

        [HttpGet("useradult/{id}")]
        public ActionResult<string> GetUserAdult(int id)
        {

            try
            {
                User temp = users[id - 1];

                if (temp.Age >= 18)
                {
                    return $"The user: {temp.FirstName} {temp.LastName} is {temp.Age} years old. He is adult.";
                }
                else
                {
                    return $"The user: {temp.FirstName} {temp.LastName} is {temp.Age} years old. He is NOT adult.";
                }
   
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound($"The user with id: {id - 1} does not faund - {ex.Message}");
            }
        }
    }
}

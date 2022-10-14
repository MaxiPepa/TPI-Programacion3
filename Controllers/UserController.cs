using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;

namespace TPI_Programación3.Controllers
{
    public class UserController : Controller
    {
        public static List<User> _users = new()
        {
            new User(1, "Alejo", "alejo@gmail.com", "123", "Common"),
            new User(2, "Gaston", "gaston_elcapo@gmail.com", "abc", "Common"),
            new User(3, "Maxi", "elmassi@gmail.com", "789", "Common"),
            new User(4, "Milton", "milton_tucson_tuki@gmail.com", "qwe", "Administrator"),
            new User(5, "Pedro", "pedrito@gmail.com", "cxz", "Administrator"),
        };

        [HttpGet("[controller]/ListUsers")]
        public IActionResult ListUsers()
        {
            List<UserResponse> userList = new();

            foreach (var user in _users)
            {
                UserResponse response = new ()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role
                };

                userList.Add(response);
            }

            return Created("List of users", userList);
        }

        [HttpDelete("[controller]/DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _users.Find(u => u.Id == id);

                if(user == null)
                {
                    throw new Exception();
                } else
                {
                    _users.Remove(user);
                    return Created("Succesfully deleted", user);

                }
            }
            catch
            {
                return Problem("User not found");
            }
        }

        [HttpPost("[controller]/AddUser")]
        public IActionResult AddUser(AddUserRequest dto)
        {
            try
            {
                User user = new(_users.Max(x => x.Id) + 1, dto.FullName, dto.Email, dto.Password, dto.Role);

                UserResponse response = new()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role
                };

                _users.Add(user);
                return Created("Succesfully created!", response);
            }
            catch(Exception error)
            {
                return Problem(error.Message);
            }
        }

    }
}
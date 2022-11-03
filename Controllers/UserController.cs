using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;
using TPI_Programación3.Repository;

namespace TPI_Programación3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("listAll")]
        public IActionResult ListAll()
        {
            List<User> users = _userRepository.GetAll();
            List<UserResponse> userList = new();

            foreach (var user in users)
            {
                UserResponse response = new()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role
                };

                userList.Add(response);
            }

            return Created("List of users", userList);
        }

        [HttpGet]
        [Route("listOne/{id}")]
        public IActionResult ListOne(int id)
        {
            try
            {
                User? user = _userRepository.GetOne(id);

                if (user != null)
                {
                    UserResponse response = new()
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Role = user.Role
                    };

                    return Ok(response);
                }
                else
                {
                    throw new Exception();
                }
            } 
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }

        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(AddUserRequest dto)
        {
            try
            {
                List<User> users = _userRepository.GetAll();
                User user = new(users.Max(x => x.Id) + 1, dto.FullName, dto.Email, dto.Password, dto.Role);

                UserResponse response = new()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role
                };

                _userRepository.Add(user);
                return Created("Succesfully created!", response);
            }
            catch(Exception error)
            {
                return Problem(error.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok("Succesfully deleted");

            }
            catch
            {
                return Problem("User not found");
            }
        }

        [HttpPut]
        [Route("changePassword/{id}/{newPassword}")]
        public IActionResult Edit(int id, string newPassword)
        {
            try
            {
                _userRepository.Edit(id, newPassword);
                return Ok("Succesfully edited");
            }
            catch
            {
                return Problem("Offer not found");
            }
        }
    }
}
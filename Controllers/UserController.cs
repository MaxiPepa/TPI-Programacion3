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
    [Authorize]
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

            return Ok(userList);
        }

        [HttpGet]
        [Route("listOne/{id}")]
        public IActionResult ListOne(int id)
        {
            try
            {
                User? user = _userRepository.GetOne(id);

                UserResponse response = new()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role
                };

                return Ok(response);
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

                ValidateUsedEmail(users, dto.Email);

                User user = new()
                {
                    FullName=dto.FullName,
                    Email=dto.Email,
                    Password=dto.Password,
                    Role=dto.Role,
                };

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
            catch (Exception error)
            {
                return Problem(error.Message);
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
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }

        [NonAction]
        public void ValidateUsedEmail(List<User> users, string email)
        {
            var isUsed = users.FirstOrDefault(u => u.Email == email);
            if (isUsed != null)
            {
                throw new Exception("Email already in use.");
            }
        }
    }
}
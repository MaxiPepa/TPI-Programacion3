using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Controllers
{
    public class UserController : Controller
    {
        List<User> _users = new()
        {
            new User(1, "Alejo", "alejo@gmail.com", "123", "Common"),
            new User(2, "Gaston", "gaston_elcapo@gmail.com", "abc", "Common"),
            new User(3, "Maxi", "elmassi@gmail.com", "789", "Common"),
            new User(4, "Milton", "milton_tucson_tuki@gmail.com", "qwe", "Administrator"),
            new User(5, "Pedro", "pedrito@gmail.com", "cxz", "Administrator"),
        };

        [HttpGet("[controller]/ListUsers")]
        public IEnumerable<User> ListUsers()
        {
            return _users;
        }

        [HttpDelete("[controller]/DeleteUser/{id}")]
        public IEnumerable<User> Delete(int id)
        {
            var user = _users.Find(u => u.Id == id);
            Console.WriteLine(user);

            if (user == null)
            {
                return _users;
            }
            else
            {
                this._users.Remove(user);
                return _users;
            }
        }

        [HttpPost("[controller]/Add/{id}/{fullName}/{email}/{password}/{role}")]
        public IEnumerable<User> Add(int id, string fullName, string email, string password, string role)
        {
            this._users.Add(new User(id, fullName, email, password, role));
            return _users;
        }

    }
}
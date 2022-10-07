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

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult DeleteEX(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpDelete("[controller]/DeleteUser/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = _users.Find(u => u.Id == id);
                if (user == null)
                {
                    return View();
                }
                else
                {
                    _users.Remove(user);
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("[controller]/ListUsers")]
        public IEnumerable<User> ListUsers()
        {
            return _users;
        }
    }
}
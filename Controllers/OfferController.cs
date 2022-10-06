using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Controllers
{
    public class OfferController : Controller
    {
        // GET: OfferController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OfferController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferController/Create
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

        // GET: OfferController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OfferController/Edit/5
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

        // GET: OfferController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OfferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        [HttpGet("[controller]/ListOffer")]
        public IEnumerable<Offer> ListOffer()
        {
            return Enumerable.Range(1, 5).Select(index => new Offer
            {
                Name = "Licuadora",
                Description = "Es literalmente una licuadora",
                Category = "Electrodoméstico",
                ImgLink = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.istockphoto.com%2Fes%2Ffotos%2Flicuadora&psig=AOvVaw1Xo6fC2dqLh9_8zqD8AGuJ&ust=1665099769965000&source=images&cd=vfe&ved=0CAkQjRxqFwoTCNCMkJWiyvoCFQAAAAAdAAAAABAD",
                CreatorEmail = "juanrodriguez@gmail.com",
                PreferedItem = "Batidora"
            })
            .ToArray();
        }
    }
}
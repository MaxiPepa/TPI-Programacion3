using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Controllers
{
    public class OfferController : Controller
    {

        List<Offer> _offers = new()
        {

            new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
            new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
            new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
            new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
            new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial"),
        };

        [HttpGet("[controller]/ListOffer")]
        public IEnumerable<Offer> ListOffer()
        {
            return _offers;
        }

        [HttpDelete("[controller]/DeleteOffer/{id}")]
        public IEnumerable<Offer> Delete(int id)
        {
            var offer = _offers.Find(u => u.Id == id);

            if (offer == null)
            {
                return _offers;
            }
            else
            {
                _offers.Remove(offer);
                return _offers;
            }
        }

        [HttpPost("[controller]/AddOffer/{id}/{name}/{description}/{category}/{imgLink}/{creatorEmail}/{preferedItem}")]
        public IEnumerable<Offer> Add(int id, string name, string description, string category, string imgLink, string creatorEmail, string? preferedItem)
        {
            _offers.Add(new Offer(id, name, description, category, imgLink, creatorEmail, preferedItem));
            return _offers;
        }
    }
}
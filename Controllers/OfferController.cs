using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;

namespace TPI_Programación3.Controllers
{
    public class OfferController : Controller
    {

        public static List<Offer> _offers = new()
        {

            new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
            new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
            new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
            new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
            new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial"),
        };

        [HttpGet("[controller]/ListOffer")]
        public IActionResult ListOffers()
        {
            List<OfferResponse> offerList = new();

            foreach (var offer in _offers)
            {
                OfferResponse response = new()
                {
                    Name = offer.Name,
                    Description = offer.Description,
                    Category = offer.Category,
                    ImgLink = offer.ImgLink,
                    CreatorEmail = offer.CreatorEmail,
                    PreferedItem = offer.PreferedItem
                };

                offerList.Add(response);
            }

            return Created("List of users", offerList);
        }

        [HttpDelete("[controller]/DeleteOffer")]
        public IActionResult DeleteOffer(int id)
        {
            try
            {
                var offer = _offers.Find(u => u.Id == id);

                if (offer == null)
                {
                    throw new Exception();
                }
                else
                {
                    _offers.Remove(offer);
                    return Created("Succesfully deleted", offer);

                }
            }
            catch
            {
                return Problem("Offer not found");
            }
        }

        [HttpPost("[controller]/AddOffer")]
        public IActionResult AddOffer(AddOfferRequest dto)
        {
            try
            {
                Offer offer = new(_offers.Max(x => x.Id), dto.Name, dto.Description, dto.Category, dto.ImgLink, dto.CreatorEmail, dto.PreferedItem);

                OfferResponse response = new()
                {
                    Name = offer.Name,
                    Description = offer.Description,
                    Category = offer.Category,
                    ImgLink = offer.ImgLink,
                    CreatorEmail = offer.CreatorEmail,
                    PreferedItem = offer.PreferedItem
                };

                _offers.Add(offer);
                return Created("Succesfully created!", response);
            }
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }
    }
}
using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private List<Offer> storedOffers = new()
        {
            new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
            new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
            new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
            new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
            new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial"),
        };
        
        public List<Offer> GetAll()
        {
            return storedOffers;
        }
        public void Add(Offer offer)
        {
            storedOffers.Add(offer);
        }
        public void Delete(int id)
        {
            storedOffers.Remove(storedOffers.First(x=> x.Id == id));
        }

        public void Edit(int id, string newValue, string field)
        {
            switch (field)
            {
                case "name":
                    storedOffers.First(x => x.Id == id).Name = newValue;
                    break;
                case "description":
                    storedOffers.First(x => x.Id == id).Description = newValue;
                    break;
                case "category":
                    storedOffers.First(x => x.Id == id).Category = newValue;
                    break;
                case "img":
                    storedOffers.First(x => x.Id == id).ImgLink = newValue;
                    break;
                case "email":
                    storedOffers.First(x => x.Id == id).CreatorEmail = newValue;
                    break;
                case "preference":
                    storedOffers.First(x => x.Id == id).PreferedItem = newValue;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}

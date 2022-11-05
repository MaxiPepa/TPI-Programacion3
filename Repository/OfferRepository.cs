using TPI_Programación3.DBContext;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public class OfferRepository : IOfferRepository
    {

        private readonly TridentExchangeDBContext _context;

        public OfferRepository(TridentExchangeDBContext context)
        {
            _context = context;
        }

        public List<Offer> GetAll()
        {
            return _context.Offers.ToList();
        }
        public void Add(Offer offer)
        {
            try
            {
                _context.Offers.Add(offer);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error in the offer adding or invalid parameters");
            }
        }
        public void Delete(int id)
        {
            try
            {
                _context.Offers.Remove(_context.Offers.First(x=> x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Offer not found");
            }
        }

        public void Edit(int id, string newValue, string field)
        {
            try
            {
                switch (field)
                {
                    case "name":
                        _context.Offers.First(x => x.Id == id).Name = newValue;
                        break;
                    case "description":
                        _context.Offers.First(x => x.Id == id).Description = newValue;
                        break;
                    case "category":
                        _context.Offers.First(x => x.Id == id).Category = newValue;
                        break;
                    case "img":
                        _context.Offers.First(x => x.Id == id).ImgLink = newValue;
                        break;
                    case "email":
                        _context.Offers.First(x => x.Id == id).CreatorEmail = newValue;
                        break;
                    case "preference":
                        _context.Offers.First(x => x.Id == id).PreferedItem = newValue;
                        break;
                    default:
                        throw new Exception();
                }
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Offer not found or invalid parameters");
            }
        }
    }
}

using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public interface IOfferRepository
    {
        public List<Offer> GetAll();

        public void Add(Offer offer);

        public void Delete(int id);

        public void Edit(int id, string newValue, string field);
    }
}

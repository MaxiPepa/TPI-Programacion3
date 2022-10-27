using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();

        public void Add(Category category);

        public void Delete(string name);

        public void EditName(int id, string newValue);
        public void EditOfferQuantity(int id, int newValue);
    }
}

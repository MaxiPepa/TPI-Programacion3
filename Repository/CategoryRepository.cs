using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> storedCategories = new()
        {
            new Category(1, "Electrodomésticos", 10),
            new Category(2, "Vehiculo", 5),
            new Category(3, "Inmueble", 2),
            new Category(4, "Mundial", 20)
        };

        public List<Category> GetAll()
        {
            return storedCategories;
        }

        public void Add(Category category)
        {
            storedCategories.Add(category);
        }

        public void Delete(string name)
        {
            storedCategories.Remove(storedCategories.First(x => x.Name == name));
        }

        public void EditName(int id, string newValue)
        {
            try
            {
                storedCategories.First(x => x.Id == id).Name = newValue;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void EditOfferQuantity(int id, int newValue)
        {
            try
            {
                storedCategories.First(x => x.Id == id).OfferQuantity = newValue;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}


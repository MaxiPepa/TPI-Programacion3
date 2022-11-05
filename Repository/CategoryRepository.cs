using TPI_Programación3.DBContext;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TridentExchangeDBContext _context;

        public CategoryRepository(TridentExchangeDBContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Add(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error in the category adding or invalid parameters");
            }
        }

        public void Delete(string name)
        {
            try
            {
                _context.Categories.Remove(_context.Categories.First(x => x.Name == name));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Category not found");
            }
        }

        public void EditName(int id, string newValue)
        {
            try
            {
                _context.Categories.First(x => x.Id == id).Name = newValue;
                _context.SaveChanges ();
            }
            catch
            {
                throw new Exception("Category not found or invalid parameters");
            }
        }

        public void EditOfferQuantity(int id, int newValue)
        {
            try
            {
                _context.Categories.First(x => x.Id == id).OfferQuantity = newValue;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Category not found or invalid parameters");
            }
        }
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;

namespace TPI_Programación3.Controllers
{
    public class CategoryController : Controller
    {
        static List<Offer> _offers = new()
        {
            new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
            new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
            new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
            new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
            new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial"),
        };

        List<Category> _categories = new()
        {
            new Category("Electrodomésticos", _offers),
            new Category("Vehiculo", _offers),
            new Category("Inmueble", _offers),
            new Category("Mundial", _offers)
        };

        [HttpGet("[controller]/ListCategories")]
        public IEnumerable<Category> List()
        {
            return _categories;
        }

        [HttpDelete("[controller]/DeleteCategory/{name}")]
        public IEnumerable<Category> Delete(string name)
        {
            var category = _categories.Find(u => u.Name == name);

            if (category == null)
            {
                return _categories;
            }
            else
            {
                _categories.Remove(category);
                return _categories;
            }
        }

        [HttpPost("[controller]/AddCategory/{name}")]
        public IEnumerable<Category> Add(string name)
        {
            _categories.Add(new Category(name, null));
            return _categories;
        }
    }
}
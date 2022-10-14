using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;

namespace TPI_Programación3.Controllers
{
    public class CategoryController : Controller
    {
        public static List<Offer> _offers = new()
        {
            new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
            new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
            new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
            new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
            new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial"),
        };

        public static List<Category> _categories = new()
        {
            new Category("Electrodomésticos", _offers),
            new Category("Vehiculo", _offers),
            new Category("Inmueble", _offers),
            new Category("Mundial", _offers)
        };

        [HttpGet("[controller]/ListCategories")]
        public IActionResult ListCategories()
        {
            List<String> categoryNameList = new();

            foreach (var category in _categories)
            {
                CategoryResponse response = new()
                {
                    Name = category.Name,
                    Offers = null
                };

                categoryNameList.Add(response.Name);
            }

            return Created("List of categories", categoryNameList);
        }

        [HttpDelete("[controller]/DeleteCategory")]
        public IActionResult DeleteCategory(string name)
        {
            try
            {
                var category = _categories.Find(u => u.Name == name);

                if (category == null)
                {
                    throw new Exception();
                }
                else
                {
                    _categories.Remove(category);
                    return Created("Succesfully deleted", category.Name);

                }
            }
            catch
            {
                return Problem("Category not found");
            }
        }

        [HttpPost("[controller]/AddCategory")]
        public IActionResult AddCategory(AddCategoryRequest dto)
        {
            try
            {
                Category category = new(dto.Name, dto.Offers);

                CategoryResponse response = new()
                {
                    Name = dto.Name,
                    Offers = dto.Offers
                };

                _categories.Add(category);
                return Created("Succesfully created!", response);
            }
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }
    }
}
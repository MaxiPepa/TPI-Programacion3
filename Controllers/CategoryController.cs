using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;
using TPI_Programación3.Repository;

namespace TPI_Programación3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("listCategories")]
        public IActionResult ListCategories()
        {
            List<Category> categories = _categoryRepository.GetAll();
            List<CategoryResponse> categoryList = new();

            foreach (var category in categories)
            {
                CategoryResponse response = new()
                {
                    Name = category.Name,
                    OfferQuantity = category.OfferQuantity
                };

                categoryList.Add(response);
            }

            return Created("List of categories", categoryList);
        }

        [HttpDelete]
        [Route("deleteCategory/{name}")]
        public IActionResult DeleteCategory(string name)
        {
            try
            {
                _categoryRepository.Delete(name);
                return Ok("Succesfully deleted");
            }
            catch
            {
                return Problem("Category not found");
            }
        }

        [HttpPost]
        [Route("addCategories")]
        public IActionResult AddCategory(AddCategoryRequest dto)
        {
            try
            {
                List<Category> categories = _categoryRepository.GetAll();
                Category category = new(categories.Max(x => x.Id) + 1, dto.Name, dto.OfferQuantity);

                CategoryResponse response = new()
                {
                    Name = dto.Name,
                    OfferQuantity = dto.OfferQuantity
                };

                _categoryRepository.Add(category);
                return Created("Succesfully created!", response);
            }
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }

        [HttpPut]
        [Route("editCategoryName/{id}/{newValue}")]
        public IActionResult EditName(int id, string newValue)
        {
            try
            {
                _categoryRepository.EditName(id, newValue);
                return Ok("Succesfully edited");
            }
            catch
            {
                return Problem("Category not found");
            }
        }

        [HttpPut]
        [Route("editCategoryQuantity/{id}/{newValue}")]
        public IActionResult EditOfferQuantity(int id, int newValue)
        {
            try
            {
                _categoryRepository.EditOfferQuantity(id, newValue);
                return Ok("Succesfully edited");
            }
            catch
            {
                return Problem("Category not found");
            }
        }
    }
}
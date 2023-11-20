using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWork.Models;

namespace TestWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private List<Category> categories;

        public CategoryController()
        {
            categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Animals", ParentCategoryId = null },
                new Category { CategoryId = 2, CategoryName = "Home", ParentCategoryId = 1 },
                new Category { CategoryId = 3, CategoryName = "Wild", ParentCategoryId = 1 },
                new Category { CategoryId = 4, CategoryName = "Dog", ParentCategoryId = 2 },
                new Category { CategoryId = 5, CategoryName = "Cat", ParentCategoryId = 2 },
                new Category { CategoryId = 6, CategoryName = "Lion", ParentCategoryId = 3 },
                new Category { CategoryId = 7, CategoryName = "Wolf", ParentCategoryId = 3}
            };
        }

        [Route("all")]
        public IEnumerable<Category> GetCategories()
        {
            var result = BuildCategoryHierarchy(null);
            return result;

        }

        public List<Category> BuildCategoryHierarchy(int? parentCategoryId)
        {
            return categories.Where(c => c.ParentCategoryId == parentCategoryId)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    ParentCategoryId = c.ParentCategoryId,
                    Subcategories = BuildCategoryHierarchy(c.CategoryId)
                })
                .ToList();
        }
    }
}

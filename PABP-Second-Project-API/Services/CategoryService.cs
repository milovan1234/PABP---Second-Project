using DAL.Models;
using DAL.Repositories;

namespace PABP_Second_Project_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            this._categoriesRepository = categoriesRepository;
        }

        public Category CreateCategory(Category category)
        {
            if (category.CategoryName == "")
            {
                throw new Exception("The category name must be filled in.");
            }
            this._categoriesRepository.Add(category);

            return this._categoriesRepository.GetById(category.CategoryId);
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = this.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new Exception("The category with given category Id does not exist.");
            }

            this._categoriesRepository.Delete(categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return this._categoriesRepository.GetAll();
        }

        public Category GetCategoryById(int categoryId)
        {
            return this._categoriesRepository.GetById(categoryId);
        }

        public Category UpdateCategory(int categoryId, Category category)
        {
            if (category.CategoryName == "")
            {
                throw new Exception("The category name must be filled in.");
            }

            this._categoriesRepository.Edit(category);

            return this._categoriesRepository.GetById(categoryId);
        }
    }
}

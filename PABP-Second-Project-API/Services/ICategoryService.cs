using DAL.Models;

namespace PABP_Second_Project_API.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category UpdateCategory(int categoryId, Category category);
        void DeleteCategory(int categoryId);
        Category CreateCategory(Category category);
    }
}

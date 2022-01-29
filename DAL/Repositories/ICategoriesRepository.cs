using DAL.Models;

namespace DAL.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int categoryId);
        void Add(Category category);
        void Delete(int categoryId);
        void Edit(Category category);
    }
}

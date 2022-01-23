using DAL.Models;

namespace DAL.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAll();
    }
}

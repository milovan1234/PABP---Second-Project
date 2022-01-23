using DAL.Models;

namespace DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private NorthwindContext _context;
        public CategoriesRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return this._context.Categories;
        }
    }
}

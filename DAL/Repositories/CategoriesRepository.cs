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

        public void Add(Category category)
        {
            this._context.Categories.Add(category);
            this._context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            Category? category = this._context.Categories.SingleOrDefault(x => x.CategoryId == categoryId);
            if (category == null)
            {
                throw new Exception("Category does not exist.");
            }
            this._context.Categories.Remove(category);
            this._context.SaveChanges();
        }

        public void Edit(Category category)
        {
            this._context.Categories.Update(category);
            this._context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return this._context.Categories;
        }

        public Category GetById(int categoryId)
        {
            return this._context.Categories.Single(x => x.CategoryId == categoryId);
        }
    }
}

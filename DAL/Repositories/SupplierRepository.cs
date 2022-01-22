using DAL.Models;

namespace DAL.Repositories
{
    public class SupplierRepository : ISuppliersRepository
    {
        private NorthwindContext _context;
        public SupplierRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return this._context.Suppliers;
        }
    }
}

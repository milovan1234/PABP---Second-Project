using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
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

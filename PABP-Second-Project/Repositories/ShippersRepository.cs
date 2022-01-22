using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public class ShippersRepository : IShippersRepository
    {
        private NorthwindContext _context;
        public ShippersRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return this._context.Shippers;
        }
    }
}

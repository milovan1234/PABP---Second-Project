using DAL.Models;

namespace DAL.Repositories
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

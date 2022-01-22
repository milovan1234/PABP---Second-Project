using DAL.Models;

namespace DAL.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private NorthwindContext _context;
        public CustomersRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return this._context.Customers;
        }
    }
}

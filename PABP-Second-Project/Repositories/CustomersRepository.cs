using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
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

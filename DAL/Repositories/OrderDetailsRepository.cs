using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private NorthwindContext _context;
        public OrderDetailsRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return this._context.OrderDetails.Include(x => x.Product);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private NorthwindContext _context;
        public OrdersRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return this._context.Orders.Include(x => x.Customer).Include(x => x.Employee).Include(x => x.ShipViaNavigation);
        }

        public Order GetById(int orderId)
        {
            return this._context.Orders.Include(x => x.Customer).Include(x => x.Employee).Include(x => x.ShipViaNavigation).Single(x => x.OrderId == orderId);
        }

        public void Add(Order order)
        {
            this._context.Orders.Add(order);
            this._context.SaveChanges();
        }

        public void Delete(int orderId)
        {
            Order? order = this._context.Orders.SingleOrDefault(x => x.OrderId == orderId);
            if (order == null)
            {
                throw new Exception("Order does not exist.");
            }
            this._context.Orders.Remove(order);
            this._context.SaveChanges();
        }

        public void Edit(Order order)
        {
            this._context.Orders.Update(order);
            this._context.SaveChanges();
        }
    }
}

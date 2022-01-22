using DAL.Models;

namespace DAL.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int orderId);
        void Add(Order order);
        void Delete(int orderId);
        void Edit(Order order);
    }
}

using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
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

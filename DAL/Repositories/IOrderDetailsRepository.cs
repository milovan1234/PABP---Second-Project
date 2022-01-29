using DAL.Models;

namespace DAL.Repositories
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetail> GetAll();
    }
}

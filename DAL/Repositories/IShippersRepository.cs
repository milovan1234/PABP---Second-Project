using DAL.Models;

namespace DAL.Repositories
{
    public interface IShippersRepository
    {
        IEnumerable<Shipper> GetAll();
    }
}

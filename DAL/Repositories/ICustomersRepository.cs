using DAL.Models;

namespace DAL.Repositories
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
    }
}

using DAL.Models;

namespace DAL.Repositories
{
    public interface ISuppliersRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int supplierId);
    }
}

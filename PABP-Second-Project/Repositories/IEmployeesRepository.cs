using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        void Add(Employee employee);
        void Delete(int employeeId);
        void Edit(Employee employee);
    }
}

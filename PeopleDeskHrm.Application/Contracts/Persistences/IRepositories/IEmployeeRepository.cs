using PeopleDeskHrm.Domain;
using System.Linq.Expressions;

namespace PeopleDeskHrm.Application.Contracts.Persistences.IRepositories;

public interface IEmployeeRepository : IGenericRepository<Employee,Guid>
{
    IQueryable<Employee> GetEmployeesWithDetails(Expression<Func<Employee, bool>> filter);
}

using PeopleDeskHrm.Application.Common.QueryFilters.EmployeeQueryBuilders;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;

namespace PeopleDeskHrm.Application.Features.Employee.GetById;

public class GetByIdEmployeeRequest : IRequest<GetEmployeeByIdResponse?>
{
    public Guid Id { get; set; }
}

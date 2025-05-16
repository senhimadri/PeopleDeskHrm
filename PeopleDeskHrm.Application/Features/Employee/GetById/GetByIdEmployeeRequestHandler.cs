using PeopleDeskHrm.Application.Common.Mappers;
using PeopleDeskHrm.Application.Contracts.Persistences;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PeopleDeskHrm.Application.Features.Employee.GetById;

public class GetByIdEmployeeRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdEmployeeRequest, GetEmployeeByIdResponse?>
{
    public async Task<GetEmployeeByIdResponse?> Handle(GetByIdEmployeeRequest request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.EmployeeRepository.GetEmployeesWithDetails(x=>x.Id == request.Id);

        var employee = await query.ToGetByIdResponse().FirstOrDefaultAsync();

        return employee;
    }
}

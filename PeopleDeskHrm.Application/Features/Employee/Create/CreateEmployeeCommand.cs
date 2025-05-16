using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;
using PeopleDeskHrm.Application.Helpers.Results;

namespace PeopleDeskHrm.Application.Features.Employee.Create;

public class CreateEmployeeCommand : IRequest<Result>
{
    public CreateEmployeePayload Payload { get; set; } = default!;
}

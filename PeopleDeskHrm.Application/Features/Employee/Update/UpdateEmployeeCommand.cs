using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;
using PeopleDeskHrm.Application.Helpers.Results;

namespace PeopleDeskHrm.Application.Features.Employee.Update;

public class UpdateEmployeeCommand : IRequest<Result>
{
    public Guid Id { get; set; }
    public UpdateEmployeePayload Payload { get; set; } = default!;
}

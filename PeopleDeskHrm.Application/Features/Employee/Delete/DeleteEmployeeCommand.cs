using MediatR;
using PeopleDeskHrm.Application.Helpers.Results;

namespace PeopleDeskHrm.Application.Features.Employee.Delete;

public class DeleteEmployeeCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}

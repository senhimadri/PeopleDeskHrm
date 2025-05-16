using PeopleDeskHrm.Application.Contracts.Persistences;
using MediatR;
using PeopleDeskHrm.Application.Helpers.Results;

namespace PeopleDeskHrm.Application.Features.Employee.Delete;

public class DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmployeeCommand,Result>
{
    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await  unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (employee is null)
            return Errors.EmployeeNotFound;

        employee.IsDelete = true;

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
using PeopleDeskHrm.Application.Contracts.Persistences;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;
using PeopleDeskHrm.Application.Common.Mappers;
using FluentValidation;
using MediatR;
using PeopleDeskHrm.Application.Helpers.Results;
using PeopleDeskHrm.Application.Helpers.Extensions;

namespace PeopleDeskHrm.Application.Features.Employee.Update;

public class UpdateEmployeeCommandHandler(IUnitOfWork unitofWork) : IRequestHandler<UpdateEmployeeCommand, Result>
{
    private readonly IUnitOfWork _unitofWork = unitofWork;

    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = new UpdateEmployeePayloadValidator().Validate(request.Payload);

        if (!validationResult.IsValid)
            return validationResult.ToValidationErrorList();

        var employee = await _unitofWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (employee is null)
            return Errors.EmployeeNotFound;

        employee.UpdateEntity(request.Payload);

        _unitofWork.EmployeeRepository.Update(employee);

        await _unitofWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

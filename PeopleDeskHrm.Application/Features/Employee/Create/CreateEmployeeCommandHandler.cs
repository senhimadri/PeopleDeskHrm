using MediatR;
using PeopleDeskHrm.Application.Common.Mappers;
using PeopleDeskHrm.Application.Contracts.Persistences;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;
using PeopleDeskHrm.Application.Helpers.Extensions;
using PeopleDeskHrm.Application.Helpers.Results;

namespace PeopleDeskHrm.Application.Features.Employee.Create;

public class CreateEmployeeCommandHandler(IUnitOfWork unitofWork) : IRequestHandler<CreateEmployeeCommand, Result>
{
    private readonly IUnitOfWork _unitofWork = unitofWork;

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await  new CreateEmployeePayloadValidator()
                               .ValidateAsync(request.Payload);

        if (!validationResult.IsValid)
            return validationResult.ToValidationErrorList();

        var employee = request.Payload.ToEntity();

        _unitofWork.EmployeeRepository.Add(employee);

        await _unitofWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}


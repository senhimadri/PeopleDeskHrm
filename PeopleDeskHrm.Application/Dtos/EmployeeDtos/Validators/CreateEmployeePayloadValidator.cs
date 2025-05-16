using FluentValidation;

namespace PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;

internal class CreateEmployeePayloadValidator : AbstractValidator<CreateEmployeePayload>
{
    public CreateEmployeePayloadValidator()
    {
        Include(new EmployeeDtoValidator());
    }
}


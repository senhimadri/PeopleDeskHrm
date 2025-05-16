using FluentValidation;

namespace PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;

public class CreateEmployeePayloadValidator : AbstractValidator<CreateEmployeePayload>
{
    public CreateEmployeePayloadValidator()
    {
        Include(new EmployeeDtoValidator());
    }
}


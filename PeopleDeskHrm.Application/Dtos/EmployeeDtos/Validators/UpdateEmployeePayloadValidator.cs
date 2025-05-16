using FluentValidation;

namespace PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;

internal class UpdateEmployeePayloadValidator : AbstractValidator<UpdateEmployeePayload>
{
    public UpdateEmployeePayloadValidator()
    {
        Include(new EmployeeDtoValidator());
    }
}


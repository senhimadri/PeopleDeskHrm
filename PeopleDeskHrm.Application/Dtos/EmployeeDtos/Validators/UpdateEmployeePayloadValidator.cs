using FluentValidation;

namespace PeopleDeskHrm.Application.Dtos.EmployeeDtos.Validators;

public class UpdateEmployeePayloadValidator : AbstractValidator<UpdateEmployeePayload>
{
    public UpdateEmployeePayloadValidator()
    {
        Include(new EmployeeDtoValidator());
    }
}


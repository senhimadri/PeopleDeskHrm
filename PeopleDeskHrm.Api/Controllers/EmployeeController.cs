using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using PeopleDeskHrm.Application.Features.Employee.Create;
using PeopleDeskHrm.Application.Features.Employee.Delete;
using PeopleDeskHrm.Application.Features.Employee.GetById;
using PeopleDeskHrm.Application.Features.Employee.GetList;
using PeopleDeskHrm.Application.Features.Employee.Update;

namespace PeopleDeskHrm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController (IMediator _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeePayload payload)
    {
        var command = new CreateEmployeeCommand { Payload = payload };
        await _mediator.Send(command);
        return Created(string.Empty, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeePayload payload)
    {
        var command = new UpdateEmployeeCommand { Id = id, Payload = payload };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetByIdEmployeeRequest { Id = id };
        var result = await _mediator.Send(query);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] EmployeePaginationQuery query)
    {
        var request = new GetListEmployeeRequest
        {
            DepartmentIds = query.DepartmentIds,
            DesignationIds = query.DesignationIds,
            SearchText = query.SearchText,
        };

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteEmployeeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

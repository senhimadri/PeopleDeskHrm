using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;

namespace PeopleDeskHrm.Application.Features.Employee.GetList;

public class GetListEmployeeRequest : IRequest<List<GetEmployeesListResponse>>
{
    public List<int>? DepartmentIds { get; set; } 
    public List<int>? DesignationIds { get; set; } 
    public string? SearchText { get; set; } 
}

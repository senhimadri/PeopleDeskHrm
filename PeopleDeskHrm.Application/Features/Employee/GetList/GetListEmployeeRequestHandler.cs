using PeopleDeskHrm.Application.Common.Mappers;
using PeopleDeskHrm.Application.Common.QueryFilters.EmployeeQueryBuilders;
using PeopleDeskHrm.Application.Contracts.Persistences;
using PeopleDeskHrm.Application.Dtos.EmployeeDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PeopleDeskHrm.Application.Features.Employee.GetList;

public class GetListEmployeeRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetListEmployeeRequest, List<GetEmployeesListResponse>>
{
    public async Task<List<GetEmployeesListResponse>> Handle(GetListEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employeeFilterBuilder = new EmployeeFilterBuilder();

        var employeeFilter = employeeFilterBuilder
                            .IncludeDepartmentIdList(request.DepartmentIds)
                            .IncludeDesignationIdList(request.DesignationIds)
                            .IncludeSearchText(request.SearchText)
                            .Build();

        var employeeList = await unitOfWork.EmployeeRepository
                        .GetEmployeesWithDetails(employeeFilter)
                        .ToGetListResponse()
                        .ToListAsync();

        return employeeList;
    }
}
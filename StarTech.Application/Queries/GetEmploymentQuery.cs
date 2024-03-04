using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries
{
  
    public class GetEmploymentQuery : IRequest<List<EmploymentViewModel>>
    {
        public string? empCode { get; set; }
        public int companyID { get; set; }
     
        public class Handler : IRequestHandler<GetEmploymentQuery, List<EmploymentViewModel>>
        {
            private readonly IEmployeeService _service;

            public Handler(IEmployeeService service)
            {
                _service = service;
            }

            public async Task<List<EmploymentViewModel>> Handle(GetEmploymentQuery request, CancellationToken cancellationToken)
            {
                
                return (List<EmploymentViewModel>)await _service.GetEmployment(request.empCode, request.companyID);

            }
        }
    }

    public class EmpProfileQuery : IRequest<List<EmpProfile>>
    {
        public string? empCode { get; set; }

        public class Handler : IRequestHandler<EmpProfileQuery, List<EmpProfile>>
        {
            private readonly IEmployeeService _service;

            public Handler(IEmployeeService service)
            {
                _service = service;
            }

            public async Task<List<EmpProfile>> Handle(EmpProfileQuery request, CancellationToken cancellationToken)
            {

                return (List<EmpProfile>)await _service.GetEmployeeProfileInfo(request.empCode);

            }
        }
    }
}

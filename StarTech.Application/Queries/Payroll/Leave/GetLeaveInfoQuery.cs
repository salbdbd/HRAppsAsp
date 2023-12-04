using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
  
    public class GetLeaveInfoQuery : IRequest<List<LeaveApplyModel>>
    {
        public int CompanyID { get; set; }
        public string EmpCode { get; set; }
       
        public class Handler : IRequestHandler<GetLeaveInfoQuery, List<LeaveApplyModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveApplyModel>> Handle(GetLeaveInfoQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveInfo(request.CompanyID,request.EmpCode);
                return result;

            }
        }
    }
}

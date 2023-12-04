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
   
    public class getLeaveInfoStatusQuery : IRequest<List<LeaveStatus>>
    {
        public int CompanyID { get; set; }
        public string EmpCode { get; set; }

        public class Handler : IRequestHandler<getLeaveInfoStatusQuery, List<LeaveStatus>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveStatus>> Handle(getLeaveInfoStatusQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.getLeaveInfoStatus(request.EmpCode,request.CompanyID);
                return result;

            }
        }
    }

}

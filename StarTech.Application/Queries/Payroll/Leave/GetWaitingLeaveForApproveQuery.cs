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
   
    public class GetWaitingLeaveForApproveQuery : IRequest<List<LeaveApplyViewModel>>
    {
        public int compId { get; set; }
        public string year { get; set; }
        public string empCode { get; set; }


        public class Handler : IRequestHandler<GetWaitingLeaveForApproveQuery, List<LeaveApplyViewModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveApplyViewModel>> Handle(GetWaitingLeaveForApproveQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetWaitingLeaveForApprove(request.compId, request.year,request.empCode);
                return (List<LeaveApplyViewModel>)result;

            }
        }
    }
}

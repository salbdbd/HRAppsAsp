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
  
    public class GetLeaveInfoForHrApproveQuery : IRequest<List<LeaveApplyViewModel>>
    {
        public int compId { get; set; }
        public string ReportTo { get; set; }
      
        public class Handler : IRequestHandler<GetLeaveInfoForHrApproveQuery, List<LeaveApplyViewModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveApplyViewModel>> Handle(GetLeaveInfoForHrApproveQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveInfoForHrApprove(request.compId,request.ReportTo);
                return(List<LeaveApplyViewModel>)result;

            }
        }
    }
}



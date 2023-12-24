using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
  
    public class GetLeaveWaitforRecommendQuery : IRequest<List<LeaveApplyViewModel>>
    {
        public int compId { get; set; }
        public string empCode { get; set; }


        public class Handler : IRequestHandler<GetLeaveWaitforRecommendQuery, List<LeaveApplyViewModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveApplyViewModel>> Handle(GetLeaveWaitforRecommendQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetWaitingLeaveForRecommend(request.compId, request.empCode);
                return (List<LeaveApplyViewModel>)result;

            }
        }
    }
}

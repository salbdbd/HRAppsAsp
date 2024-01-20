using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class LeaveApplyQuery : IRequest<bool>
    {
        public LeaveApply leaveApply { get; set; }
       
        public class Handler : IRequestHandler<LeaveApplyQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(LeaveApplyQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.LeaveApply(request.leaveApply);
                return result;

            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class SaveLeaveApplicationQuery : IRequest<bool>
    {
        public LeaveApply leaveApply { get; set; }

        public class Handler : IRequestHandler<SaveLeaveApplicationQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(SaveLeaveApplicationQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.SaveLeaveApplication(request.leaveApply);
                return result;

            }
        }
    }
}

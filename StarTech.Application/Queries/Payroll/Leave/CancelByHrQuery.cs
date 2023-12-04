using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    
    public class CancelByHrQuery : IRequest<bool>
    {
        public int leaveId { get; set; }

        public class Handler : IRequestHandler<CancelByHrQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(CancelByHrQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.CancelByHr(request.leaveId);
                return result;

            }
        }
    }

}

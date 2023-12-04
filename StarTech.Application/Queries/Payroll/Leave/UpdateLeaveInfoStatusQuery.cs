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
   
    public class UpdateLeaveInfoStatusQuery : IRequest<bool>
    {
        public LeaveInfoStatusModel Lis { get; set; }

        public class Handler : IRequestHandler<UpdateLeaveInfoStatusQuery, bool>                                                                            
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(UpdateLeaveInfoStatusQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.UpdateLeaveInfoStatus(request.Lis);
                return result;

            }
        }
    }
}

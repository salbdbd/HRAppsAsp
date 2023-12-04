using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class GetLeaveTypeQuery : IRequest<List<LeaveTypeModel>>
    {
        public int gradeValue { get; set; }
        public int gender { get; set; }

        public class Handler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveTypeModel>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveType(request.gradeValue, request.gender);
                return (List<LeaveTypeModel>)result;

            }
        }
    }
}

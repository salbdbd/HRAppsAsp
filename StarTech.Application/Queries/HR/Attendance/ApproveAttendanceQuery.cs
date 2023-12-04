using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.Attendance;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR.Attendance
{
    public class ApproveAttendanceQuery : IRequest<bool>
    {
        public int id { get; set; }

        public class Handler : IRequestHandler<ApproveAttendanceQuery, bool>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(ApproveAttendanceQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.ApproveAttendance(request.id);
                return result;

            }
        }
    }
}

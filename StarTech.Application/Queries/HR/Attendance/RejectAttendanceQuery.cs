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
    public class RejectAttendanceQuery : IRequest<bool>
    {
        public int id { get; set; }

        public class Handler : IRequestHandler<RejectAttendanceQuery, bool>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(RejectAttendanceQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.RejectAttendance(request.id);
                return result;

            }
        }
    }
}

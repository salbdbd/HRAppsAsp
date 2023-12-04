using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR.Attendance
{
    public class SaveManualAttenQuery : IRequest<bool>
    {
        public ManualAttendenceModel model { get; set; }

        public class Handler : IRequestHandler<SaveManualAttenQuery, bool>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(SaveManualAttenQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.SaveManualAttendence(request.model);
                return result;

            }
        }
    }
}

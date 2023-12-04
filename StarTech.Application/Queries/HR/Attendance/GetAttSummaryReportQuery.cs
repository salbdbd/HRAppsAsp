using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR.Attendance
{
    public class GetAttSummaryReportQuery : IRequest<List<AttendanceSummaryModel>>
    {
        public string empCode { get; set; }
        public int periodID { get; set; }
        public int companyID { get; set; }
       
        public class Handler : IRequestHandler<GetAttSummaryReportQuery, List<AttendanceSummaryModel>>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<List<AttendanceSummaryModel>> Handle(GetAttSummaryReportQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetSummaryReport(request.empCode, request.periodID, request.companyID);
                return (List<AttendanceSummaryModel>)result;

            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR.Attendance
{
    public class GetIndInOutReportQuery : IRequest<List<IndEmpInOutModel>>
    {
        public string empCode { get; set; }
        public int companyID { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public class Handler : IRequestHandler<GetIndInOutReportQuery, List<IndEmpInOutModel>>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<List<IndEmpInOutModel>> Handle(GetIndInOutReportQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetIndividualInOutReport(request.empCode, request.companyID, request.startDate, request.endDate);
                return (List<IndEmpInOutModel>)result;

            }
        }
    }
}

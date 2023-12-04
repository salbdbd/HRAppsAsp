using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Application.Queries.HR;
using StarTech.Model.HR;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class GetLeaveReportQuery : IRequest<List<LeaveReportModel>>
    {
        public string? empcode { get; set; }
        public string startDate { get; set; }
        public string? endDate { get; set; }
        public int companyID { get; set; }
       

        public class Handler : IRequestHandler<GetLeaveReportQuery, List<LeaveReportModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveReportModel>> Handle(GetLeaveReportQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveReport(request.empcode, request.startDate, request.endDate,request.companyID);
                return (List<LeaveReportModel>)result;

            }
        }
    }
}

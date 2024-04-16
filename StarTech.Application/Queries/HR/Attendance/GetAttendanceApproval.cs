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
    public class GetAttendanceApproval : IRequest<List<AttendanceApprovalModel>>
    {
        public int companyID { get; set; }
        public string applyTo { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int anyDate { get; set; }

        public class Handler : IRequestHandler<GetAttendanceApproval, List<AttendanceApprovalModel>>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<List<AttendanceApprovalModel>> Handle(GetAttendanceApproval request, CancellationToken cancellationToken)
            {
                var result = await _service.GetAttendanceApproval(request.companyID,request.applyTo, request.fromDate, request.toDate, request.anyDate);
                return (List<AttendanceApprovalModel>)result;

            }
        }
    }

    public class ChickAttendance : IRequest<List<ChickAttendaceModel>>
    {
        public string empCode { get; set; }

        public class Handler : IRequestHandler<ChickAttendance, List<ChickAttendaceModel>>
        {
            private readonly IAttendanceService _service;

            public Handler(IAttendanceService service)
            {
                _service = service;
            }

            public async Task<List<ChickAttendaceModel>> Handle(ChickAttendance request, CancellationToken cancellationToken)
            {
                var result = await _service.ChickAttendance(request.empCode);
                return (List<ChickAttendaceModel>)result;

            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class GetLeaveApplicationListQuery : IRequest<List<LeaveApplicationListModel>>
    {
        public int compId { get; set; }
        public string reportTo { get; set; }


        public class Handler : IRequestHandler<GetLeaveApplicationListQuery, List<LeaveApplicationListModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<LeaveApplicationListModel>> Handle(GetLeaveApplicationListQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveApplicationList(request.compId,request.reportTo);
                return (List<LeaveApplicationListModel>)result;

            }
        }
    }
}

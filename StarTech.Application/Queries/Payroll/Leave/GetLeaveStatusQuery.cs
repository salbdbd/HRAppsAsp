using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class GetLeaveStatusQuery : IRequest<List<GetLeaveStatusModel>>
    {
        public string EmpCode { get; set; }
        public int CompanyID { get; set; }
        public int PeriodID { get; set; }



        public class Handler : IRequestHandler<GetLeaveStatusQuery, List<GetLeaveStatusModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<GetLeaveStatusModel>> Handle(GetLeaveStatusQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetLeaveStatus(request.EmpCode, request.CompanyID, request.PeriodID);
                return (List<GetLeaveStatusModel>)result;

            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Application.Queries.Payroll.Leave;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll
{
    public class GetPaySlipQuery : IRequest<List<PaySlipModel>>
    {
        public string empCode { get; set; }
        public int periodID { get; set; }
        public int companyID { get; set; }
        public string department { get; set; }

        public class Handler : IRequestHandler<GetPaySlipQuery, List<PaySlipModel>>
        {
            private readonly ISalaryService _service;

            public Handler(ISalaryService service)
            {
                _service = service;
            }

            public async Task<List<PaySlipModel>> Handle(GetPaySlipQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetPaySlip(request.empCode, request.periodID, request.companyID, request.department);
                return (List<PaySlipModel>)result;
            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll
{
    public class GetSalaryPeriodQuery : IRequest<List<SalaryPeriodModel>>
    {
        public int companyID { get; set; }
      

        public class Handler : IRequestHandler<GetSalaryPeriodQuery, List<SalaryPeriodModel>>
        {
            private readonly ISalaryService _service;

            public Handler(ISalaryService service)
            {
                _service = service;
            }

            public async Task<List<SalaryPeriodModel>> Handle(GetSalaryPeriodQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetPeriodList(request.companyID);
                return (List<SalaryPeriodModel>)result;

            }
        }
    }
}

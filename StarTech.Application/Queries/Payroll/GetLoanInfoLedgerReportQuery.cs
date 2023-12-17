using MediatR;
using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll
{
    public class GetLoanInfoLedgerReportQuery : IRequest<List<RptLoanInfoLedgerModel>>
    {


        public string empCode { get; set; } 
        public int companyID { get; set; }
       
        public class Handler : IRequestHandler<GetLoanInfoLedgerReportQuery, List<RptLoanInfoLedgerModel>>
        {
            private readonly ISalaryService _service;

            public Handler(ISalaryService service)
            {
                _service = service;
            }


            public async Task<List<RptLoanInfoLedgerModel>> Handle(GetLoanInfoLedgerReportQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetRptLoanInfoLedgerReport(request.empCode, request.companyID);
                return (List<RptLoanInfoLedgerModel>)result;
            }




        }


    }
}

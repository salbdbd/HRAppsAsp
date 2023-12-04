using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR
{
        public class GetEmployeeInfoQuery : IRequest<List<EmpInfoModel>>
        {
            public string? empCode { get; set; }
            public int companyID { get; set; }
            public string? department { get; set; }
            public string? name { get; set; }
            public string? reportTo { get; set; }
            public int pageNumber { get; set; }
            public int rowsOfPage { get; set; }       
            public class Handler : IRequestHandler<GetEmployeeInfoQuery, List<EmpInfoModel>>
            {
                private readonly IEmployeeService _service;

                public Handler(IEmployeeService service)
                {
                    _service = service;
                }

                public async Task<List<EmpInfoModel>> Handle(GetEmployeeInfoQuery request, CancellationToken cancellationToken)
                {
                   var result = await _service.GetEmpInfo(request.empCode,request.companyID,request.department,request.name,request.reportTo,request.pageNumber,request.rowsOfPage);
                    return (List<EmpInfoModel>)result;

                }
            }
        }
}

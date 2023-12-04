using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class GetEmpGradeQuery : IRequest<List<EmpGradeModel>>
    {
        public class Handler : IRequestHandler<GetEmpGradeQuery, List<EmpGradeModel>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<EmpGradeModel>> Handle(GetEmpGradeQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetEmpGrade();
                return (List<EmpGradeModel>)result;

            }
        }
    }
}

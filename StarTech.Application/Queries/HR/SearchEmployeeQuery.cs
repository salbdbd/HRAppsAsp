using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR
{

    public class SearchEmployeeQuery : IRequest<List<EmpSearchViewModel>>
    {
        
        public EmpSearchViewModel EmpSearch { get; set; }
       
        public class Handler : IRequestHandler<SearchEmployeeQuery, List<EmpSearchViewModel>>
        {
            private readonly IEmployeeService _service;

            public Handler(IEmployeeService service)
            {
                _service = service;
            }

            public async Task<List<EmpSearchViewModel>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
            {
               var result = await _service.SearchEmployee(request.EmpSearch);
                return (List<EmpSearchViewModel>)result;

            }
        }
    }
}

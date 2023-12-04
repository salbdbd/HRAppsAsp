using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
    public class UpdateLeaveStatusQuery : IRequest<bool>
    {
        public ApprovedModel UpdateLeaveStatus { get; set; }

        public int type { get; set; }
        public int id { get; set; }
        public string reqFrom { get; set; }
        public int companyID { get; set; }
        public string reqTo { get; set; }
        public string remarks { get; set; }

        public class Handler : IRequestHandler<UpdateLeaveStatusQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

        


            public async Task<bool> Handle(UpdateLeaveStatusQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateLeaveStatus(request.UpdateLeaveStatus);
        return result;

    }
        }
    }
}

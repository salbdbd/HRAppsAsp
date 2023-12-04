using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Application.Interface.ServiceInterface.Security;
using StarTech.Application.Queries.HR.Attendance;
using StarTech.Model.Attendance;
using StarTech.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Security
{
    public class ChangePasswordQuery : IRequest<bool>
    {
        public ChangePasswordModel model { get; set; }

        public class Handler : IRequestHandler<ChangePasswordQuery, bool>
        {
            private readonly ISecurityService _service;

            public Handler(ISecurityService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(ChangePasswordQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.ChangePassword(request.model);
                return result;

            }
        }
    }
}

using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.Payroll.Leave
{
   
    public class UpdateLeaveInfoStatusQuery : IRequest<bool>
    {
        public LeaveInfoStatusModel Lis { get; set; }

        public class Handler : IRequestHandler<UpdateLeaveInfoStatusQuery, bool>                                                                            
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(UpdateLeaveInfoStatusQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.UpdateLeaveInfoStatus(request.Lis);
                return result;

            }
        }
    }

    public class UpdateRecommandQuery : IRequest<bool>
    {
        public ApprovedModel Lis { get; set; }
       
        public class Handler : IRequestHandler<UpdateRecommandQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(UpdateRecommandQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.UpdateRecommand(request.Lis);
                return result;

            }
        }
    }

    public class GetMessageQuery : IRequest<List<GetWMesage>>
    {

        public int CompanyId { get; set; }
        public string EmpCode { get; set; }

        public class Handler : IRequestHandler<GetMessageQuery, List<GetWMesage>>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<List<GetWMesage>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.Get_Message(request.CompanyId, request.EmpCode);
                return result;

            }
        }
    }

    public class SaveMessageQuery : IRequest<bool>
    {

        public SaveWMesage SaveWMesage { get; set; }
        public SaveMessageQuery(SaveWMesage SaveWMesage)
        {
            this.SaveWMesage = SaveWMesage;
        }

        public class Handler : IRequestHandler<SaveMessageQuery, bool>
        {
            private readonly ILeaveService _service;

            public Handler(ILeaveService service)
            {
                _service = service;
            }

            public async Task<bool> Handle(SaveMessageQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.Message_Save(request.SaveWMesage);
                return result;

            }
        }

    }

}

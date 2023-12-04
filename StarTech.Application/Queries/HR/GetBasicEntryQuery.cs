using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Queries.HR
{
    public class GetBasicEntryQuery : IRequest<List<BasicEntryModel>>
    {
        public string tableName { get; set; }
        public int compId { get; set; }
       
        public class Handler : IRequestHandler<GetBasicEntryQuery, List<BasicEntryModel>>
        {
            private readonly IBasicEntryService _service;

            public Handler(IBasicEntryService service)
            {
                _service = service;
            }

            public async Task<List<BasicEntryModel>> Handle(GetBasicEntryQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetAllBasicItems(request.tableName, request.compId);
                return (List<BasicEntryModel>)result;

            }
        }
    }
}

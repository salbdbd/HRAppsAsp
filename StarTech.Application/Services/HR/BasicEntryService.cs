using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.HR
{
    public class BasicEntryService : IBasicEntryService
    {
        // private readonly IMapper _mapper;
        private readonly IBasicEntryRepository _repository;

        public BasicEntryService(IBasicEntryRepository repository)
        {
            //  _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<BasicEntryModel>> GetAllBasicItems(string tableName, int compId) => await _repository.GetAllBasicItems(tableName, compId);

    }
}

using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.RepositoryInterface.HR
{
    public interface IBasicEntryRepository
    {
        Task<IEnumerable<BasicEntryModel>> GetAllBasicItems(string tableName, int compId);
    }
}

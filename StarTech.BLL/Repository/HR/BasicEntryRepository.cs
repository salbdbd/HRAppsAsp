using Microsoft.Data.SqlClient;
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Repository.HR
{
    public class BasicEntryRepository:IBasicEntryRepository
    {
        public BasicEntryRepository()
        {

        }

        public async Task<IEnumerable<BasicEntryModel>> GetAllBasicItems(string tableName, int compId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE CompanyID={compId}";
            var con = new SqlConnection(Connection.ConnectionString());
            var items = await con.QueryAsync<BasicEntryModel>(sql);
            return items.ToList();
            
        }
    }
}

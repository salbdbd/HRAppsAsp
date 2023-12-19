using Microsoft.Data.SqlClient;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Repository.Payroll
{
    public class SalaryRepository : ISalaryRepository
    {
        
        public IDbConnection _db;
        public SalaryRepository() => _db = new SqlConnection(Connection.ConnectionString());
      
        public async Task<IEnumerable<PaySlipModel>> GetPaySlip(string EmpCode, int PeriodID, int CompanyID,string department)
        {
            var result = await _db.QueryAsync<PaySlipModel>("SP_API_Getpayslip_NI",
                param: new
                {
                    EmpCode,
                    PeriodID,
                    CompanyID,
                    department
                },

             commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }

        public async Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int CompanyID)
        {

            var result = await _db.QueryAsync<SalaryPeriodModel>("GetPeriodList_NI",
                 param: new
                 {
                     CompanyID
                 },

              commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }

        public async Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID)
        {
       
            var result = await _db.QueryAsync<RptLoanInfoLedgerModel>("spRptLoanInfoLedgerReport",
                param: new
                {
                    empCode,
                    companyID
                },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

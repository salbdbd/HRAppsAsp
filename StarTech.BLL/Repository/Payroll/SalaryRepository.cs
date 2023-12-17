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
        public SalaryRepository()
        {

        }
        public async Task<IEnumerable<PaySlipModel>> GetPaySlip(string EmpCode, int PeriodID, int CompanyID,string department)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            List<PaySlipModel> result = con.Query<PaySlipModel>("SP_API_Getpayslip_NI",
                param: new
                {
                    EmpCode,
                    PeriodID,
                    CompanyID,
                    department
                    
                },

             commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public async Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int CompanyID)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            List<SalaryPeriodModel> result = con.Query<SalaryPeriodModel>("GetPeriodList_NI",
                param: new
                {
                    CompanyID
                },

             commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public async Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            List<RptLoanInfoLedgerModel> result = con.Query<RptLoanInfoLedgerModel>("spRptLoanInfoLedgerReport",
                param: new
                {
                    empCode,
                    companyID
                },
                commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}

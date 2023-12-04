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
        public async Task<IEnumerable<PaySlipModel>> GetPaySlip(string EmpCode, int PeriodID, int CompanyID, string Department)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            List<PaySlipModel> result = con.Query<PaySlipModel>("SP_API_Getpayslip_NI",
                param: new
                {
                    EmpCode,
                    PeriodID,
                    CompanyID,
                    Department
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

        public async Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID, string department, int loanType, int branch, int grade, int projectId, string startdate, string endtime)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            List<RptLoanInfoLedgerModel> result = con.Query<RptLoanInfoLedgerModel>("spRptLoanInfoLedgerReport",
                param: new
                {
                    empCode,
                    companyID,
                    department,
                    loanType,
                    branch,
                    grade,
                    projectId,
                    startdate,
                    endtime

                },
                commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}

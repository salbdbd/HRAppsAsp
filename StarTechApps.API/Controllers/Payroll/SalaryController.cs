using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarTech.Application.Queries.Payroll;
using StarTech.Application.Queries.Payroll.Leave;
using StarTech.BLL.DBConfiguration;
using StarTech.Model.Payroll;
using StarTechApps.API.Controllers.Common;
using System.Data;

namespace StarTechApps.API.Controllers.Payroll
{
    [Authorize]
    public class SalaryController : BaseApiController
    {
        public IDbConnection _db;
        public SalaryController()
        {
            _db = new SqlConnection(Connection.ConnectionString());
        }

        [HttpGet("salary/get-pay-slip/{empCode}/{periodID}/{companyID}/{department}")]
        public async Task<IActionResult> GetPaySlip(string empCode, int periodID, int companyID, string department)
        {
            return Ok(await _mediatr.Send(new GetPaySlipQuery { empCode = empCode, periodID = periodID, companyID = companyID, department = department }));
        }

        [HttpGet("salary/get-period-list/{companyID}")]
        public async Task<IActionResult> GetPeriodList(int companyID)
        {
            return Ok(await _mediatr.Send(new GetSalaryPeriodQuery {companyID = companyID }));
        }

        [HttpGet("salary/get-rpt-loaninfoledgerreport/{empCode}/{companyID}")]
        public async Task<IActionResult> GetRptLoanInfoLedgerReport(string empCode, int companyID)
        {
            return Ok(await _mediatr.Send(new GetLoanInfoLedgerReportQuery { empCode = empCode, companyID = companyID}));
       
        }

        [HttpGet("salary/EmpCurrentAsset/{EmpCode}/{CompanyID}/{Grade}")]
        public async Task<IEnumerable<EmpCurrentAsset>> EmpCurrentAsset(string EmpCode,int CompanyID, int Grade)
        {
            var result = await _db.QueryAsync<EmpCurrentAsset>("spRptEmpCurrentAssetAssain",
                param: new
                {
                    EmpCode,
                    Grade,
                    CompanyID
         
                },

             commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }
    }
}

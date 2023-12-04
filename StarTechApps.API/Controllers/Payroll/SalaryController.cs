using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Queries.Payroll;
using StarTech.Application.Queries.Payroll.Leave;
using StarTechApps.API.Controllers.Common;

namespace StarTechApps.API.Controllers.Payroll
{
    [Authorize]
    public class SalaryController : BaseApiController
    {
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

        [HttpGet("salary/get-rpt-loaninfoledgerreport/{empCode}/{companyID}/{department}/{loanType}/{branch}/{grade}/{projectId}/{startdate}/{endtime}")]
        public async Task<IActionResult> GetRptLoanInfoLedgerReport(string empCode, int companyID, string department, int loanType, int branch, int grade, int projectId, string startdate, string endtime)
        {
            return Ok(await _mediatr.Send(new GetLoanInfoLedgerReportQuery { empCode = empCode, companyID = companyID, department = department, loanType = loanType, branch = branch, grade = grade, projectId = projectId, startdate = startdate, endtime = endtime }));
       
        }


    }
}

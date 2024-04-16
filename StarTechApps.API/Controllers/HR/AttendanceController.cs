using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarTech.Application.Queries.HR;
using StarTech.Application.Queries.HR.Attendance;
using StarTech.Application.Queries.Payroll.Leave;
using StarTech.BLL.DBConfiguration;
using StarTech.Model.Attendance;
using StarTech.Model.Leave;
using StarTechApps.API.Controllers.Common;
using System.ComponentModel.Design;
using System.Data;

namespace StarTechApps.API.Controllers.HR
{
    //[Authorize]
    public class AttendanceController : BaseApiController
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public IDbConnection db;
        public AttendanceController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            db = new SqlConnection(Connection.ConnectionString());
        }
      
      


        [HttpPost("atten/approve-attendance/{id}")]
        public async Task<IActionResult> ApproveAttendance(int id)
        {
            return Ok(await _mediatr.Send(new ApproveAttendanceQuery { id = id }));
        }

        [HttpPost("atten/reject-attendance/{id}")]
        public async Task<IActionResult> RejectAttendance(int id)
        {
            return Ok(await _mediatr.Send(new RejectAttendanceQuery { id = id }));
        }

        [HttpPost("atten/save-manual-attendance")]
        public async Task<IActionResult> SaveManualAttendence([FromBody] ManualAttendenceModel model)
        {
            return Ok(await _mediatr.Send(new SaveManualAttenQuery { model = model }));
        }

        [HttpGet("atten/get-individual-inout-report/{empCode}/{companyID}/{startDate}/{endDate}")]
        public async Task<IActionResult> GetIndividualInOutReport(string empCode, int companyID, string startDate, string endDate)
        {
            return Ok(await _mediatr.Send(new GetIndInOutReportQuery { empCode = empCode, companyID = companyID, startDate = startDate, endDate= endDate }));
        }

        [HttpGet("atten/get-summary-report/{empCode}/{periodID}/{companyID}")]
        public async Task<IActionResult> GetSummaryReport(string empCode, int periodID, int companyID)
        {
            return Ok(await _mediatr.Send(new GetAttSummaryReportQuery { empCode = empCode, periodID= periodID,companyID = companyID }));
        }

        [HttpGet("atten/get-attendance-approval/{companyID}/{applyTo}/{fromDate}/{toDate}/{anyDate}")]
        public async Task<IActionResult> GetAttendanceApproval(int companyID,string applyTo,string fromDate,string toDate ,int anyDate)
         {
            return Ok(await _mediatr.Send(new GetAttendanceApproval { companyID = companyID, applyTo = applyTo, fromDate = fromDate, toDate = toDate, anyDate = anyDate }));
        } 
        
        
        [HttpGet("atten/ChickAddTendance/{empCode}")]
        public async Task<IActionResult> ChickAttendance(string empCode)
         {
            return Ok(await _mediatr.Send(new ChickAttendance { empCode = empCode }));
        }
       






}
}

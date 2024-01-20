using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarTech.Application.Queries.HR;
using StarTech.Application.Queries.Payroll.Leave;
using StarTech.BLL.DBConfiguration;
using StarTech.Model.Leave;
using StarTech.Model.Payroll.Leave;
using StarTechApps.API.Controllers.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StarTechApps.API.Controllers.Payroll
{
    [Authorize]
    public class LeaveController : BaseApiController
    {
        #region // Leave Apply start
        [HttpGet("leave/get-leave-type/{gradeValue}/{gender}")]
        public async Task<IActionResult> GetLeaveType(int gradeValue, int gender)
        {
            return Ok(await _mediatr.Send(new GetLeaveTypeQuery { gradeValue = gradeValue, gender = gender }));
        }
       
        [HttpGet("leave/Get-Leave-Status/{EmpCode}/{CompanyID}/{PeriodID}")]
        public async Task<IActionResult> GetLeaveStatus(string EmpCode, int CompanyID, int PeriodID)
        {
            return Ok(await _mediatr.Send(new GetLeaveStatusQuery { EmpCode = EmpCode, CompanyID = CompanyID, PeriodID = PeriodID }));
        }
        [HttpGet("leave/Get-Leave-Info/{EmpCode}/{CompanyID}")]
        public async Task<IActionResult> GetLeaveInfo(string EmpCode, int CompanyID)
        {
            return Ok(await _mediatr.Send(new GetLeaveInfoQuery { EmpCode = EmpCode, CompanyID = CompanyID }));
        }
        [HttpPost("leave/leave-apply")]
        public async Task<IActionResult> LeaveApply([FromBody] LeaveApply model)
        {
            return Ok(await _mediatr.Send(new LeaveApplyQuery { leaveApply = model }));
        }
        #endregion // Leave Apply end

        [HttpGet("leave/getLeaveInfoStatus/{EmpCode}/{CompanyID}")]
        public async Task<IActionResult> getLeaveInfoStatus(string EmpCode, int CompanyID)
        {
            return Ok(await _mediatr.Send(new getLeaveInfoStatusQuery { EmpCode = EmpCode, CompanyID = CompanyID }));
        }

        [HttpGet("leave/get-Emp-grade")]
        public async Task<IActionResult> GetEmpGrade()
        {
            return Ok(await _mediatr.Send(new GetEmpGradeQuery { }));
        }

        [HttpGet("leave/get-leave-report/{empcode}/{startDate}/{endDate}/{companyID}")]
        public async Task<IActionResult> GetLeaveReport(string empcode, string startDate, string endDate, int companyID)
        {
            return Ok(await _mediatr.Send(new GetLeaveReportQuery { empcode = empcode, startDate = startDate, endDate = endDate, companyID = companyID }));
        }
        
        

        [HttpGet("leave/get-leave-application-list/{compId}/{reportTo}/{logInID}")]
        public async Task<IActionResult> GetLeaveApplicationList(int compId, string reportTo, string logInID)
        {
            return Ok(await _mediatr.Send(new GetLeaveApplicationListQuery { compId = compId , reportTo = reportTo, logInID = logInID }));
        }

        #region //leave approval start
        [HttpGet("leave/GetWaitingLeaveForApprove/{compId}/{year}/{empCode}")]
        public async Task<IActionResult> GetWaitingLeaveForApprove(int compId, string year, string empCode)
        {
            return Ok(await _mediatr.Send(new GetWaitingLeaveForApproveQuery { empCode = empCode, compId = compId, year = year }));
        }

        [HttpPost("leave/approved-leave")]
        public async Task<IActionResult> ApprovedLeave([FromBody] ApprovedModel ent)
        {
            return Ok(await _mediatr.Send(new UpdateRecommandQuery { Lis = ent }));
        }
        [HttpPost("leave/cancel-leave")]
        public async Task<IActionResult> CancelLeave([FromBody] ApprovedModel ent)
        {
            return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { type = 3, id = ent.ID, reqFrom = ent.ReqFrom, companyID = ent.CompanyID, reqTo = "", remarks = ent.Remarks }));
        }
        [HttpPost("leave/recommend-leave")]
        public async Task<IActionResult> RecommendLeave([FromBody] ApprovedModel ent)
        {
            return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { type =  2, id = ent.ID, reqFrom = ent.ReqFrom, companyID = ent.CompanyID, reqTo = "", remarks = ent.Remarks }));
        }

        [HttpPost("leave/UpdateLeaveInfoStatus")]
        public async Task<IActionResult> UpdateLeaveInfoStatus(LeaveInfoStatusModel lis)
        {
            return Ok(await _mediatr.Send(new UpdateLeaveInfoStatusQuery { Lis = lis }));
        }


        [HttpPost("leave/UpdateByAuthority")]
        public async Task<IActionResult> UpdateByAuthority(UpdateByAuthorityModel lis)
        {
            return Ok(await _mediatr.Send(new UpdateAuthorityQuery { updateAuthoRity = lis })); 
        }
       
        #endregion //leave approval end


        #region //leave approval by HR start
        [HttpGet("leave/GetLeaveInfoForHrApprove/{compId}")]
        public async Task<IActionResult> GetLeaveInfoForHrApprove(int compId)
        {
            return Ok(await _mediatr.Send(new GetLeaveInfoForHrApproveQuery { compId = compId })); ;
        }

        [HttpPost("leave/ApproveByHr")]
        public async Task<IActionResult> ApproveByHr(LeaveDetailsViewModel leaveDetailsVm)
        {
            return Ok(await _mediatr.Send(new ApproveByHrQuery { leaveDetails = leaveDetailsVm })); ;
        } 
        
        [HttpPost("leave/CancelByHr/{leaveId}")]
        public async Task<IActionResult> CancelByHr(int leaveId)
        {
            return Ok(await _mediatr.Send(new CancelByHrQuery { leaveId = leaveId })); 
        }

        #endregion //leave approval by HR end


        #region //SuperVisor
        [HttpGet("GetWaitingLeaveForRecommend/{compId}/{empCode}")]
        public async Task<IActionResult> GetWaitingLeaveForRecommend(int compId,string empCode)
        {
            return Ok(await _mediatr.Send(new GetLeaveWaitforRecommendQuery { compId = compId, empCode = empCode }));
        }

        [HttpPost("UpdateRecommand")]
        public async Task<IActionResult> UpdateRecommand(ApprovedModel recom)
        {
            return Ok(await _mediatr.Send(new UpdateRecommandQuery { Lis  = recom }));
        }
        #endregion


        

    }

}

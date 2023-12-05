using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Queries.HR;
using StarTech.Application.Queries.Payroll.Leave;
using StarTech.Model.Leave;
using StarTech.Model.Payroll.Leave;
using StarTechApps.API.Controllers.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [HttpPost("leave/leave-apply")]
        public async Task<IActionResult> LeaveApply([FromBody] LeaveApplyModel model)
        {
            return Ok(await _mediatr.Send(new LeaveApplyQuery { leaveApply = model }));
        }
        [HttpGet("leave/Get-Leave-Status/{EmpCode}/{PeriodID}/{CompanyID}/{Grade}/{Gender}")]
        public async Task<IActionResult> GetLeaveStatus(string EmpCode, int PeriodID, int CompanyID, int Grade, int Gender)
        {
            return Ok(await _mediatr.Send(new GetLeaveStatusQuery { EmpCode = EmpCode, PeriodID = PeriodID, CompanyID = CompanyID, Grade = Grade, Gender = Gender }));
        }
        [HttpGet("leave/Get-Leave-Info/{EmpCode}/{CompanyID}")]
        public async Task<IActionResult> GetLeaveInfo(string EmpCode, int CompanyID)
        {
            return Ok(await _mediatr.Send(new GetLeaveInfoQuery { EmpCode = EmpCode, CompanyID = CompanyID }));
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
        
        //[HttpPost("leave/save-manual-leave-application")]
        //public async Task<IActionResult> ManualLeaveApplication([FromBody] LeaveApplyModel model)
        //{
        //    return Ok(await _mediatr.Send(new SaveLeaveApplicationQuery { leaveApply = model}));
        //}

        [HttpGet("leave/get-leave-application-list/{compId}/{reportTo}")]
        public async Task<IActionResult> GetLeaveApplicationList(int compId, string reportTo)
        {
            return Ok(await _mediatr.Send(new GetLeaveApplicationListQuery { compId = compId , reportTo = reportTo }));
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
            return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { UpdateLeaveStatus = ent }));
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
        //[HttpPost("leave/UpdateLeaveApprove")]
        //public async Task<IActionResult> UpdateLeaveApprove(List<UpdateLeaveApprove> leaveInfoList)
        //{
        //    return Ok(await _mediatr.Send(new UpdateLeaveApproveQuery { la = leaveInfoList }));

        //}

        // [HttpPost("leave/approved-leave")]
        //public async Task<IActionResult> ApprovedLeave([FromBody] ApprovedModel ent)
        // {
        //     return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { UpdateLeaveStatus = ent }));
        // }
        // [HttpPost("leave/cancel-leave")]
        // public async Task<IActionResult> CancelLeave([FromBody] ApprovedModel ent)
        // {
        //     return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { type = 3, id = ent.ID, reqFrom = ent.ReqFrom, companyID = ent.CompanyID, reqTo = "", remarks = ent.Remarks }));
        // }

        // [HttpPost("leave/recommend-leave")]
        // public async Task<IActionResult> RecommendLeave([FromBody] ApprovedModel ent)
        // {
        //    return Ok(await _mediatr.Send(new UpdateLeaveStatusQuery { type = 2, id = ent.ID, reqFrom = ent.ReqFrom, companyID = ent.CompanyID, reqTo = "", remarks = ent.Remarks }));
        // }


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

        //[HttpPost("leave/UpdateAndApproveByHr")]
        //public async Task<IActionResult> UpdateAndApproveByHr(LeaveApplyModel la)
        //{
        //    return Ok(await _mediatr.Send(new UpdateAndApproveByHrQuery { la = la }));
        //}


    }

}

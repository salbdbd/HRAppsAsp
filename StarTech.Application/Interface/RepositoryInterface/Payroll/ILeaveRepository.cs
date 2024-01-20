using StarTech.Application.Queries.Payroll.Leave;
using StarTech.Model.HR;
using StarTech.Model.HR.Attendance;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.RepositoryInterface.Payroll
{
    public interface ILeaveRepository
    {
       
        Task<IEnumerable<LeaveTypeModel>> GetLeaveType(int gradeValue, int gender);
        Task<IEnumerable<LeaveReportModel>> GetLeaveReport(string Empcode, string StartDate, string EndDate, int CompanyID);
        Task<IEnumerable<LeaveApplicationListModel>> GetLeaveApplicationList(int compId, string reportTo, string logInID);
        Task<IEnumerable<EmpGradeModel>> GetEmpGrade();
        Task<IEnumerable<GetLeaveStatusModel>> GetLeaveStatus(string EmpCode, int CompanyID, int PeriodID);
        Task<List<LeaveApplyModel>> GetLeaveInfo(int compId, string empCode);
        Task<List<LeaveStatus>> getLeaveInfoStatus(string empCode, int companyId);
        Task<List<LeaveApplyViewModel>> GetWaitingLeaveForApprove(int compId, string year, string empCode);
        Task<List<LeaveApplyViewModel>> GetWaitingLeaveForRecommend(int compId, string empCode);
        Task<List<LeaveApplyViewModel>> GetLeaveInfoForHrApprove(int compId);
        Task<bool> UpdateLeaveStatus(ApprovedModel approve);
        Task<bool> LeaveApply(LeaveApply leaveApply);
        Task<bool> UpdateLeaveInfoStatus(LeaveInfoStatusModel lsi);
        Task<bool> ApproveByHr(LeaveDetailsViewModel leaveDetailsVm);
        Task<bool> SaveLeaveApplication(LeaveApply ent);
        Task<bool> CancelByHr(int leaveId);
        Task<bool> UpdateByAuthority(UpdateByAuthorityModel leaveInfo);
        Task<bool> UpdateRecommand(ApprovedModel approve);






    }
}

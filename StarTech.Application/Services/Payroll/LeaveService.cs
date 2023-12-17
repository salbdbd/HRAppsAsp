using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.HR;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.Payroll
{

    public class LeaveService : ILeaveService
    {
       
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository) => _repository = repository;
       
        public async Task<bool> SaveLeaveApplication(LeaveApplyModel model) => await _repository.SaveLeaveApplication(model);
        public async Task<bool> LeaveApply(LeaveApplyModel model) => await _repository.LeaveApply(model);
        public async Task<IEnumerable<LeaveTypeModel>> GetLeaveType(int gradeValue, int gender) => await _repository.GetLeaveType(gradeValue, gender);
        public async Task<IEnumerable<LeaveReportModel>> GetLeaveReport(string empcode, string startDate, string endDate, int companyID) => await _repository.GetLeaveReport(empcode, startDate, endDate,companyID);
        public async Task<IEnumerable<LeaveApplicationListModel>> GetLeaveApplicationList(int compId, string reportTo) => await _repository.GetLeaveApplicationList(compId,reportTo);
        public async Task<bool> UpdateLeaveStatus(ApprovedModel leave) => await _repository.UpdateLeaveStatus(leave);

        public async Task<IEnumerable<EmpGradeModel>> GetEmpGrade() => await _repository.GetEmpGrade();

        public async Task<IEnumerable<GetLeaveStatusModel>> GetLeaveStatus(string EmpCode, int CompanyID, int PeriodID) => await _repository.GetLeaveStatus(EmpCode,CompanyID,PeriodID);

        public async Task<List<LeaveApplyModel>> GetLeaveInfo(int compId, string empCode)=> await _repository.GetLeaveInfo(compId,empCode);

        public async Task<List<LeaveStatus>> getLeaveInfoStatus(string empCode, int companyId)=> await _repository.getLeaveInfoStatus(empCode,companyId);

        public async Task<List<LeaveApplyViewModel>> GetWaitingLeaveForApprove(int compId, string year, string empCode) => await _repository.GetWaitingLeaveForApprove(compId,year,empCode);

        public async Task<bool> UpdateLeaveInfoStatus(LeaveInfoStatusModel lsi) => await _repository.UpdateLeaveInfoStatus(lsi);

        public async Task<bool> ApproveByHr(LeaveDetailsViewModel leaveDetailsVm)=> await _repository.ApproveByHr(leaveDetailsVm);

        public async Task<List<LeaveApplyViewModel>> GetLeaveInfoForHrApprove(int compId,string ReportTo) => await _repository.GetLeaveInfoForHrApprove(compId, ReportTo);

        public async Task<bool> CancelByHr(int leaveId) => await _repository.CancelByHr(leaveId);

        public async Task<bool> UpdateByAuthority(UpdateByAuthorityModel leaveInfo)=> await _repository.UpdateByAuthority(leaveInfo);
        
    }
}

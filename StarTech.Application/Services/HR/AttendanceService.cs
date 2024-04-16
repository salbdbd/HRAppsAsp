using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.Attendance;
using StarTech.Model.HR;
using StarTech.Model.HR.Attendance;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.HR
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;

        public AttendanceService(IAttendanceRepository repository) => _repository = repository;
        
        public async Task<IEnumerable<IndEmpInOutModel>> GetIndividualInOutReport(string empCode, int companyID, string startDate, string endDate) => await _repository.GetIndividualInOutReport(empCode, companyID, startDate,endDate);
        public async Task<bool> ApproveAttendance(int id) => await _repository.ApproveAttendance( id);
        public async Task<bool> RejectAttendance(int id) => await _repository.RejectAttendance( id);
        public async Task<bool> SaveManualAttendence(ManualAttendenceModel model) => await _repository.SaveManualAttendence(model);
        public async Task<IEnumerable<AttendanceSummaryModel>> GetSummaryReport(string empCode, int periodID, int companyID) => await _repository.GetSummaryReport(empCode, periodID, companyID);
        public async Task<IEnumerable<AttendanceApprovalModel>> GetAttendanceApproval(int companyID, string applyTo, string fromDate, string toDate, int anyDate) => await _repository.GetAttendanceApproval(companyID,applyTo,fromDate,toDate,anyDate);

        public async Task<IEnumerable<ChickAttendaceModel>> ChickAttendance(string empCode) => await _repository.ChickAttendance(empCode);
        
    }
}

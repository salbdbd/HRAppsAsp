using StarTech.Model.Attendance;
using StarTech.Model.HR.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.ServiceInterface.HR
{
    public interface IAttendanceService
    {
        Task<IEnumerable<IndEmpInOutModel>> GetIndividualInOutReport(string empCode, int companyID, string startDate, string endDate);
        Task<bool> ApproveAttendance(int id);
        Task<bool> RejectAttendance(int id);
        Task<bool> SaveManualAttendence(ManualAttendenceModel model);
        Task<IEnumerable<AttendanceSummaryModel>> GetSummaryReport(string empCode, int periodID, int companyID);
        Task<IEnumerable<AttendanceApprovalModel>> GetAttendanceApproval(int companyID, string applyTo,string fromDate,string toDate, int anyDate);
       
    }
}

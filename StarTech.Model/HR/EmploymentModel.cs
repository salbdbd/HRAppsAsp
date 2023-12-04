using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.HR
{
  
    public class EmploymentModel
    {
        public int? ID { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public int CompanyID { get; set; }
        public int? BusinessNatureID { get; set; }
        public int? DesignationID { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? JobType { get; set; }
        public int? EmpGradeID { get; set; }
        public string JobDescription { get; set; }
        public int? JobLocation { get; set; }
        public int? ProjectID { get; set; }
        public int? DepartmentID { get; set; }
        public string ConfirmationDate { get; set; }
        public string ConfirmationDueDate { get; set; }
        public string CardNo { get; set; }
        public string Experience { get; set; }
        public string Resident { get; set; }
        public string IsComCar { get; set; }
        public string Status { get; set; }
        public int? Location { get; set; }
        public string IsBlock { get; set; }
        public int? Unit { get; set; }
        public int? MachineID { get; set; }
        public string ReportTo { get; set; }
        public string ReportToEmpName { get; set; }
        public string ReportToDepartment { get; set; }
        public string ReportToDesignation { get; set; }
        public string OT { get; set; }
        public DateTime AssainDate { get; set; }
        public int? Type { get; set; }
        public int? Active { get; set; }
        public int? GradeValue { get; set; }
        public int? EmpTypeID { get; set; }
        public int UserTypeId { get; set; }
    }
}

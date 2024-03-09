using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll.Leave
{
    public class LeaveApplyViewModel : LeaveApplyModel
    {
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string TypeName { get; set; }
    
    }



    public class RecommandModal
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public int AccepteDuration { get; set; }
        public int LeaveTypedID { get; set; }
        public int? UnAccepteDuration { get; set; }
        public string Withpay { get; set; }
        public string AppType { get; set; }
        public int CompanyID { get; set; }
        public DateTime LADate { get; set; }
        public DateTime LSDate { get; set; }
        public DateTime LEDate { get; set; }
        public string ApplyTo { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string TypeName { get; set; }
        public string EmpEmail { get; set; }
        public string RecommandToEmail { get; set; }
        public string RecommandedName { get; set; }
        public string ReportToEmail { get; set; }
        public string ReportToEmpName { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Attendance
{
    public class AttendanceApprovalModel
    {
        public int ID { get;  set; }
        public int Approved { get;  set; }
        public int AnyDate { get;  set; }
        public string EmpCode { get;  set; }
        public string EmpName { get;  set; }
        public string AppType { get;  set; }
        public string Remarks { get;  set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GPRSLocation { get;  set; }
        public string Department { get;  set; }
        public string Date { get;  set; }
        public string Designation { get;  set; }
        public string OfficeBranch { get;  set; }
        public string Login { get;  set; }
        public string Logout { get;  set; }


    }
}

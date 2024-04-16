using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Attendance
{
    public  class IndEmpInOutModel
    {
       
        
        public string EmpCodS { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string OfficeBranch { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Login { get; set; }
        public string Logout { get; set; }
        public string WorkingHour { get; set; }
        public string Lates { get; set; }
        public string Earlier { get; set; }
        public string Status { get; set; }           
        public string Location { get; set; }        
    }

    public class ChickAttendaceModel
    {
        public int IsAttendance { get; set; }
        public int IsLeave { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Attendance
{
    public class AttendanceSummaryModel
    {
        public string MonthsName { get; set; }
        public int TotalMonthlyDays { get; set; }
        public int Holydays { get; set; }
        public int WorkingDays { get; set; }
        public int LeaveDays { get; set; }
        public int LWTP { get; set; }
        public int AbsentDays { get; set; }
        public int PressentDays { get; set; }
        public int Lates { get; set; }
   
    }
}

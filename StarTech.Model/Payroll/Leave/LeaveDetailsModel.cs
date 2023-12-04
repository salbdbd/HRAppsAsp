using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll.Leave
{
    public class LeaveDetailsModel
    {
        public int ID { get; set; }
        public int LeaveID { get; set; }
        public string EmpCode { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}

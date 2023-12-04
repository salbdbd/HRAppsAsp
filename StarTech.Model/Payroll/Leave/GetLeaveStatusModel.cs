using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll.Leave
{
    public class GetLeaveStatusModel
    {
        public string EmpCode { get; set; }
        public string TypeName { get; set; }
        public int MaxDays { get; set; }
        public int TOtalLeave { get; set; }
        public int Typeee { get; set; }
        public int AccepteDuration { get; set; }
        public int Balance { get; set; }

    }
}


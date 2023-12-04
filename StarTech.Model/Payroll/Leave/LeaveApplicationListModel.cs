using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Leave
{
    public class LeaveApplicationListModel:LeaveApplyModel
    {
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string TypeName { get; set; }
    }
}

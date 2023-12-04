using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Leave
{
    public class LeaveReportModel
    {
        public int LeaveID { get; set; }
        public string ReqFrom { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int CompanyID { get; set; }
        public string TypeName { get; set; }
        public string PayType { get; set; }
        
    }
}

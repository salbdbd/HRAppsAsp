using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll.Leave
{
    
    public class UpdateByAuthorityModel
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int AccepteDuration { get; set; }
        public int LeaveTypedID { get; set; }
        public int? UnAccepteDuration { get; set; }
        public string Grandtype { get; set; }
        public string Withpay { get; set; }
        public string AppType { get; set; }
        public int CompanyID { get; set; }

    }
}

using StarTech.Model.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Leave
{
    public class ApprovedModel
    {
        public int ID { get; set; }
        public string ReqTo { get; set; }
        public string ReqFrom { get; set; }
        public string Remarks { get; set; }
        public int CompanyID { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }

    public class SaveWMesage
    {
        public string MessagInfo { get; set; }
        public string EmpCode { get; set; }
        public string FromEmpCode { get; set; }
        public string Heading { get; set; }
        public int CompanyID { get; set; }
        public int Status { get; set; }
    }

    public class GetWMesage
    {
        public int Id { get; set; }
        public string MessagInfo { get; set; }
        public string FullName { get; set; }
        public string FromEmpCode { get; set; }
        public string Heading { get; set; }
        public int CompanyID { get; set; }
        public int Status { get; set; }
    }

    public class ChangeStatus
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}

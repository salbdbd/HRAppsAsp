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
}

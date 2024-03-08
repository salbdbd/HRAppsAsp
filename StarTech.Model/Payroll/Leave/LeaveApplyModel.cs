using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Leave
{
    public class LeaveApplyModel
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public DateTime ApplicationDate { get; set; }
        public int AccepteDuration { get; set; }
        public int LeaveTypedID { get; set; }
        public int? UnAccepteDuration { get; set; }
        public string ReferanceEmpcode { get; set; }
        public int Grandtype { get; set; }
        public string YYYYMMDD { get; set; }
        public string Withpay { get; set; }
        public string AppType { get; set; }
        public int CompanyID { get; set; }
        public DateTime LADate { get; set; }
        public DateTime LSDate { get; set; }
        public DateTime LEDate { get; set; }
        public string ApplyTo { get; set; }
        public string Reason { get; set; }
        public string EmgContructNo { get; set; }
        public string EmgAddress { get; set; }
        public string EmpEmail { get; set; }
        public string RecommandToEmail { get; set; }
        public string ReportToEmail { get; set; }


    }

    public class LeaveApply
    {
       
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int AccepteDuration { get; set; }
        public int LeaveTypedID { get; set; }
        public int? UnAccepteDuration { get; set; }
        public string ReferanceEmpcode { get; set; }
        public string Grandtype { get; set; }
        public string Withpay { get; set; }
        public string AppType { get; set; }
        public int CompanyID { get; set; }
        public string ApplyTo { get; set; }
        public string Reason { get; set; }
        public string EmgContructNo { get; set; }
        public string EmgAddress { get; set; }
        public string RecommendTo { get; set; }
       



    }
}


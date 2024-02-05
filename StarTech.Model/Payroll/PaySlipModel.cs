using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll
{
    public class PaySlipModel
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string PeriodName { get; set; }

        public double Basic { get; set; }
        public double Mobile { get; set; }
        public double HouseRent { get; set; }
        public double Conveyance { get; set; }
        public double Medical { get; set; }
        public double GrossPay { get; set; }
        public double CarAllo { get; set; }
        public double SpacilAllo { get; set; }
        public double LFA { get; set; }
        public double ELEncase { get; set; }
        public double SalesComm { get; set; }
        public double SalaryAdj { get; set; }
        public double Advance { get; set; }
        public double FstBonus { get; set; }
        public double PerBonus { get; set; }
        public double OtherAddi { get; set; }
        public double TotalAddi { get; set; }
        public double ExCelBill { get; set; }
        public double ExFulBill { get; set; }
        public double FmlyPackge { get; set; }
        public double InstalDeduct { get; set; }
        public double AbsDeduct { get; set; }
        public double SalaryDeduct { get; set; }
        public double OtherDeduct { get; set; }
        public double AdvanceDeduct { get; set; }
        public double PFOwn { get; set; }
        public double IncomeTax { get; set; }
        public double TotalDeduct { get; set; }
        public double NetPay { get; set; }

        public double ExtraAddition { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string AccountNo { get; set; }
        public string Payby { get; set; }
    }
}

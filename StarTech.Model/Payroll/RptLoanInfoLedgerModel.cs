using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll
{
    public class RptLoanInfoLedgerModel
    {
        public int id { get; set; }
        public string EmpCode { get; set; }
       
        public string LoanDate { get; set; }
        public int SalaryHeadID { get; set; }
        public int InstallmentStart { get; set; }

        public double LoanAmount { get; set; }
        public double DownPayment { get; set; }
        public double NetLoan { get; set; }
        public int NoofInstallment { get; set; }
        public int InstallmentType { get; set; }
        public double Installmentamount { get; set; }
        public double Interest { get; set; }
        public double CompanyID { get; set; }
     
        public string Remarks { get; set; }

        public string DDMMYY { get; set; }




    }
}

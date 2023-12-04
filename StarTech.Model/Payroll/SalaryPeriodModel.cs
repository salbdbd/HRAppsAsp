using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Payroll
{
    public class SalaryPeriodModel
    {
        public int ID { get; set; }
        public string PeriodName { get; set; }
        public string MonthName { get; set; }
        public string TaxYear { get; set; }
        public int CompanyID { get; set; }
       
    }
}

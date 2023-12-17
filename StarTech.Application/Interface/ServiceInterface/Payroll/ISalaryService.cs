using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.ServiceInterface.Payroll
{
    public interface ISalaryService
    {
        Task<IEnumerable<PaySlipModel>> GetPaySlip(string empCode, int periodID, int companyID,string department);
        Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int companyID);

        Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID);

    }
}
